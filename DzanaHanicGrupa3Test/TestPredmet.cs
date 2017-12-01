using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;

namespace DzanaHanicGrupa3Test
{
    /// <summary>
    /// Summary description for TestPredmet
    /// </summary>
    [TestClass]
    public class TestPredmet
    {
        Fakultet fax;
        public TestPredmet()
        {
            fax = new Fakultet("ETF");
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        

        //test metoda koja testira da li student moze upisati isti predmet dvaput
        //test nece pasti jer je ocekivan izuetak

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_PolaganjeIstogPredmeta()
        {
            StudentBachelor student1 = new StudentBachelor("Dzana", "Hanic", new DateTime(1995, 12, 27), "2712995111222", new DateTime(2014, 10, 10));
            fax.upisiStudenta(student1);

            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            fax.dodajUposlenika(u1);

            Predmet tp = new Predmet("TP", "Tehnike programiranja", "Bachelor", 14, 7, 100, 8, uposleni, "Programiranje for life");
            fax.dodajPredmet(tp);

            student1.polaganjePredmeta(tp);
            student1.polaganjePredmeta(tp);
        }



        //test metoda koja testira da li student moze slusati/polagati predmet kada je premasen dozvoljen broj studenata
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_KapacitetPopunjen()
        {
            StudentBachelor student1 = new StudentBachelor("Nina", "Simone", new DateTime(1995, 03, 05), "0503996175032", new DateTime(2014, 10, 10));
            fax.upisiStudenta(student1);

            StudentBachelor student2 = new StudentBachelor("Leonard", "Cohen", new DateTime(1993, 11, 20), "2011993180008", new DateTime(2014, 10, 10));
            fax.upisiStudenta(student1);

            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1970, 05, 02), "0205970177176", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            fax.dodajUposlenika(u1);

            //broj dozvoljenih studenata = 1
            Predmet ld = new Predmet("LD", "Logički dizajn", "Bachelor", 14, 7, 1, 6, uposleni, "LD struggle");

            student1.polaganjePredmeta(ld);
            student2.polaganjePredmeta(ld);

            //test nece pasti jer je izuzetak ocekivan (predmet ne mogu slusati/polagati 2 studenta jer je kapacitet 1)
        }


        //test svi predmeti u dosadasnjoj listi na fakultetu nisu null

        [TestMethod]
        public void Test_IspravnoDodaniPredmeti()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet im1 = new Predmet("IM1", "Inzenjerska matematika1", "Bachelor", 14, 7, 100, 8, uposleni, "Matematika<3");
            Predmet im2 = new Predmet("IM2", "Inzenjerska matematika2", "Bachelor", 14, 7, 100, 8, uposleni, "Matematika<3");

            fax.dodajPredmet(im1);
            fax.dodajPredmet(im2);

            CollectionAssert.AllItemsAreNotNull(fax.dajSvePredmete());


        }

        [TestMethod]
        public void Test_SifraPredmeta()
        {

            Fakultet f = new Fakultet("ASU");
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet im1 = new Predmet("IM1", "Inzenjerska matematika1", "Bachelor", 14, 7, 100, 8, uposleni, "Matematika<3");
            f.dodajPredmet(im1);

            StringAssert.EndsWith(im1.SifraPredmeta, f.dajSvePredmete()[0].SifraPredmeta);
        }


        //test svi predmeti u dosadasnjoj listi su jedinstveni

        [TestMethod]
        public void Test_JedinstveniPredmeti()
        {
            CollectionAssert.AllItemsAreUnique(fax.dajSvePredmete());
        }


        //test string Assert

        [TestMethod]
        public void Test_ProvjeraNazivaPredmeta()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet im2 = new Predmet("IM2", "Inzenjerska matematika2", "Bachelor", 14, 7, 100, 8, uposleni, "Matematika<3");

            StringAssert.Contains("Inzenjerska matematika2", im2.NazivPredmeta);

        }


    }
}
