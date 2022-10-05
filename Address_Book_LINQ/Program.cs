using System;
using System.Data;

namespace Address_Book_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
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
            DataTable dataTable = TableOperations.InsertIntoDataTable(addressBook);
            TableOperations.Display(dataTable);
            TableOperations.DeleteaPerson(dataTable, "Gopi");
        }
    }
}
