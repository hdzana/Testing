using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public interface IPredmet
    {
        string dajGeneralneInformacije(string naziv, string opis);
        double dajECTSuSate(int bodovi);
        List<string> dajNastavniAnsambl(List<Uposlenik> uposlenici);
    }
}
