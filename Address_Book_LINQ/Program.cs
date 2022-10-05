using System;
using System.Data;

namespace Address_Book_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable = GetDataTables.GetTable();
        }
    }
}
