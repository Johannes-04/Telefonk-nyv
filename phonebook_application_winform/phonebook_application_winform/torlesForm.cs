using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phonebook_application_winform
{
    public partial class torlesForm : Form
    {
        List<Telefon> telefonok = new List<Telefon>();
        public torlesForm()
        {
            InitializeComponent();
        }

        private void torlesForm_Load(object sender, EventArgs e)
        {
            Beolvasas();
        }

        private void Beolvasas()
        {
            StreamReader sr = null;
            try
            {
                string fajlNev = "telefonkonyv.txt";
                sr = new StreamReader(fajlNev);

                AdatBevitel(sr);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hibaüzenet a fejlesztő számára");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    FelRak();
                }
            }
        }

        private void AdatBevitel(StreamReader sr)
        {
            string sor = sr.ReadLine();
            string[] adatok;
            while (sor != null)
            {
                adatok = sor.Split(';');
                telefonok.Add(new Telefon(adatok[0], adatok[1], adatok[2], adatok[3], double.Parse(adatok[4]), adatok[5], adatok[6], double.Parse(adatok[7])));
                sor = sr.ReadLine();
            }
        }
        public void FelRak()
        {
            tellist.Items.Clear();
            foreach (var item in telefonok)
            {
                tellist.Items.Add(item.ToString());
            }
        }
        private void Kiir()
        {
            StreamWriter sw = new StreamWriter("telefonkonyv.txt");

            foreach (Telefon t in telefonok)
            {
                sw.WriteLine($"{t.nev};{t.cim};{t.apa};{t.anya};{t.telSzam};{t.nem};{t.email};{t.szemelyiSzam}");
            }
            sw.Close();
        }

        private void visszabtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void torlesbtn_Click(object sender, EventArgs e)
        {
            if (tellist.SelectedItem != null)
            {

                int selectedIndex = tellist.SelectedIndex;
                tellist.Items.RemoveAt(selectedIndex);

                telefonok.RemoveAt(selectedIndex);
                FelRak();
                Kiir();
            }
        }
    }
}