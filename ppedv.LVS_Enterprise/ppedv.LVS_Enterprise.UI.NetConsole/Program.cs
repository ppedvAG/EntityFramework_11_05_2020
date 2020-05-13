using ppedv.LVS_Enterprise.Logic;
using ppedv.LVS_Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.LVS_Enterprise.UI.NetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** LVS Enterprise v0.1 ***");

            var core = new LVSCore();
            foreach (var art in core.Repository.GetAll<Artikel>())
            {
                Console.WriteLine($"{art.Bezeichnung} {art.Gewicht}kg");
            }

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
