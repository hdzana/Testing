using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;

namespace Zadatak5
{
    /// <summary>
    /// Summary description for TestStub
    /// </summary>
    [TestClass]
    public class TestStub
    {
        Predmet predmet;
        public TestStub()
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
        public void PripremaPodataka_StubTest()
        {
            predmet = new Predmet(new StubPredmet());
        }


        [TestMethod]
        public void Test_NastavniAnsabl()
        {
            CollectionAssert.AllItemsAreNotNull(predmet.dajNastavniAnsambl(new List<Uposlenik>()));
           
            
        }

        [TestMethod]
        public void Test_OpisPredmeta()
        {
            string naziv = "Verifikacija i validacija softvera";
            string opis = "Test";
            StringAssert.Equals(predmet.generalneInformacije(naziv, opis), "Verifikacija i validacija softvera Test");
        }

        [TestMethod]
        public void Test_ECTS()
        {
            double sati = predmet.ECTSuSate(5);
            Assert.AreEqual(5.3, sati);

        }



    }
}
