using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadatak1
{
    public class StubPredmet: IPredmet
    {
        public string dajGeneralneInformacije(string naziv, string opis)
        {
            return "Verifikacija i validacija softvera" + " " + "Test";

        }
        public double dajECTSuSate(int bodovi)
        {
            return 5.3;
        }
        public List<string> dajNastavniAnsambl(List<Uposlenik> uposlenici)
        {
            List <String> _uposlenici = new List<String>();

            _uposlenici.Add("Joan Dylan");
            _uposlenici.Add("Bob Dylan");
            _uposlenici.Add("Joan Joan");
            return _uposlenici;

        }
    }
}
