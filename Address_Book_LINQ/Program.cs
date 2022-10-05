using System;
using System.Data;

namespace Address_Book_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            DataTable dataTable = GetDataTables.GetTable();
            TableOperations.Display(dataTable);
            TableOperations.ModifyLastName(dataTable, "singh", "sandeep");
        }
    }
}
