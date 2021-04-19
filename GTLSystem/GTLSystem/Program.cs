using Dapper;
using System;
using System.Data.SqlClient;

namespace GTLSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            var version = con.ExecuteScalar<string>("SELECT @@VERSION");

            Console.WriteLine(version);
        }
    }
}
