using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfModelFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.CellContentDoubleClick += DataGridView1_CellContentDoubleClick;

        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem is Mitarbeiter mit)
            {
                EntityState state = context.Entry(mit).State;

                MessageBox.Show(state.ToString());
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is IEnumerable<Abteilung> abts)
            {
                e.Value = string.Join(", ", abts.Select(x => x.Bezeichnung));
            }
        }

        Model1Container context = new Model1Container();

        private void LadenButton_Click(object sender, EventArgs e)
        {
            var query = context.PersonSet.OfType<Mitarbeiter>()
                               .Where(x => x.Name.StartsWith("F"))
                               .Include(x => x.Abteilung) //eager loading
                               .Include(x => x.Kunde);

            //MessageBox.Show(query.ToString());
            Debug.WriteLine(query.ToString());

            dataGridView1.DataSource = query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Name = $"Fred #{i:000}",
                    GebDatum = DateTime.Now.AddYears(-30).AddDays(i * 17),
                    Beruf = "Macht dinge"
                };

                //string interpolation
                //m.Name = "Fred #" + i.ToString("000");
                //m.Name = string.Format("Fred #{0:000} {1}", i);
                //m.Name = $"Fred #{i:000}";

                if (i % 2 == 0)
                    m.Abteilung.Add(abt1);
                if (i % 3 == 0)
                    m.Abteilung.Add(abt2);

                context.PersonSet.Add(m);
            }
            context.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem is Mitarbeiter mit)
            {
                var txt = $"Soll der Mitarbeiter {mit.Name} wirklich gelöscht werden?";
                if (MessageBox.Show(txt, "Löschen?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    context.PersonSet.Remove(mit);
                }
            }
        }
    }
}
