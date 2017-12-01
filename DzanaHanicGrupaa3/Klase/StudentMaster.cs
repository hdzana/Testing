using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class StudentMaster: Student
    {
        DateTime ZavrsetakDrugiFakultet { get; set; }
        string MjestoPrethodnogObrazovanja { get; set; }

        Boolean drugi = false;

        public StudentMaster(String ime, String prezime, DateTime datumRodjenja, String maticni, DateTime prethodnoObrazovanje)
            :base(ime, prezime, datumRodjenja, maticni, prethodnoObrazovanje)
        {
            this.MjestoPrethodnogObrazovanja = null;

            if (drugi) generisiNoviIndeks();
            else generisiIndeks();
        }
        public StudentMaster(String ime, String prezime, DateTime datumRodjenja, String maticni,  DateTime drugiFaks, String mjesto)
            :base(ime, prezime, datumRodjenja, maticni, drugiFaks)
        {
            this.ZavrsetakDrugiFakultet = drugiFaks;
            this.MjestoPrethodnogObrazovanja = mjesto;

            if (MjestoPrethodnogObrazovanja != "" && MjestoPrethodnogObrazovanja != null) drugi = true;
            if (drugi) generisiNoviIndeks();
            else generisiIndeks();
        }

        public void generisiNoviIndeks()
        {
            Random random1 = new Random();
            string r = random1.Next(0, 1000).ToString("D3");
            Random random2 = new Random();
            string rb = random2.Next(0, 1000000).ToString("D6");
            string indeks = r + "/" + rb;

            this.BrojIndeks = indeks;
        }

        public void generisiIndeks()
        {
            Random random = new Random();
            string r = random.Next(0, 1000).ToString("D3");

            this.BrojIndeks = r + "/" + BrojIndeks;
        }
    }
}
