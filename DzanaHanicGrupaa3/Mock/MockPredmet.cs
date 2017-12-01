using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
   public class MockPredmet: IPredmetVandredni
    {
        public double projekatECTS(double ects)
        {
            return ects * 0.5;
        }
        public double seminarskiECTS(double ects)
        {
            return ects * 0.3;
        }
        public double zadaceECTS(double ects)
        {
            return ects * 0.15;
        }
        public double ispitiECTS(double ects)
        {
            return ects * 0.9;
        }
        public string dajGeneralneInformacije(string naziv, string opis)
        {
            return naziv + " " + opis;

        }
        public double dajECTSuSate(int bodovi)
        {
            return bodovi * 25;
        }
        public List<string> dajNastavniAnsambl(List<Uposlenik> uposlenici)
        {
            List<string> _uposlenici = new List<string>();

            for (int i = 0; i < uposlenici.Count(); i++)
            {
                _uposlenici.Add(uposlenici[i].Ime + " " + uposlenici[i].Prezime);
                
            }

            return _uposlenici;

        }
    }
}
