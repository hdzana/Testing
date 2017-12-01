using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class StudentBachelor : Student
    { 

        public StudentBachelor(String ime, String prezime, DateTime datumRodjenja, String maticni, DateTime prethodnoObrazovanje)
            : base(ime, prezime, datumRodjenja, maticni, prethodnoObrazovanje) { }


    }
}
