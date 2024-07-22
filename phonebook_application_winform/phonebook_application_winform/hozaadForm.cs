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
    public partial class hozaadForm : Form
    {
        List<Telefon> telefonok = new List<Telefon>();
        public hozaadForm()
        {
            InitializeComponent();
        }

        private void hozaadForm_Load(object sender, EventArgs e)
        {
            Beolvasas();
        }
        private void visszabtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
                telefonok.Add(new Telefon(adatok[0], adatok[1], adatok[2], adatok[3], double.Parse(adatok[4]), adatok[5], adatok[6], int.Parse(adatok[7])));
                sor = sr.ReadLine();
            }
        }

        private void hozzaadbtn_Click(object sender, EventArgs e)
        {
            string nev;
            string cim;
            string apa;
            string anya;
            double telefonszam;
            string nem;
            string email;
            double szamszam;

            nev = nevtxt.Text;
            cim = cimtxt.Text;
            apa = apatxt.Text;
            anya = anyatxt.Text;
            telefonszam = double.Parse(telefonszamtxt.Text);
            nem = nemtxt.Text;
            email = emailtxt.Text;
            szamszam = double.Parse(szemszamtxt.Text);

            Telefon item = new Telefon(nev,cim,apa,anya, telefonszam,nem,email,szamszam);

            telefonok.Add(item);

            StreamWriter sw = new StreamWriter("telefonkonyv.txt");
            
            foreach (Telefon t in telefonok)
            {
                sw.WriteLine($"{t.nev};{t.cim};{t.apa};{t.anya};{t.telSzam};{t.nem};{t.email};{t.szemelyiSzam}");
            }sw.Close();

            nevtxt.Clear();
            cimtxt.Clear();
            apatxt.Clear();
            anyatxt.Clear();
            telefonszamtxt.Clear();
            nemtxt.Clear();
            emailtxt.Clear();
            szemszamtxt.Clear();
        }
    }
}