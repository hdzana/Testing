using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public interface IPredmetVandredni : IPredmet
    {
        double projekatECTS(double ects);
        double seminarskiECTS(double ects);
        double zadaceECTS(double ects);
        double ispitiECTS(double ects);
    }
}
