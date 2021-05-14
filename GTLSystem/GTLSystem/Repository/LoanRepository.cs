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
    public class LoanRepository : ILoanRepository
    {
        private DbConnection connection;

        public LoanRepository()
        {

        }

        public LoanRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public bool Delete(string loanID)
        {
            bool result = true;
            var con = connection.CreateConnection();

            try
            {
                con.Execute(@"DELETE FROM [dbo].[Loan] WHERE Id = " + loanID);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public Loan GetNewestLoan()
        {
            var con = connection.CreateConnection();

            return con.QueryFirst<Loan>("SELECT TOP 1 * FROM Loan ORDER BY LoanId DESC");
        }

        public bool Insert(Loan loan)
        {
            bool result = true;
            var con = connection.CreateConnection();


            string insertQuery = @"INSERT INTO Loan
           (StartDate,
            MemberSSN)
            VALUES 
           (@StartDate,
            @MemberSSN)";

            try
            {
                con.Execute(insertQuery, loan);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public int? MaterialCountBySSN(string memberSSN)
        {
            var con = connection.CreateConnection();

            try
            {
                return con.QuerySingle<int>("SELECT COUNT(MaterialId) FROM Loan INNER JOIN MaterialLoan ON Loan.LoanId = MaterialLoan.LoanId WHERE Loan.MemberSSN = '" + memberSSN + "'");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
