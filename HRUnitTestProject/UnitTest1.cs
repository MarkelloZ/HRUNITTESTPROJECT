
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRDLL.HRDLL;

namespace HRUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        const string msg1 = "Το ονομα που δωσατε δεν πρεπει να περιέχει σύμβολα.";


        [TestMethod]
        public void TestValidName()
        {
            HRDLL.HRDLL b = new HRDLL.HRDLL();
            object[,] testcases =
            {
                { 1, "Kyriakos Marios Markellos", true, "msg1"},
                { 2, "Mar.ios Nikolao?s Lamprou!", false, "msg1"},
             };

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    bool expectedResult = (bool)testcases[i, 2];
                    bool actualResult = b.ValidName((string)testcases[i, 1]);
                    Assert.AreEqual(expectedResult, actualResult);
                }
                catch (Exception e)
                {
                    // Απέτυχε η περίπτωση ελέγχου
                    Assert.Fail($"Failed Test Case: {testcases[i, 0]}: {(string)testcases[i, 1]} - {(bool)testcases[i, 2]} - {(string)testcases[i, 3]}. \n \t Reason: {e.Message}");
                }
            }
        }

        const string msg = "pass";
        const string msg3 = "Μη έγκυρος κωδικός επειδή δεν έχει τουλάχιστον 12 ψηφία";
        const string msg4 = "Μη έγκυρος κωδικός επειδή δεν έχει κεφαλαίο γράμμα στην αρχή";
        const string msg5 = "Μη έγκυρος κωδικός επειδή δεν τελειώνει με αριθμό";
        const string msg6 = "Μη έγκυρος κωδικός επειδή δεν περιέχει σύμβολο";
        const string msg7 = "Μη έγκυρος κωδικός επειδή δεν περιέχει πεζούς χαρακτήρες";
        const string msg8 = "Μη έγκυρος κωδικός επειδή δεν περιέχει κεφαλαίους χαρακτήρες";
        const string msg9 = "Μη έγκυρος κωδικός επειδή περιέχει μόνο αριθμούς και όχι σύμβολα";



        [TestMethod]
        public void TestValidPassword()
        {
            HRDLL.HRDLL b = new HRDLL.HRDLL();

            object[,] testcases =
            {
        { 1, "ValidPassword!1", true, msg},//DEN EXEI 12 PSIFIA//
        { 2, "Pass123$", false, msg3},// Μη έγκυρος κωδικός επειδή δεν έχει τουλάχιστον 12 ψηφία
        { 3, "password123$A", false, msg4},// Μη έγκυρος κωδικός επειδή δεν έχει κεφαλαίο γράμμα στην αρχή
        { 4, "Password$A", false, msg5},// Μη έγκυρος κωδικός επειδή δεν τελειώνει με αριθμό
        { 5, "Password123A", false, msg6},// Μη έγκυρος κωδικός επειδή δεν περιέχει σύμβολο
        { 6, "PASSWORD123$A", false, msg7},// Μη έγκυρος κωδικός επειδή δεν περιέχει πεζούς χαρακτήρες
        { 7, "password123$a", false, msg8},// Μη έγκυρος κωδικός επειδή δεν περιέχει κεφαλαίους χαρακτήρες
        { 8, "123456789012", false, msg9},// Μη έγκυρος κωδικός επειδή περιέχει μόνο αριθμούς και όχι σύμβολα

    };

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    bool expectedResult = (bool)testcases[i, 2];
                    bool actualResult = b.ValidPassword((string)testcases[i, 1]);
                    Assert.AreEqual(expectedResult, actualResult);
                }
                catch (Exception e)
                {
                    // Απέτυχε η περίπτωση ελέγχου
                    Assert.Fail($"Failed Test Case: {testcases[i, 0]}: {(string)testcases[i, 1]} - {(bool)testcases[i, 2]} - {(string)testcases[i, 3]}. \n \t Reason: {e.Message}");
                }
            }
        }

        [TestMethod]
        public void TestEncryptedPassword()
        {
            HRDLL.HRDLL b = new HRDLL.HRDLL();

            object[,] testcases =
            {
                {1, "kyriakosmarkellospas123", "pdwnfptxrfwpjqqtxufx123"},
                {2, "0123456789AaBbAaCc!", "0123456789FfGgFfHh!"},
                {3, "0987654321Aa!", "5432109876Ff!"}
            };

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    string encryptedPW = "";
                    b.EncryptPassword((string)testcases[i, 1], ref encryptedPW);
                    Assert.AreEqual((string)testcases[i, 2], encryptedPW);
                }
                catch (Exception)
                {
                    Assert.Fail($"Failed Test Case: {testcases[i, 0]}: {(string)testcases[i, 1]} - {(string)testcases[i, 2]}. \n\tReason: Wrong Encryption Matching");
                }
            }
        }



        Employee[] emp = new Employee[]
        {
            new Employee("Kyriakos Marios Markellos", "2141033440", "6948762308", new DateTime(2002,11,13), new DateTime(2022,10,15)),

            new Employee("Marios Nikoalos Lamprou", "21410345333", "6903452309", new DateTime(2002,6,16), new DateTime(2022,11,3)),

            new Employee("Fwtios Giannounakos", "27410345243", "6903452309", new DateTime(2002,3,6), new DateTime(2022,10,13)),

            new Employee("Tasos Mpitsigkounias", "21039390832", "6974230947", new DateTime(1990,3,15), new DateTime(2020,12,3)),

            new Employee("Anastasios Amparizas", "2310338397", "69082304591",new DateTime(2002,4,23), new DateTime(2020,6,23))
        };

        [TestMethod]
        public void TestCheckPhone()
        {
            HRDLL.HRDLL d = new HRDLL.HRDLL();

            object[,] testcases =
            {
                {1, "2103345237", 1, "Athens"},
                {2, "2234567890", 0, "Central Greece and the Aegean Islands"},
                {3, "2345678901", 0, "Central Macedonia and Florina"},
                {4, "2456789012", 0, "Thessaly and West Macedonia"},
                {5, "2567890123", 0, "East Macedonia and Thrace"},
                {6, "2678901234", 0, "West Greece, Ionian Island and Epirus"},
                {7, "2741034337", 0, "Peloponnese and Kythera"},
                {8, "2890123456", 0, "Crete"},
                {9, "6972032448", 0, "Cosmote"},
                {10, "6984523099", 1, "Cosmote"},
                {11, "6945784809", 1, "Vodafone"},
                {12, "6955742307", 1, "Vodafone"},
                {13, "6902846039", 1, "Nova"},
                {14, "6933132305", 1, "Nova"}
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    int TypePhone = -1;
                    string InfoPhone = "";

                    d.CheckPhone((string)testcases[i, 1], ref TypePhone, ref InfoPhone);

                    Assert.AreEqual((int)testcases[i, 2], TypePhone);
                    Assert.AreEqual((string)testcases[i, 3], InfoPhone);
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine("Failed Test Case: {0}: {1} - {2} - {3}. \n \t Reason: {4} ",
                                        (int)testcases[i, 0], (string)testcases[i, 1], (int)testcases[i, 2], (string)testcases[i, 3], e.Message);
                }
            }

            if (failed) Assert.Fail();
        }



        [TestMethod]
        public void TestInfoEmployee()
        {

            HRDLL.HRDLL e = new HRDLL.HRDLL();

            // Define test cases
            object[,] testcases =
            {
            {1, emp[0], 21, 1},
            {2, emp[1], 21, 1},
            {3, emp[2], 21, 1},
            {4, emp[3], 33, 2},
            {5, emp[4], 22, 3},
            };

            bool failed = false;

            for (int i = 0; i < testcases.GetLength(0); i++)
            {
                try
                {
                    int Age = -1;
                    int YearsOfExperience = -1;

                    e.InfoEmployee((Employee)testcases[i, 1], ref Age, ref YearsOfExperience);

                    Assert.AreEqual(testcases[i, 2], Age);
                    Assert.AreEqual(testcases[i, 3], YearsOfExperience);
                }
                catch (AssertFailedException ex)
                {
                    failed = true;
                    Console.WriteLine($"Failed Test Case: {(int)testcases[i, 0]}. Reason: {ex.Message}");
                }
            }

            if (failed) Assert.Fail("One or more test cases failed.");
        }

        [TestMethod]
        public void TestLiveInAthens()
        {
            HRDLL.HRDLL e = new HRDLL.HRDLL();
            bool failed = false;

                try
                {
                    Assert.AreEqual(3, e.LiveInAthens(emp));
                }
                catch (AssertFailedException ex)
                {
                    failed = true;
                Console.WriteLine($"Failed Test Case: . Reason: {ex.Message}");
                }
           
            if (failed) Assert.Fail("One or more test cases failed.");

        }

    }

}
