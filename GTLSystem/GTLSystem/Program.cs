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
            var repo = new LoanRepository();
            var loan = new Loan();

            loan.StartDate = DateTime.Now;

            repo.Insert(loan);

            Console.WriteLine("inserted");
        }
    }
}
