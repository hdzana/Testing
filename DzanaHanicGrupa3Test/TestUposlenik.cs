using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;
namespace Zadatak2
{
    /// <summary>
    /// Summary description for TestUposlenik
    /// </summary>
    [TestClass]
    public class TestUposlenik
    {
        Fakultet fax;
        public TestUposlenik()
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

        [TestMethod]
        public void Test_DodavanjeUposlenika()
        {
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            UposlenikStalni u2 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1971, 10, 20), "2010971111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            UposlenikPrivremeni u3 = new UposlenikPrivremeni("Bob", "Dylan", new DateTime(1970, 10, 20), "2010970111444", Pozicija.Demonstrator, DateTime.Now, new DateTime(2017, 10, 10), 3);

            fax.dodajUposlenika(u1);
            fax.dodajUposlenika(u2);
            fax.dodajUposlenika(u3);

            CollectionAssert.AllItemsAreInstancesOfType(fax.dajSveUposlenike(), typeof(Uposlenik));
        }


        //pogresan unos datuma pocetka i zavrsetka ugovora

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_DatumUgovora()
        {
            DateTime pocetak = new DateTime(2017, 10, 10);
            DateTime zavrsetak = DateTime.Now;
            UposlenikPrivremeni u4 = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.StrucnjakIzPrakse, pocetak, zavrsetak, 2);

            u4.obracunajPlatu();

            //ocekivano je padanje testa, pocetak > zavrsetak
        }



        //test kojim se provjerava da su svi elementi u listi uposlenika na fakultetu jedinstveni
        //CollectionAssert - AllItemsAreUnique

        [TestMethod]
        public void Test_JedinstveniUposlenici()
        {
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            UposlenikStalni u2 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1971, 10, 20), "2010971111444", Pozicija.VandredniProfesor, 1, "s", "prof dr");
            UposlenikPrivremeni u3 = new UposlenikPrivremeni("Bob", "Dylan", new DateTime(1970, 10, 20), "2010970111444", Pozicija.Demonstrator, DateTime.Now, new DateTime(2017, 10, 10), 5);
            UposlenikPrivremeni u4 = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.StrucnjakIzPrakse, DateTime.Now, new DateTime(2017, 10, 10), 2);
            UposlenikPrivremeni u5 = new UposlenikPrivremeni("Sara", "Dylan", new DateTime(1975, 10, 20), "2010975111444", Pozicija.GostujuciPredavac, DateTime.Now, new DateTime(2017, 10, 10), 3);

            fax.dodajUposlenika(u3);
            fax.dodajUposlenika(u4);
            fax.dodajUposlenika(u5);

            CollectionAssert.AllItemsAreUnique(fax.dajSveUposlenike());

        }


        //test kojim se provjerava da nema null elemenata u dosadasnjoj listi (svi su uspjesno kreirani)

        [TestMethod]
        public void Test_DodavanjeSvihUposlenika()
        {
            CollectionAssert.AllItemsAreNotNull(fax.dajSveUposlenike());
        }


        //testiranje plate stalnog uposlenika - redovni profesor
        //Assert - IsTrue

        [TestMethod]
        public void Test_ObracunPlateStalni()
        {
            double norma = 1;

            double ocekivanaPlata = (norma + 0.3) * 1500;
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, norma, "s", "red prof dr");

            double razlika = Math.Abs(ocekivanaPlata - u1.Plata);
            Assert.IsTrue(razlika <= 0.0001);
        }


        //testiranje plate privremenog uposlenika - demonstrator
        //Assert - IsFalse

        [TestMethod]
        public void Test_ObracunPlatePrivremeni()
        {
            DateTime danP = new DateTime(2016, 11, 11);
            DateTime danK = new DateTime(2016, 11, 12);
            int brojCasova = 1;
            UposlenikPrivremeni u3 = new UposlenikPrivremeni("Bob", "Dylan", new DateTime(1970, 10, 20), "2010970111444", Pozicija.Demonstrator, danP, danK, brojCasova);

            double ocekivanaPlata = brojCasova * 10 * 1;
            double razlika = Math.Abs(ocekivanaPlata - u3.Plata);

            Assert.IsFalse(razlika > 0.0001);

        }


        //testiranje ispravnosti unesenih podataka

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Podaci()
        {
            UposlenikPrivremeni u3 = new UposlenikPrivremeni("_Bob", "Dylan321", new DateTime(1970, 10, 20), "2010970111444", Pozicija.Demonstrator, DateTime.Now, new DateTime(2017, 10, 10), 3);
            UposlenikStalni u1 = new UposlenikStalni("Miles", "Davis", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1, "s", "red prof dr");

            //ocekivano je padanje testa jer format imena/prezimena uposlenika u3 nije ispravan
        }

        [TestMethod]
        public void Test_JMBUposlenik()
        {
            UposlenikStalni u1 = new UposlenikStalni("Miles", "Davis", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1, "s", "red prof dr");

            StringAssert.StartsWith(u1.MaticniBroj, u1.DatumRodjenja.Day.ToString()+u1.DatumRodjenja.Month.ToString());
        }





        //Norma

        [TestMethod]
        public void Test_NormaMinMax()
        {
            double n1 = 0.2;
            double n2 = 5.9;

            UposlenikStalni u1 = new UposlenikStalni("Chet", "Baker", new DateTime(1972, 10, 21), "2110972211444", Pozicija.Docent, n1, "s", "red prof dr");
            UposlenikStalni u2 = new UposlenikStalni("Die", "Antwoord", new DateTime(1972, 11, 22), "2211972211444", Pozicija.Akademik, n2, "s", "red prof dr");

            Assert.IsFalse(u1.Norma - n1 < 0.0001); //test ce proci jer je u konstruktoru norma [0.5, 1.5] postavljena na minimum ukoliko je unesena manja vrijednost od 0.5
            Assert.IsTrue(u2.Norma - 1.5 <= 0.0001); //norma u konstruktoru postavljena na 1.5(max) ukoliko se unese veca vrijednost
        }

        [TestMethod]
        public void Test_Norma()
        {
            double n1 = 1; //pripada rangu [0.5, 1.5]
            UposlenikStalni u1 = new UposlenikStalni("Chet", "Baker", new DateTime(1972, 10, 21), "2110972211444", Pozicija.Docent, n1, "s", "red prof dr");

            Assert.IsTrue(u1.Norma - n1 <= 0.0001);
        }

    }
}