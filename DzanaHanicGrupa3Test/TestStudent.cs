using Zadatak1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Zadatak2
{

    [TestClass]
    public class TestStudent
    {
        Fakultet fax;
        public TestStudent()
        {
            fax = new Fakultet("ETF");
        }

        private TestContext testContextInstance;

      
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


        //JMB TESTOVI

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_JMB_13()
        {
            StudentBachelor student1 = new StudentBachelor("Dzana", "Hanic", new DateTime(1995, 12, 27), "2712995111222", new DateTime(2014, 10, 10));
            student1.validirajMaticni("271299511122"); //test nece pasti jer maticni ne sadrzi 13 cifri (ocekuje se exception)
        }


        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Test_JMB_Sadrzaj()
        {
            StudentBachelor student1 = new StudentBachelor("Dzana", "Hanic", new DateTime(1995, 12, 27), "2712995111222", new DateTime(2014, 10, 10));
            student1.validirajMaticni("0712995111222");  //test nece pasti jer maticni nije ispravan (datum je 27) - ocekuje se exception
        }


        [TestMethod]
        public void Test_JMB()
        {
            StudentBachelor student1 = new StudentBachelor("Dzana", "Hanic", new DateTime(1995, 12, 27), "2712995111222", new DateTime(2014, 10, 10));
            fax.upisiStudenta(student1);
            student1.validirajMaticni("2712995177657"); //test nece pasti jer je maticni ispravan

        }


        //INDEKS TEST
        //pri svakom dodavanju novog studenta provjeravat cu da li vec postoji indeks koji je identican novom upisanom


        //test koji testira ispravnost indeksa kreiranog na masteru xxx/indeks_bachelor
        //Assert - AreEqual

        [TestMethod]
        public void Test_IspravanIndeks()
        {

            StudentBachelor s1 = new StudentBachelor("Dzana", "Hanic", new DateTime(1995, 12, 27), "2712995177657", new DateTime(2014, 10, 10));
            String iB = s1.BrojIndeks;
            StudentMaster s2 = new StudentMaster("Dzana", "Hanic", new DateTime(1995, 12, 27), "2712995177657", new DateTime(2017, 10, 10));
            String iM = s2.BrojIndeks;

            fax.upisiStudenta(s1);
            fax.upisiStudenta(s2);

            Assert.AreEqual(iB, iM.Substring(4, 6)); 
        }


        //test metoda u kojoj provjeravam da li se od indeksa koji su trenutno generisani kod bachelor studenata
        //pojavljuje isti indeks kao i kod master studenta sa drugog fakulteta

        [TestMethod]
        public void Test_JedinstvenIndeksMaster()
        {
            StudentMaster sM = new StudentMaster("Janis", "Joplin", new DateTime(1995, 12, 27), "2712995177657", DateTime.Now, "PFSA");

            fax.upisiMasterDrugiFaks(sM);

            List<String> indeksi = fax.dajSveIndekse();
            String iM = sM.BrojIndeks.Substring(4, 6);
            CollectionAssert.DoesNotContain(indeksi, iM); //test ne bi trebao pasti
           
        }

        //ispravan format indeksa studenta master studija
        //StringAssert - Matches

        [TestMethod]
        public void Test_FormatIndexMaster()
        {
            StudentMaster s = new StudentMaster("Janis", "Joplin", new DateTime(1995, 12, 27), "2712995177657", DateTime.Now, "PFSA");
            Regex r = new Regex(@"^[0-9]{3}/[0-9]{6}");
           
            StringAssert.Matches(s.BrojIndeks, r);
        }

        //ispravan format indeksa studenta bachelor studija
        //StringAssert - Matches
        [TestMethod]
        public void Test_FormatIndexBachelor()
        {
            StudentBachelor s = new StudentBachelor("Niko", "Nikic", new DateTime(1995, 12, 27), "2712995177657", new DateTime(2014, 10, 10));
            Regex r = new Regex(@"^[0-9]{6}");

            StringAssert.Matches(s.BrojIndeks, r);
        }

        //test metoda u kojoj provjeravam da li je lista dosadasnjih indeksa jedinstvena
        //CollectionAssert - AllItemsAreUnique

        [TestMethod]
        public void Test_JedinstvenIndeks()
        {
            List<String> indeksi = fax.dajSveIndekse();

            CollectionAssert.AllItemsAreUnique(indeksi); //test nece pasti jer svi indeksi trebaju biti jedinstveni
        }



        //CollectionAssert - AllItemsAreInstancesOfType

        [TestMethod]
        public void Test_Kolekcija()
        {

           fax.upisiBachelor("Ema", "Jukic", new DateTime(1993, 11, 20), "2011993180008", new DateTime(2014, 10, 10));
           fax.upisiMaster("Lejla", "Zecevic", new DateTime(1995, 12, 27), "2712995177657", new DateTime(2011, 10, 10));

            CollectionAssert.AllItemsAreInstancesOfType(fax.dajSveStudente(), typeof(Student));

        }


        //testiranje da se fond povecava upisom novih studenata
        //Assert - IsFalse

        [TestMethod]
        public void Test_Fond()
        {

            fax.upisiBachelor("Norah", "Jones", new DateTime(1995, 09, 28), "2809995177170", new DateTime(2014, 10, 10));
            fax.upisiMaster("Amy", "Winehouse", new DateTime(1995, 12, 27), "2712995177657", new DateTime(2011, 10, 10));

            Assert.IsFalse(fax.fondFlag()); //test nece pasti jer se flag za prazan fond postavlja na false ukoliko je student uspjesno kreiran

        }


        //testiranje ispravnosti unesenih podataka

       [TestMethod]
       [ExpectedException(typeof(System.ArgumentException))]
        public void Test_Podaci()
        {
            StudentMaster sM = new StudentMaster("Janis*1", "/1Joplin", new DateTime(1995, 12, 27), "2712995177657", DateTime.Now, "PFSA");
            StudentBachelor sB = new StudentBachelor("Norah", "Jones321", new DateTime(1995, 12, 27), "2712995177657", new DateTime(2014, 10, 10));

            //ocekivano je padanje jer format imena i prezimena nije tacan
        }














    }
}
