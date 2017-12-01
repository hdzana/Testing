using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class UposlenikPrivremeni : Uposlenik
    {
        public DateTime PocetakUgovora { get; set; }
        public DateTime ZavrsetakUgovora { get; set; }
        public readonly int BrCasovaSedmicno;

        public UposlenikPrivremeni()
        {

        }
        public UposlenikPrivremeni(string ime, string prezime, DateTime datum, String maticni, Pozicija pozicija, DateTime pocetak, DateTime zavrsetak, int brojCasova)
            : base(ime, prezime, datum, maticni, pozicija)
        {

            if(pocetak > zavrsetak)
                throw new ArgumentException("Pogresan unos datuma pocetka i zavrsetka ugovora");

            this.PocetakUgovora = pocetak;
            this.ZavrsetakUgovora = zavrsetak;
            this.BrCasovaSedmicno = brojCasova;

            obracunajPlatu();

        }

        public override void obracunajPlatu()
        {
            double trajanje = (this.ZavrsetakUgovora - this.PocetakUgovora).TotalDays;
            switch (this.PozicijaUposlenika)
            {
                case Pozicija.Demonstrator:
                    {
                        this.Plata = (BrCasovaSedmicno * 10) * trajanje;
                        break;
                    }
                case Pozicija.StrucnjakIzPrakse:
                    {
                        this.Plata = (BrCasovaSedmicno * 15) * trajanje;
                        break;
                    }
                case Pozicija.GostujuciPredavac:
                    {
                        this.Plata = (BrCasovaSedmicno * 20) + 150;
                        break;
                    }
            }

        }
    }
}
