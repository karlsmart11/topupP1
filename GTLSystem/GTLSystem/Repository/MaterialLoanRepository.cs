using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    public class MaterialLoanRepository : IMaterialLoan
    {
        private DbConnection connection;

        public MaterialLoanRepository()
        {

        }

        public MaterialLoanRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(MaterialLoan materialLoan)
        {
            var con = connection.CreateConnection();

            string insertQuery = @"INSERT INTO MaterialLoan 
            (MaterialId, 
            LoanId) 
            VALUES 
            (@MaterialId, 
            @LoanId)";

            con.Execute(insertQuery, materialLoan);
        }
    }
}
