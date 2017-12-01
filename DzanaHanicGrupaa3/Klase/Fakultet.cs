using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class Fakultet
    {
        private List<Student> _studenti = null;
        private List<Uposlenik> _uposleni = null;
        private List<Predmet> _predmeti = null;

        private List<String> _indeksi = null;

        private double fond;
        private Boolean prazanFond;

        private string imeFakulteta;

        public Fakultet(string ime)
        {
            Regex r = new Regex("^[a-zA-Z0-9 ]*$");

            if (r.IsMatch(ime))
                imeFakulteta = ime;
            else
                throw new ArgumentException("Neispravn format naziva fakulteta");

            _studenti = new List<Student>();
            _uposleni = new List<Uposlenik>();
            _predmeti = new List<Predmet>();
            _indeksi = new List<String>();

            fond = 0.0;
            prazanFond = true;

        }
        public List<Student> dajSveStudente() { return _studenti; }
        public List<String> dajSveIndekse() { return _indeksi; }
        public List<Uposlenik> dajSveUposlenike() { return _uposleni; }
        public List<Predmet> dajSvePredmete() { return _predmeti; }
        public Boolean fondFlag() { return prazanFond; }


        //studenti
        public void upisiBachelor(String ime, String prezime, DateTime datumRodjenja, String maticni, DateTime prethodnoObrazovanje)
        {
            StudentBachelor student = new StudentBachelor(ime, prezime, datumRodjenja, maticni, prethodnoObrazovanje);
  
            provjeriIndeks(student);

            if (provjeriStudente(student))
            {
                _studenti.Add(student);
                fond += 2000;
                prazanFond = false;
            }

            else
                throw new ArgumentException("Student sa istim maticnim brojem vec postoji");
        }


        public void upisiMaster(String ime, String prezime, DateTime datumRodjenja, String maticni, DateTime prethodnoObrazovanje)
        {
            StudentMaster student = new StudentMaster(ime, prezime, datumRodjenja, maticni, prethodnoObrazovanje);

            provjeriIndeks(student);
            _studenti.Add(student);

            fond += 2000;
            prazanFond = false;
        }

       

        public void upisiMasterDrugiFaks(StudentMaster student)
        {

            provjeriIndeks(student);
            _studenti.Add(student);
            fond += 2000;
            prazanFond = false;
        }

        public void upisiStudenta(Student student)
        {
            provjeriIndeks(student);
            _studenti.Add(student);
            fond += 2000;
            prazanFond = false;
        }

        //metoda koja ne dopusta da se na fakultet upisu studenti sa istim maticnim brojem (isti student?)
        public Boolean provjeriStudente(Student student)
        {
            foreach (Student s in _studenti)
            {
                if (s.MaticniBroj == student.MaticniBroj)
                    return false;
                    
            }
            return true;

        }
      

        public void provjeriIndeks(Student student)
        {
            while (_indeksi.Contains(student.BrojIndeks))
            {
                Random random = new Random();
                string rb = random.Next(0, 1000000).ToString("D6");

                student.BrojIndeks = rb;
            }

            _indeksi.Add(student.BrojIndeks);

        }



        //predmeti
        public void dodajPredmet(Predmet p)
        {
            if (!_predmeti.Contains(p))
                _predmeti.Add(p);
        }


        //uposlenici
       

        public void dodajUposlenika(Uposlenik u)
        {
            if (!_uposleni.Contains(u))
                _uposleni.Add(u);
        }

        public Boolean isplatiIzFonda(double n)
        {
            if (prazanFond) return false;

            if ((fond - n) < 0) return false;

            fond -= n;

            if (Math.Abs(fond) < 0.001)
                prazanFond = true;

            return true;
        }

    }
}
