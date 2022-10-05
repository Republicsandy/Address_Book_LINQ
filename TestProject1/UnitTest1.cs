using NUnit.Framework;
using Address_Book_LINQ;
using System.Data;
using System.Collections.Generic;

namespace TestProject1
{
    public class Tests
    {
        DataTable dataTable;

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

    }
}