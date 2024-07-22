using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phonebook_application_winform
{


    public partial class Form1 : Form
    {
        private List<Telefon> telefonok = new List<Telefon>();
        public Form1()
        {
            InitializeComponent();
        }

        private void ujhozzaadasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hozaadForm hozad = new hozaadForm();
            hozad.ShowDialog();
        }

        private void listazasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaForm lista = new listaForm();
            lista.ShowDialog();
        }

        private void kilepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztosan kilép?", "Megerősítés", MessageBoxButtons.YesNo);
            if (valasz == DialogResult.Yes) this.Close();
        }

        private void modositasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modositForm modosit = new modositForm();
            modosit.ShowDialog();
        }

        private void keresesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keresesForm keres = new keresesForm();
            keres.ShowDialog();
        }

        private void torlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            torlesForm torles = new torlesForm();
            torles.ShowDialog();
        }
    }
}