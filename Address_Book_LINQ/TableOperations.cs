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
    }
}
