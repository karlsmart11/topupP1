using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    class MaterialLoanRepository : IMaterialLoan
    {
        public void Insert(MaterialLoan materialLoan)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

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
