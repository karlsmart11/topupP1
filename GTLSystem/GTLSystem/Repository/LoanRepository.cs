using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GTLSystem.Repository
{
    class LoanRepository : ILoan
    {

        public int Delete(string loanID)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            return con.Execute(@"DELETE FROM [dbo].[Loan] WHERE Id = " + loanID);
        }

        public IEnumerable<Loan> getByMemberSSN(string SSN)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            return con.Query<Loan>("SELECT * FROM Loan WHERE MemberSSN = " + SSN);
        }

        public void Insert(Loan loan)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();


            string insertQuery = @"INSERT INTO Loan
           (StartDate
           ,MemberSSN)
            VALUES 
           (@StartDate,
            @MemberSSN)";

            con.Execute(insertQuery, loan);
        }

        public int Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
