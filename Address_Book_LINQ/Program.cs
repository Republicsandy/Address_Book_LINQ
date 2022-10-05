using System;
using System.Collections.Generic;
using System.Data;

namespace Address_Book_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = GetDataTables.GetTable();
            List<string> result = TableOperations.RetrieveDataBasedOnCityName(dataTable, "Chennai");
            foreach (var mem in result)
                Console.WriteLine(mem);
        }
    }
}
