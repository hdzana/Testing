using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;

namespace Zadatak2
{
    /// <summary>
    /// Summary description for TestFakultet
    /// </summary>
    [TestClass]
    public class TestFakultet
    {

        Fakultet fax;
        public TestFakultet()
        {
            fax = new Fakultet("ASU");
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

       
         //provjera da se kreiraju jedistveni indeksi
        //Assert AllItemsAreUnique 

        [TestMethod]
        public void Test_Index()
        {
            Fakultet etf = new Fakultet("ETF");
            StudentBachelor s1 = new StudentBachelor("Dzana", "Hanic", new DateTime(1995, 12, 27), "2712995177657", new DateTime(2014, 10, 10));
            StudentBachelor s2 = new StudentBachelor("Ema", "Jukic", new DateTime(1995, 09, 28), "2809995177170", new DateTime(2014, 10, 10));
            etf.upisiStudenta(s1);
            etf.upisiStudenta(s2);
            List<String> indeksi = etf.dajSveIndekse();

            CollectionAssert.AllItemsAreUnique(indeksi);

        }

        //provjera da se kreiraju studenti master koji nisu null
        

        //provjera fonda

        [TestMethod]
        public void Test_ProvjeraFonda()
        {
            //norma = 1.5
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 1.5, "s", "prof dr");
            StudentBachelor s1 = new StudentBachelor("Niko", "Nikic", new DateTime(1995, 12, 27), "2712995111222", new DateTime(2014, 10, 10));

            fax.dodajUposlenika(u1);
            fax.upisiStudenta(s1);

            Assert.IsFalse(fax.isplatiIzFonda(u1.Plata)); //nece se isplatiti iz fonda jer je plata profesora veca od trenutnog stanja

        }


        //ispravna isplata iz fonda
        [TestMethod]
        public void Test_IsplatiIzFonda()
        {
            //norma = 0.5
            UposlenikStalni u1 = new UposlenikStalni("Novica", "Nosovic", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, 0.5, "s", "prof dr");
            StudentBachelor s1 = new StudentBachelor("Niko", "Nikic", new DateTime(1995, 12, 27), "2712995111222", new DateTime(2014, 10, 10));

            fax.dodajUposlenika(u1);
            fax.upisiStudenta(s1);

            Assert.IsTrue(fax.isplatiIzFonda(u1.Plata));
        }
        //provjera da se ispravno kreira ime fakuleta

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_ProvjeraNaziva()
        {
            Fakultet f = new Fakultet("ETF//");

            f.dajSveIndekse();
            f.dajSveStudente();
            f.dajSveUposlenike();

            //ocekivano je padanje testa jer ime sadrzi '//'
        }

        [TestMethod]
        public void Test_KreirajFakultet()
        {
            Fakultet f = new Fakultet("ETF");
            Assert.IsTrue(f.dajSveStudente().Count == 0);
        }


    }
}
