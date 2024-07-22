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
    public partial class keresesForm : Form
    {
        private List<Telefon> telefonok = new List<Telefon>();
        public keresesForm()
        {
            InitializeComponent();
        }

        private void keresesForm_Load(object sender, EventArgs e)
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

        private void visszabtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void keresbtn_Click(object sender, EventArgs e)
        {
            string nev = kerestxt.Text;

            foreach (var item in telefonok)
            {
                if (item.nev == nev)
                {
                    nevtxt.Text = item.nev;
                    cimtxt.Text = item.cim;
                    apatxt.Text = item.apa;
                    anyatxt.Text = item.anya;
                    telefonszamtxt.Text = item.telSzam.ToString();
                    nemtxt.Text = item.nem;
                    emailtxt.Text = item.email;
                    szemszamtxt.Text = item.szemelyiSzam.ToString();
                    break;
                }
            }
        }
    }
}