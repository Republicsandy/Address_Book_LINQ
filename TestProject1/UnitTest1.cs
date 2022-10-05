using NUnit.Framework;
using Address_Book_LINQ;
using System.Data;
using System.Collections.Generic;

namespace TestProject1
{
    public class Tests
    {
        DataTable dataTable;
        [SetUp]
        public void Setup()
        {
            dataTable = GetDataTables.GetTable();
        }

        [Test]
        public void TestMethodForInsertion()
        {
            AddressBookModel addressBook = new AddressBookModel();
            addressBook.FirstName = "Gopi";
            addressBook.LastName = "S";
            addressBook.Address = "Lal Street";
            addressBook.City = "Bangalore";
            addressBook.State = "Karnataka";
            addressBook.ZipCode = "ZIP7451";
            addressBook.Phonenumber = 7410205065;
            addressBook.email = "Gopi@aceu.in";
            addressBook.contactId = 5;
            addressBook.addressbookname = "Technical";
            addressBook.addressBooktype = "Profession";
            DataTable actual = TableOperations.InsertIntoDataTable(addressBook);
            int expected = 5;
            System.Console.WriteLine(actual.Rows.Count);
            Assert.AreEqual(actual.Rows.Count, expected);
        }

        //Test method to check updation
        [Test]
        public void TestMethodForModfiyLastName()
        {
            string expected = "Success";
            string actual = TableOperations.ModifyLastName(dataTable, "Jhan", "Amir");
            Assert.AreEqual(expected, actual);
        }
        //Test method to check updation wrong name
        [Test]
        public void NegativeTestMethodForModfiyLastName()
        {
            string expected = "Failure";
            string actual = TableOperations.ModifyLastName(dataTable, "Jhan", "Al");
            Assert.AreEqual(expected, actual);
        }
        //TestMethod To Check Deletion of a row
        [Test]
        public void TestMethodForDeletion()
        {
            string expected = "Success";
            AddressBookModel addressBook = new AddressBookModel();
            addressBook.FirstName = "Gopi";
            addressBook.LastName = "S";
            addressBook.Address = "Lal Street";
            addressBook.City = "Bangalore";
            addressBook.State = "Karnataka";
            addressBook.ZipCode = "ZIP7451";
            addressBook.Phonenumber = 7410205065;
            addressBook.email = "Gopi@aceu.in";
            addressBook.contactId = 5;
            DataTable dataTable1 = TableOperations.InsertIntoDataTable(addressBook);
            string actual = TableOperations.DeleteaPerson(dataTable1, "Gopi");
            Assert.AreEqual(expected, actual);
        }
        //Test method to check updation wrong name
        [Test]
        public void NegativeTestMethodForDeletion()
        {
            string expected = "Failure";
            AddressBookModel addressBook = new AddressBookModel();
            addressBook.FirstName = "Gopi";
            addressBook.LastName = "S";
            addressBook.Address = "Lal Street";
            addressBook.City = "Bangalore";
            addressBook.State = "Karnataka";
            addressBook.ZipCode = "ZIP7451";
            addressBook.Phonenumber = 7410205065;
            addressBook.email = "Gopi@aceu.in";
            addressBook.contactId = 5;
            DataTable dataTable1 = TableOperations.InsertIntoDataTable(addressBook);
            string actual = TableOperations.DeleteaPerson(dataTable1, "Gopio");
            Assert.AreEqual(expected, actual);
        }
        //retrieve based on city name is checked
        [Test]
        public void TestMethodToCheckRetrievalBasedOnCityName()
        {
            List<string> actual = TableOperations.RetrieveDataBasedOnCityName(dataTable, "Chennai");
            string[] temp = { "Dhanush Raj", "Amir Khan" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        //Test method to check retrieval count based on city and state name
        [Test]
        public void TestMethodToRetrieveCountBasedOnCityAndStateName()
        {
            List<string> actual = TableOperations.RetrieveCountBasedOnCityAndStateName(dataTable);
            string[] temp = { "Chennai TamilNadu 2", "Mumbai Maharastra 1", "Delhi Delhi 1" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        //Test method to sort based on name and for given city
        [Test]
        public void TestMethodToSortFirstNameBasedOnCity()
        {
            List<string> actual = TableOperations.SortName(dataTable, "Chennai");
            string[] temp = { "Amir Khan", "Dhanush Raj" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        //Test method to check for count based on type
        [Test]
        public void TestMethodToCountBasedOnType()
        {
            List<string> actual = TableOperations.CountByType(dataTable);
            string[] temp = { "Family 2", "Profession 1", "Friend 1" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        //After ER
        [Test]
        public void TestMethodToCheckRetrievalBasedOnCityNameAfterER()
        {
            List<string> actual = TableOperations.RetrieveDataBasedOnCityNameAfterER("Chennai");
            string[] temp = { "1 Dhanush", "1 Dhanush", "2 Amir" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        [Test]
        public void TestMethodToRetrieveCountBasedOnCityAndStateNameAfterER()
        {
            List<string> actual = TableOperations.RetrieveCountBasedOnCityAndStateNameAfterER();
            string[] temp = { "Chennai TamilNadu 2", "Mumbai Maharastra 1", "Delhi Delhi 1" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        [Test]
        public void TestMethodToSortFirstNameBasedOnCityAfterER()
        {
            List<string> actual = TableOperations.SortNameAfterER("Chennai");
            string[] temp = { "Amir Khan", "Dhanush Raj" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        //Test method to check for count based on type After ER
        [Test]
        public void TestMethodToCountBasedOnTypeAfterER()
        {
            List<string> actual = TableOperations.CountByTypeAfterER();
            string[] temp = { "Family 2", "Friends 2", "Profession 1" };
            var expected = new List<string>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }

    }
}