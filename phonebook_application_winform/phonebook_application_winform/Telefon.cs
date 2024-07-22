using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebook_application_winform
{
    public class Telefon
    {
        public string nev;
        public string cim;
        public string apa;
        public string anya;
        public double telSzam;
        public string nem;
        public string email;
        public double szemelyiSzam;

        public Telefon(string nev, string cim, string apa, string anya, double telSzam, string nem, string email, double szemelyiSzam)
        {
            this.nev = nev;
            this.cim = cim;
            this.apa = apa;
            this.anya = anya;
            this.telSzam = telSzam;
            this.nem = nem;
            this.email = email;
            this.szemelyiSzam = szemelyiSzam;
        }

        public override string ToString()
        {
            return nev;
        }
    }
}
