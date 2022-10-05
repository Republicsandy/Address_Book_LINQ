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
        //Delete the row of given name
        public static string DeleteaPerson(DataTable dataTable, string search)
        {
            var member = (from contacts in dataTable.AsEnumerable() where contacts.Field<string>("FirstName") == search select contacts).FirstOrDefault();

            if (member != null)
            {
                //deletes the column
                member.Delete();
                Console.WriteLine("After Updation");
                Display(dataTable);
                return "Success";
            }
            return "Failure";

        }
        //Retrieve based on city name
        public static List<string> RetrieveDataBasedOnCityName(DataTable dataTable, string cityname)
        {
            var member = from contacts in dataTable.AsEnumerable() where contacts.Field<string>("City") == cityname select contacts;
            List<string> result = new List<string>();
            foreach (var mem in member)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", mem["ContactId"], mem["FirstName"], mem["LastName"], mem["Address"], mem["City"], mem["State"], mem["ZipCode"], mem["PhoneNumber"], mem["Email"]);
                result.Add(mem["FirstName"] + " " + mem["LastName"]);
            }
            return result;
        }
        //Group by based on city and state name and returns the count with list
        public static List<string> RetrieveCountBasedOnCityAndStateName(DataTable dataTable)
        {
            //group by city and state name
            var member = from contacts in dataTable.AsEnumerable() group contacts by new { City = contacts.Field<string>("City"), State = contacts.Field<string>("State") } into temp select new { City = temp.Key.City, State = temp.Key.State, count = temp.Count() };
            List<string> result = new List<string>();
            foreach (var mem in member)
            {
                Console.WriteLine(mem.City + " " + mem.State + " " + mem.count);
                result.Add(mem.City + " " + mem.State + " " + mem.count);

            }
            return result;
        }
        //sorts based on names
        public static List<string> SortName(DataTable dataTable, string city)
        {
            var member = from contacts in dataTable.AsEnumerable() orderby contacts.Field<string>("FirstName") where contacts.Field<string>("City") == city select contacts;
            List<string> result = new List<string>();
            foreach (var mem in member)
            {

                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", mem["ContactId"], mem["FirstName"], mem["LastName"], mem["Address"], mem["City"], mem["State"], mem["ZipCode"], mem["PhoneNumber"], mem["Email"]);
                result.Add(mem["FirstName"] + " " + mem["LastName"]);
            }
            return result;
        }
        //count based on address book type
        public static List<string> CountByType(DataTable dataTable)
        {
            List<string> result = new List<string>();
            var member = from contacts in dataTable.AsEnumerable() group contacts by contacts.Field<string>("AddressBookType") into temp select new { Type = temp.Key, count = temp.Count() };
            foreach (var mem in member)
            {
                Console.WriteLine(mem.Type + " " + mem.count);
                result.Add(mem.Type + " " + mem.count);
            }
            return result;

        }
        public static void Display(DataTable dataTable)
        {
            foreach (DataRow rows in dataTable.Rows)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10}", rows["ContactId"], rows["FirstName"], rows["LastName"], rows["Address"], rows["City"], rows["State"], rows["ZipCode"], rows["PhoneNumber"], rows["Email"], rows["AddressBookName"], rows["AddressBookType"]);
            }

        }
        ///After ER
        ///using join
        public static List<string> RetrieveDataBasedOnCityNameAfterER(string city)
        {
            DataTable contact_list = GetDataTables.GetContactTable();
            DataTable addressBookType = GetDataTables.GetAddressBookTypeTable();
            DataTable contact_map_type = GetDataTables.GetContact_map_typeTable();
            List<string> result = new List<string>();
            var member = from contacts in contact_list.AsEnumerable()
                         join contactmaptype in contact_map_type.AsEnumerable()
                         on contacts.Field<int>("ContactId") equals contactmaptype.Field<int>("contactId")
                         join addressbooktype in addressBookType.AsEnumerable()
                         on contactmaptype.Field<int>("typeId") equals addressbooktype.Field<int>("typeId")
                         where contacts.Field<string>("City") == city
                         select new { contacts, Type = addressbooktype.Field<string>("Type") };
            foreach (var mem in member)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10}",
                    mem.contacts.Field<int>("ContactId"), mem.contacts.Field<string>("FirstName")
                    , mem.contacts.Field<string>("LastName"), mem.contacts.Field<string>("Address"),
                    mem.contacts.Field<string>("City"), mem.contacts.Field<string>("State")
                    , mem.contacts.Field<string>("ZipCode"), mem.contacts.Field<long>("PhoneNumber"), mem.contacts.Field<string>("Email")
                    , mem.contacts.Field<string>("AddressBookName"), mem.Type);
                result.Add(mem.contacts.Field<int>("ContactId") + " " + mem.contacts.Field<string>("FirstName"));
            }
            return result;
        }
        public static List<string> RetrieveCountBasedOnCityAndStateNameAfterER()
        {
            //group by city and state name
            DataTable contact_list = GetDataTables.GetContactTable();
            List<string> result = new List<string>();
            var member = from contacts in contact_list.AsEnumerable() group contacts by new { City = contacts.Field<string>("City"), State = contacts.Field<string>("State") } into temp select new { City = temp.Key.City, State = temp.Key.State, count = temp.Count() };
            foreach (var mem in member)
            {
                Console.WriteLine(mem.City + " " + mem.State + " " + mem.count);
                result.Add(mem.City + " " + mem.State + " " + mem.count);

            }
            return result;
        }
        public static List<string> SortNameAfterER(string city)
        {
            DataTable contact_list = GetDataTables.GetContactTable();
            var member = from contacts in contact_list.AsEnumerable() orderby contacts.Field<string>("FirstName") where contacts.Field<string>("City") == city select contacts;
            List<string> result = new List<string>();
            foreach (var mem in member)
            {

                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", mem["ContactId"], mem["FirstName"], mem["LastName"], mem["Address"], mem["City"], mem["State"], mem["ZipCode"], mem["PhoneNumber"], mem["Email"]);
                result.Add(mem["FirstName"] + " " + mem["LastName"]);
            }
            return result;
        }
        //count based on address book type using join
        public static List<string> CountByTypeAfterER()
        {
            DataTable contact_list = GetDataTables.GetContactTable();
            DataTable addressBookType = GetDataTables.GetAddressBookTypeTable();
            DataTable contact_map_type = GetDataTables.GetContact_map_typeTable();
            List<string> result = new List<string>();
            var member = from contacts in contact_list.AsEnumerable()
                         join contactmaptype in contact_map_type.AsEnumerable()
                         on contacts.Field<int>("ContactId") equals contactmaptype.Field<int>("contactId")
                         join addressbooktype in addressBookType.AsEnumerable()
                         on contactmaptype.Field<int>("typeId") equals addressbooktype.Field<int>("typeId")
                         group contacts by addressbooktype.Field<string>("Type") into temp
                         select new { Type = temp.Key, NoOfContacts = temp.Count() };
            foreach (var mem in member)
            {
                Console.WriteLine(mem.Type + " " + mem.NoOfContacts);
                result.Add(mem.Type + " " + mem.NoOfContacts);
            }
            return result;

        }

    }
}
