using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_LINQ
{

    public class GetDataTables
    {
        public static DataTable GetTable()
        {
            DataTable addressbook = new DataTable();
            //Add columns
            addressbook.Columns.Add("ContactId", typeof(int));
            addressbook.Columns.Add("FirstName", typeof(string));
            addressbook.Columns.Add("LastName", typeof(string));
            addressbook.Columns.Add("Address", typeof(string));
            addressbook.Columns.Add("City", typeof(string));
            addressbook.Columns.Add("State", typeof(string));
            addressbook.Columns.Add("ZipCode", typeof(string));
            addressbook.Columns.Add("PhoneNumber", typeof(long));
            addressbook.Columns.Add("Email", typeof(string));
            addressbook.Columns.Add("AddressBookName", typeof(string));
            addressbook.Columns.Add("AddressBookType", typeof(string));
            //add rows
            addressbook.Rows.Add(1, "Dhanush", "Raj", "Egmore", "Chennai", "TamilNadu", "600009", 7874157898, "amir.khan@gmail.com", "Home", "Family");
            addressbook.Rows.Add(2, "Amir", "Khan", "Nungambakam", "Chennai", "TamilNadu", "600077", 7102354045, "Dhanush.raj@gmail.com", "Manager", "Profession");
            addressbook.Rows.Add(3, "Ajay", "Kumar", "Menod", "Mumbai", "Maharastra", "ZIP5864", 6145784515, "Kumar@gmail.com", "Neighbour", "Friend");
            addressbook.Rows.Add(4, "Ram", "Jai", "XXXX", "Delhi", "Delhi", "XXXXXX", 6410203045, "Ram.jai@gmail.com", "Home", "Family");
            return addressbook;
        }
        //After ER
        public static DataTable GetContactTable()
        {
            DataTable contacts = new DataTable();
            //Add columns
            contacts.Columns.Add("ContactId", typeof(int));
            contacts.Columns.Add("FirstName", typeof(string));
            contacts.Columns.Add("LastName", typeof(string));
            contacts.Columns.Add("Address", typeof(string));
            contacts.Columns.Add("City", typeof(string));
            contacts.Columns.Add("State", typeof(string));
            contacts.Columns.Add("ZipCode", typeof(string));
            contacts.Columns.Add("PhoneNumber", typeof(long));
            contacts.Columns.Add("Email", typeof(string));
            contacts.Columns.Add("AddressBookName", typeof(string));

            //add rows
            contacts.Rows.Add(1, "Dhanush", "Raj", "Egmore", "Chennai", "TamilNadu", "600009", 7874157898, "Dhanush.raj@gmail.com", "Home");
            contacts.Rows.Add(2, "Amir", "Khan", "Nungambakam", "Chennai", "TamilNadu", "600077", 7102354045, "amir.khan@gmail.com", "Manager");
            contacts.Rows.Add(3, "Ajay", "Kumar", "Menod", "Mumbai", "Maharastra", "ZIP5864", 6145784515, "Kumar@gmail.com", "Neighbour");
            contacts.Rows.Add(4, "Ram", "Jai", "XXXX", "Delhi", "Delhi", "XXXXXX", 6410203045, "Ram.jai@gmail.com", "Home");
            return contacts;
        }
        public static DataTable GetAddressBookTypeTable()
        {
            DataTable addressBookType = new DataTable();
            //Add columns
            addressBookType.Columns.Add("typeId", typeof(int));
            addressBookType.Columns.Add("Type", typeof(string));
            addressBookType.Rows.Add(1, "Family");
            addressBookType.Rows.Add(2, "Friends");
            addressBookType.Rows.Add(3, "Profession");

            return addressBookType;
        }
        public static DataTable GetContact_map_typeTable()
        {
            DataTable contact_map_type = new DataTable();
            //Add columns
            contact_map_type.Columns.Add("typeId", typeof(int));
            contact_map_type.Columns.Add("contactId", typeof(int));
            contact_map_type.Rows.Add(1, 1);
            contact_map_type.Rows.Add(2, 3);
            contact_map_type.Rows.Add(3, 2);
            contact_map_type.Rows.Add(1, 4);
            contact_map_type.Rows.Add(2, 1);
            return contact_map_type;

        }
    }
}
