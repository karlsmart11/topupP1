using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    public class MaterialLoanRepository : IMaterialLoanRepository
    {
        private DbConnection connection;

        public MaterialLoanRepository()
        {

        }

        public MaterialLoanRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public bool Insert(Loan loan, Material material)
        {
            MaterialLoan materialLoan = new MaterialLoan() { LoanId = loan.LoanId, MaterialId = material.MaterialId };
            bool result = true;
            var con = connection.CreateConnection();

            string insertQuery = @"INSERT INTO MaterialLoan 
            (MaterialId, 
            LoanId) 
            VALUES 
            (@MaterialId, 
            @LoanId)";

            try
            {
                con.Execute(insertQuery, materialLoan);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
