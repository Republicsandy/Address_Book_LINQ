using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_LINQ
{
    public class AddressBookModel
    {
        public int contactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public long Phonenumber { get; set; }
        public string email { get; set; }
        public string addressbookname { get; set; }
        public string addressBooktype { get; set; }
    }
}
