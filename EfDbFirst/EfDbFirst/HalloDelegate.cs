using System;
using System.Collections.Generic;
using System.Linq;

namespace EfDbFirst
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitParameter(string text);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            Action meineDeleAlsAction = EinfacheMethode;
            Action meineDeleAlsActionAno = delegate () { Console.WriteLine("Hallo"); };
            Action meineDeleAlsActionAno2 = () => { Console.WriteLine("Hallo"); };
            Action meineDeleAlsActionAno3 = () => Console.WriteLine("Hallo");

            DelegateMitParameter deleMitPara = MethodeMitPara;
            Action<string> deleMitParaAlsAction = MethodeMitPara;
            Action<string> deleMitParaAlsActionAno = delegate (string txt) { Console.WriteLine(txt); };
            Action<string> deleMitParaAlsActionAno2 = (txt) => Console.WriteLine(txt);
            Action<string> deleMitParaAlsActionAno3 = x => Console.WriteLine(x);

            CalcDelegate calc = Multi;
            Func<int, int, long> calcFunc = Sum;
            CalcDelegate calcAno = (int a, int b) => { return a + b; };
            CalcDelegate calcAno2 = (a, b) => a + b;

            List<string> texte = new List<string>();
            texte.Where(x => x.StartsWith("F"));
            texte.Where(x => Filter(x));
            texte.Where(Filter);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("F"))
                return true;
            else
                return false;
        }

        private long Multi(int a, int b)
        {
            return a * b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string text)
        {
            Console.WriteLine(text);
        }

        public void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}
