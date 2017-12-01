using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak1;

namespace Zadatak4
{
    /// <summary>
    /// Summary description for TestData
    /// </summary>
    [TestClass]
    public class TestData
    {
        public TestData()
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

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void Test_UpisiStudentaCSV()
        {
            Fakultet fax = new Fakultet("ASU");

            DateTime d1 = new DateTime(
                Convert.ToInt32(TestContext.DataRow["Godina"]),
                 Convert.ToInt32(TestContext.DataRow["Mjesec"]),
                  Convert.ToInt32(TestContext.DataRow["Dan"]));

            DateTime d2 = new DateTime(
                Convert.ToInt32(TestContext.DataRow["GodinaZavrsetka"]),
                 Convert.ToInt32(TestContext.DataRow["MjesecZavrsetka"]),
                  Convert.ToInt32(TestContext.DataRow["DanZavrsetka"]));

            StudentBachelor s = new StudentBachelor(
                Convert.ToString(TestContext.DataRow["Ime"]),
                 Convert.ToString(TestContext.DataRow["Prezime"]), d1,
                  Convert.ToString(TestContext.DataRow["Maticni"]), d2
                 );

            fax.upisiStudenta(s);

            List<Student> studenti = fax.dajSveStudente();
            Assert.AreEqual(s, studenti[0]);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "podaci.xml", "student", DataAccessMethod.Sequential), DeploymentItem("podaci.xml")TestMethod]
        public void Test_UpisiStudentaXML()
        {
            Fakultet fax = new Fakultet("ASU");

            DateTime d1 = new DateTime(
                Convert.ToInt32(TestContext.DataRow["Godina"]),
                 Convert.ToInt32(TestContext.DataRow["Mjesec"]),
                  Convert.ToInt32(TestContext.DataRow["Dan"]));

            DateTime d2 = new DateTime(
                Convert.ToInt32(TestContext.DataRow["GodinaZ"]),
                 Convert.ToInt32(TestContext.DataRow["MjesecZ"]),
                  Convert.ToInt32(TestContext.DataRow["DanZ"]));

            StudentBachelor s = new StudentBachelor(
                Convert.ToString(TestContext.DataRow["Ime"]),
                 Convert.ToString(TestContext.DataRow["Prezime"]), d1,
                  Convert.ToString(TestContext.DataRow["Maticni"]), d2
                 );

            fax.upisiStudenta(s);

            List<Student> studenti = fax.dajSveStudente();
            Assert.AreEqual(s.MaticniBroj, studenti[0].MaticniBroj);
        }
    }
}
