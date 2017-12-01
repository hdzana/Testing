using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class UposlenikStalni : Uposlenik
    {
        public double Norma { get; set; }
        public string StrucnaSprema { get; set; }
        public String Titula { get; set; }

        const double minNorma = 0.5;
        const double maxNorma = 1.5;
        public UposlenikStalni()
        {

        }
        public UposlenikStalni(string ime, string prezime, DateTime datum, String maticni, Pozicija pozicija, double norma, string sprema, String titula)
           : base(ime, prezime, datum, maticni, pozicija)
        {
            if (norma > maxNorma)
                this.Norma = maxNorma;
            else if (norma < minNorma)
                this.Norma = minNorma;
            else
                this.Norma = norma;

            this.StrucnaSprema = sprema;
            this.Titula = titula;

            obracunajPlatu();
        }


        public override void obracunajPlatu()
        {
            switch (this.PozicijaUposlenika)
            {
                case Pozicija.Asistent:
                    {
                        this.Plata = Norma * 1100;
                        break;
                    }
                case Pozicija.VisiAsistent:
                    {
                        this.Plata = Norma * 1300;
                        break;
                    }
                case Pozicija.Docent:
                    {
                        this.Plata = (Norma + 0.1) * 1300;
                        break;
                    }
                case Pozicija.VandredniProfesor:
                    {
                        this.Plata = (Norma + 0.2) * 1300 + 150;
                        break;
                    }
                case Pozicija.RedovniProfesor:
                    {
                        this.Plata = (Norma + 0.3) * 1500;
                        break;
                    }
                case Pozicija.Akademik:
                    {
                        this.Plata = (Norma + 0.3) * 2000;
                        break;
                    }






            }
        }

    }
}
