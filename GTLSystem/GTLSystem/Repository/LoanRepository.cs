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
    public class LoanRepository : ILoan
    {
        private DbConnection connection;

        public LoanRepository()
        {

        }

        public LoanRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public int Delete(string loanID)
        {
            var con = connection.CreateConnection();

            return con.Execute(@"DELETE FROM [dbo].[Loan] WHERE Id = " + loanID);
        }

        public Loan GetNewestLoan()
        {
            var con = connection.CreateConnection();

            return con.QueryFirst<Loan>("SELECT TOP 1 * FROM Loan ORDER BY LoanId DESC");
        }

        public void Insert(Loan loan)
        {
            var con = connection.CreateConnection();


            string insertQuery = @"INSERT INTO Loan
           (StartDate,
            MemberSSN)
            VALUES 
           (@StartDate,
            @MemberSSN)";

            con.Execute(insertQuery, loan);
        }

        public int MaterialCountBySSN(string memberSSN)
        {
            var con = connection.CreateConnection();

            return con.QuerySingle<int>("SELECT COUNT(MaterialId) FROM Loan INNER JOIN MaterialLoan ON Loan.LoanId = MaterialLoan.LoanId WHERE Loan.MemberSSN = '" + memberSSN + "'");
        }

        public int Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
