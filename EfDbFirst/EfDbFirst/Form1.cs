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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NORTHWNDEntities context = new NORTHWNDEntities();

        private void LadenButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees.ToList();
            dataGridView1.DataSource = context.Employee_Sales_by_Country(DateTime.Now.AddYears(-100), DateTime.Now);
        }
    }
}
