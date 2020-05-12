using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfDbFirst
{
    public delegate object SuperDelegate(string txt);
    public partial class Form1 : Form
    {

        public event SuperDelegate SuperClick;

        public Form1()
        {
            InitializeComponent();

            this.Click += Form1_Click;
            SuperClick += Form1_SuperClick;
        }

        private object Form1_SuperClick(string msg)
        {
            throw new NotImplementedException();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
          //  SuperClick.Invoke("GeSUPERclicked");
        }

        NORTHWNDEntities context = new NORTHWNDEntities();

        private void LadenButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees.ToList();
            dataGridView1.DataSource = context.Employee_Sales_by_Country(DateTime.Now.AddYears(-100), DateTime.Now);
        }
    }
}
