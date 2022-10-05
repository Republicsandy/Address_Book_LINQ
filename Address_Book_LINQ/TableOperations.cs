using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_LINQ
{
    public class TableOperations
    {
        //Inserts into table
        public static DataTable InsertIntoDataTable(AddressBookModel addressBookModel)
        {
            DataTable dataTable = GetDataTables.GetTable();
            dataTable.Rows.Add(addressBookModel.contactId, addressBookModel.FirstName, addressBookModel.LastName, addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.ZipCode, addressBookModel.Phonenumber, addressBookModel.email, addressBookModel.addressbookname, addressBookModel.addressBooktype);
            return dataTable;
        }
        //modifies last name
        public static string ModifyLastName(DataTable dataTable, string LastName, string search)
        {
            //retrieve the data row as a result
            var member = (from contacts in dataTable.AsEnumerable() where contacts.Field<string>("FirstName") == search select contacts).FirstOrDefault();
            if (member != null)
            {
                //data in column modified
                member["LastName"] = LastName;
                Console.WriteLine("After Updation");
                Display(dataTable);
                return "Success";
            }
            return "Failure";

        }
        public static void Display(DataTable dataTable)
        {
            foreach (DataRow rows in dataTable.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", rows["ContactId"], rows["FirstName"], rows["LastName"], rows["Address"], rows["City"], rows["State"], rows["ZipCode"], rows["PhoneNumber"], rows["Email"]);
            }


        }

    }
}
