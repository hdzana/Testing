using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;

namespace Zadatak3
{
    /// <summary>
    /// Summary description for TestPrivremeniUposlenik
    /// </summary>
    [TestClass]
    public class TestPrivremeniUposlenik
    {
        public TestPrivremeniUposlenik()
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
        

        //broj casova = 0

        [TestMethod]
        public void Test_0Casova()
        {
            UposlenikPrivremeni u = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.StrucnjakIzPrakse, DateTime.Now, new DateTime(2017, 10, 10), 0);
            UposlenikPrivremeni u1 = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.Demonstrator, DateTime.Now, new DateTime(2017, 10, 10), 0);
            UposlenikPrivremeni u2 = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.GostujuciPredavac, DateTime.Now, new DateTime(2017, 10, 10), 0);

            Assert.IsTrue(u.Plata <= 0.0001);
            Assert.IsTrue(u1.Plata <= 0.0001);
            Assert.IsTrue(u2.Plata - 150  <= 0.0001);
        }

        //testiranje plate demonstratora

        [TestMethod]
        public void Test_Demonstrator()
        {
            
            int brCasova = 5;
            DateTime d1 = DateTime.Now;
            DateTime d2 = new DateTime(2017, 10, 10);
            double trajanje = (d2 - d1).TotalDays;
            double ocekivanaPlata = brCasova * 10 * trajanje;

            UposlenikPrivremeni u = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.Demonstrator, d1, d2, brCasova);

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);
        }

        [TestMethod]
        public void Test_StrucnjakIzPrakse()
        {
            int brCasova = 3;
            DateTime d1 = DateTime.Now;
            DateTime d2 = new DateTime(2017, 10, 10);
            double trajanje = (d2 - d1).TotalDays;
            double ocekivanaPlata = brCasova * 15 * trajanje;

            UposlenikPrivremeni u = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.StrucnjakIzPrakse, d1, d2, brCasova);

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);
        }

        [TestMethod]
        public void Test_GostujuciPredavac()
        {
            int brCasova = 5;
            DateTime d1 = DateTime.Now;
            DateTime d2 = new DateTime(2017, 10, 10);

            double ocekivanaPlata = brCasova * 20 + 150;

            UposlenikPrivremeni u = new UposlenikPrivremeni("Joan", "Dylan", new DateTime(1976, 10, 20), "2010976111444", Pozicija.GostujuciPredavac, d1, d2, brCasova);

            double razlika = Math.Abs(ocekivanaPlata - u.Plata);
            Assert.IsTrue(razlika <= 0.0001);
        }



    }
}
