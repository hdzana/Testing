using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class Predmet
    {
        public String SifraPredmeta { get; set; }
        public String NazivPredmeta { get; set; }
        public String Studij { get; set; }
        public int BrojPredavanja { get; set; }
        public int BrojVjezbi { get; set; }
        public int DozvoljeniBrojStudenata { get; set; }
        public int BrojECTS { get; set; }
        public List<Uposlenik> NastavniAnsambl { get; set; }
        public String OpisPredmeta { get; set; }

        public int TrenutniBrojStudenata { get; set; }

        private IPredmet _stubPredmet;
        public IPredmetVandredni _mockPredmet;
        public Predmet(IPredmet p)
        {
            this._stubPredmet = p;
        }

        public Predmet(IPredmetVandredni p)
        {
            this._mockPredmet = p;
        }
        public Predmet() { }
        public Predmet(String sifra, String naziv, String studij, int brPred, int brVjezbe, int brstudenti, int brECTS, List<Uposlenik>nastavniAnsambl, String opis)
        {
            this.SifraPredmeta = sifra;
            this.NazivPredmeta = naziv;
            this.Studij = studij;
            this.BrojPredavanja = brPred;
            this.BrojVjezbi = brVjezbe;
            this.DozvoljeniBrojStudenata = brstudenti;
            this.BrojECTS = brECTS;
            this.NastavniAnsambl = nastavniAnsambl;
            this.OpisPredmeta = opis;

            TrenutniBrojStudenata = 0;
        }

        public String generalneInformacije(string naziv, string opis)
        {
            return _stubPredmet.dajGeneralneInformacije(naziv, opis);
        }
        public List<string> dajNastavniAnsambl(List<Uposlenik> uposlenici)
        {
            return _stubPredmet.dajNastavniAnsambl(uposlenici);
        }
        public double ECTSuSate(int bodovi)
        {
            return _stubPredmet.dajECTSuSate(bodovi);
        }
    }
}
