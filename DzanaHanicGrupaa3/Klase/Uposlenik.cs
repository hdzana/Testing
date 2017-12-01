using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadatak1
{

    public enum Pozicija { Demonstrator =1, StrucnjakIzPrakse=2, GostujuciPredavac=3, Asistent=4, VisiAsistent=5, Docent=6, VandredniProfesor=7, RedovniProfesor=8, Akademik=9 }

    public abstract class Uposlenik
    {
       
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String MaticniBroj { get; set; }
        public string SifraUposlenog { get; set; }
        public double Plata { get; set; }

        public Pozicija PozicijaUposlenika { get; set; }

        public Uposlenik() { }
        public Uposlenik(string ime, string prezime, DateTime datum, String maticni, Pozicija pozicija)
        {
           
            this.DatumRodjenja = datum;
            this.PozicijaUposlenika = pozicija;

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

            generisiSifru();
        }

        void generisiSifru()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            this.SifraUposlenog =  new string(Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static readonly Regex JMBG = new Regex("[0-9]{13}");
        public Boolean validirajMaticni(string maticni)
        {

            if (JMBG.IsMatch(maticni) == false)
            {
                throw new ArgumentException("Neispravan maticni broj. <13");
            }

            if ((maticni.Substring(0, 2) != this.DatumRodjenja.Day.ToString()) ||
                     (maticni.Substring(2, 2) != this.DatumRodjenja.ToString("MM")) ||
                         (maticni.Substring(4, 3) != this.DatumRodjenja.Year.ToString().Substring(1, 3)))
            {
                throw new ArgumentException("Neispravan maticni broj");
            }


            return true;

        }

        public abstract void obracunajPlatu();

    }
}
