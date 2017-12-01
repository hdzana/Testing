using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;

namespace Zadatak3
{
    /// <summary>
    /// Summary description for TestStalniUposllenik
    /// </summary>
    [TestClass]
    public class TestStalniUposlenik
    {
        public TestStalniUposlenik()
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
        

        
        [TestMethod]
        public void TestAsistent()
        {
            double norma = 0.6;
            UposlenikStalni u = new UposlenikStalni("Louis", "Armstrong", new DateTime(1972, 10, 20), "2010972211444", Pozicija.Asistent, norma, "s", "red prof dr");

            double ocekivanaPlata = norma * 1100;

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);

        }


        [TestMethod]
        public void TestVisiAsistent()
        {
            double norma = 0.8;
            UposlenikStalni u = new UposlenikStalni("Louis", "Armstrong", new DateTime(1972, 10, 20), "2010972211444", Pozicija.VisiAsistent, norma, "s", "red prof dr");

            double ocekivanaPlata = norma * 1300;

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);
        }

        [TestMethod]
        public void TestDocent()
        {
            double norma = 1;
            UposlenikStalni u = new UposlenikStalni("Louis", "Armstrong", new DateTime(1972, 10, 20), "2010972211444", Pozicija.Docent, norma, "s", "red prof dr");

            double ocekivanaPlata = (norma + 0.1) * 1300;

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);
        }

        [TestMethod]
        public void TestRedovniProfesor()
        {
            double norma = 1.4;
            UposlenikStalni u = new UposlenikStalni("Louis", "Armstrong", new DateTime(1972, 10, 20), "2010972211444", Pozicija.RedovniProfesor, norma, "s", "red prof dr");

            double ocekivanaPlata = (norma + 0.3) *1500;

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);

        }

        [TestMethod]
        public void TestVandredniProfesor()
        {
            double norma = 1.3;
            UposlenikStalni u = new UposlenikStalni("Louis", "Armstrong", new DateTime(1972, 10, 20), "2010972211444", Pozicija.VandredniProfesor, norma, "s", "red prof dr");

            double ocekivanaPlata = (norma + 0.2) * 1300 + 150;

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);
        }

        [TestMethod]
        public void TestAkademik()
        {
            double norma = 1.5;
            UposlenikStalni u = new UposlenikStalni("Louis", "Armstrong", new DateTime(1972, 10, 20), "2010972211444", Pozicija.Akademik, norma, "s", "red prof dr");

            double ocekivanaPlata = (norma + 0.3) * 2000;

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);

        }
    }
}
