using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;

namespace Zadatak5
{
    /// <summary>
    /// Summary description for MockTest
    /// </summary>
    [TestClass]
    public class TestMock
    {
        IPredmetVandredni vandredni;
        Predmet predmet;
       
        public TestMock()
        {
            //
            // TODO: Add constructor logic here
            //
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

        [TestInitialize]
        public void Inicijalizacija_MockTest()
        {
            vandredni = new MockPredmet();
            predmet = new Predmet(vandredni);
           
        }

        [TestMethod]
        public void Test_EctsSeminarski()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet tp = new Predmet("TP", "Tehnike programiranja", "Bachelor", 14, 7, 100, 8, uposleni, "Programiranje for life");

            double vrijednost = tp.BrojECTS * 0.3;
            Assert.IsTrue((vrijednost - predmet._mockPredmet.seminarskiECTS(8)) <= 0.001 );
        }


        [TestMethod]
        public void Test_EctsProjekat()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet tp = new Predmet("TP", "Tehnike programiranja", "Bachelor", 14, 7, 100, 8, uposleni, "Programiranje for life");

            double vrijednost = tp.BrojECTS * 0.5;
            Assert.IsTrue((vrijednost - predmet._mockPredmet.projekatECTS(8)) <= 0.001);
        }


        [TestMethod]
        public void Test_EctsZadace()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet tp = new Predmet("TP", "Tehnike programiranja", "Bachelor", 14, 7, 100, 8, uposleni, "Programiranje for life");

            double vrijednost = tp.BrojECTS * 0.15;
            Assert.IsTrue((vrijednost - predmet._mockPredmet.zadaceECTS(8)) <= 0.001);
        }


        [TestMethod]
        public void Test_EctsIspiti()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet tp = new Predmet("TP", "Tehnike programiranja", "Bachelor", 14, 7, 100, 8, uposleni, "Programiranje for life");

            double vrijednost = tp.BrojECTS * 0.9;
            Assert.IsTrue((vrijednost - predmet._mockPredmet.ispitiECTS(8)) <= 0.001);
        }


        [TestMethod]
        public void Test_generalneInformacije()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet tp = new Predmet("TP", "Tehnike programiranja", "Bachelor", 14, 7, 100, 8, uposleni, "Test");

            StringAssert.Equals(tp.NazivPredmeta + " " + tp.OpisPredmeta, predmet._mockPredmet.dajGeneralneInformacije("Tehnike programiranja", "Test"));

        }

        [TestMethod]
        public void Test_ECTSuSate()
        {
            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet vvs = new Predmet("VVS", "Verifikacija i validacija softvera", "Bachelor", 14, 7, 100, 5, uposleni, "Test");

            double sati = vvs.BrojECTS * 25;
            Assert.IsTrue((sati - predmet._mockPredmet.dajECTSuSate(vvs.BrojECTS)) <= 0.001);

        }


        [TestMethod]
        public void Test_NastavniAnsambl()
        {

            List<Uposlenik> uposleni = new List<Uposlenik>();
            UposlenikStalni u1 = new UposlenikStalni("Zeljko", "Juric", new DateTime(1972, 10, 20), "2010972111444", Pozicija.RedovniProfesor, 1, "s", "prof dr");
            uposleni.Add(u1);
            Predmet vvs = new Predmet("VVS", "Verifikacija i validacija softvera", "Bachelor", 14, 7, 100, 5, uposleni, "Test");

            Assert.AreEqual(uposleni.Count, predmet._mockPredmet.dajNastavniAnsambl(uposleni).Count);
        }




    }
}
