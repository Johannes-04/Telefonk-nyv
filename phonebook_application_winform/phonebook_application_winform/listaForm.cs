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
    public partial class listaForm : Form
    {
        List<Telefon> telefonok = new List<Telefon>();
        public listaForm()
        {
            InitializeComponent();
        }

        private void listaForm_Load(object sender, EventArgs e)
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


        private void tellist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tellist.SelectedItem != null)
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
    }
}
