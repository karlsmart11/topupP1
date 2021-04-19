using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    class LoanRepository : ILoan
    {

        public int Delete(Loan loan)
        {
            throw new NotImplementedException();
        }

        public void Insert(Loan loan)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            string insertQuery = @"INSERT INTO [dbo].[Loan]
           ([Id]
           ,[StartDate]
           ,[MemberSSN])";

            //var result = con.Execute(insertQuery, loan);
        }

        public int Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
