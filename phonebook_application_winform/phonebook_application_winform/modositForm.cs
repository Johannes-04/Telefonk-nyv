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
    public partial class modositForm : Form
    {
        List<Telefon> telefonok = new List<Telefon>();
        public modositForm()
        {
            InitializeComponent();
        }

        private void modositForm_Load(object sender, EventArgs e)
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

        private void Tisztitt()
        {
            nevtxt.Clear();
            cimtxt.Clear();
            apatxt.Clear();
            anyatxt.Clear();
            telefonszamtxt.Clear();
            nemtxt.Clear();
            emailtxt.Clear();
            szemszamtxt.Clear();
        }
        private void tellist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tellist.SelectedItem != null)
            {
                int szam;
                szam = tellist.SelectedIndex;
                nevtxt.Text = telefonok[szam].nev;
                cimtxt.Text = telefonok[szam].cim;
                apatxt.Text = telefonok[szam].apa;
                anyatxt.Text = telefonok[szam].anya;
                telefonszamtxt.Text = telefonok[szam].telSzam.ToString();
                nemtxt.Text = telefonok[szam].nem;
                emailtxt.Text = telefonok[szam].email;
                szemszamtxt.Text = telefonok[szam].szemelyiSzam.ToString();
            }
        }
        private void visszabtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void modBt_Click(object sender, EventArgs e)
        {
            int szam;
            szam = tellist.SelectedIndex;
            telefonok[szam].nev = nevtxt.Text;
            telefonok[szam].cim = cimtxt.Text;
            telefonok[szam].apa = apatxt.Text;
            telefonok[szam].anya = anyatxt.Text;
            telefonok[szam].telSzam = double.Parse(telefonszamtxt.Text);
            telefonok[szam].nem = nemtxt.Text;
            telefonok[szam].email = emailtxt.Text;
            telefonok[szam].szemelyiSzam = double.Parse(szemszamtxt.Text);
            FelRak();
            Kiir();
            Tisztitt();
        }  
    }
}
