using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadatak1
{
    public abstract class Student
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MaticniBroj { get; set; }
        public DateTime ZavrsetakPrethodnog { get; set; }
        public string BrojIndeks { get; set; }

        public List<Predmet> PolozeniPredmeti { get; set; }

        public Student() { }
        public Student(String ime, String prezime, DateTime datumRodjenja, String maticni, DateTime prethodnoObrazovanje)
        {
          
            this.DatumRodjenja = datumRodjenja;
            this.ZavrsetakPrethodnog = prethodnoObrazovanje;

            Regex r = new Regex("^[a-zA-Z]*$");
            if (r.IsMatch(ime) && r.IsMatch(prezime))
            {
                this.Ime = ime;
                this.Prezime = prezime;
            }
            else
                throw new ArgumentException("Neispravan format imena/prezimena.");

            if (validirajMaticni(maticni))
                this.MaticniBroj = maticni;
            

            kreirajIndeks();

            PolozeniPredmeti = new List<Predmet>();

        }

        private static readonly Regex JMBG = new Regex("[0-9]{13}");
        public Boolean validirajMaticni(string maticni)
        {
            if (JMBG.IsMatch(maticni) == false)
            {
                
                throw new ArgumentException("Neispravan maticni broj. (broj cifara != 13)");
            }

            if ((maticni.Substring(0, 2) != this.DatumRodjenja.Day.ToString()) ||
                     (maticni.Substring(2, 2) != this.DatumRodjenja.ToString("MM")) ||
                         (maticni.Substring(4, 3) != this.DatumRodjenja.Year.ToString().Substring(1, 3)))
            {
                
                throw new ArgumentException("Neispravan maticni broj");
            }

            int[] jmb = new int[13] { Int32.Parse(maticni[0].ToString()), Int32.Parse(maticni[1].ToString()), Int32.Parse(maticni[2].ToString()),
                                        Int32.Parse(maticni[3].ToString()), Int32.Parse(maticni[4].ToString()), Int32.Parse(maticni[5].ToString()),
                                        Int32.Parse(maticni[6].ToString()), Int32.Parse(maticni[7].ToString()), Int32.Parse(maticni[8].ToString()),
                                        Int32.Parse(maticni[9].ToString()), Int32.Parse(maticni[10].ToString()), Int32.Parse(maticni[11].ToString()),
                                        Int32.Parse(maticni[12].ToString()) };

            //formula za racunanje kontrolne cifre
            int kontrolnaCifra = 11 - ((7 * (jmb[0] + jmb[6]) + 6 * (jmb[1] + jmb[7]) +
                                        5 * (jmb[2] + jmb[8]) + 4 * (jmb[3] + jmb[9]) +
                                        3 * (jmb[4] + jmb[10]) + 2 * (jmb[5] + jmb[11])) % 11);

            if (kontrolnaCifra > 9) kontrolnaCifra = 0;

            if (kontrolnaCifra != jmb[12])
            {
                throw new Exception("Neispravna kontrolna cifra");
            }


            return true;

        }

        public void kreirajIndeks()
        {
            Random random = new Random();
            string rb = random.Next(0, 1000000).ToString("D6");

            this.BrojIndeks = rb;
        }

        public void polaganjePredmeta(Predmet p)
        {
            if (this.PolozeniPredmeti.Contains(p))
                throw new ArgumentException("Predmet je vec polozen");

            if (upisiPredmet(p))
                 this.PolozeniPredmeti.Add(p);
        }

        public Boolean upisiPredmet(Predmet p)
        {
            if (p.TrenutniBrojStudenata >= p.DozvoljeniBrojStudenata)
                throw new ArgumentException("Kapaciteti za ovaj predmet su već popunjeni");

            p.TrenutniBrojStudenata++;
            return true;
        }
    }
}
