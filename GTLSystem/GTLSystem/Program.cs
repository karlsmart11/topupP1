using Dapper;
using GTLSystem.Model;
using GTLSystem.Repository;
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

            var repo = new LoanRepository();
            var loan = new Loan();

            loan.StartDate = DateTime.Now;

            repo.Insert(loan);

            Console.WriteLine("inserted");
        }
    }
}
