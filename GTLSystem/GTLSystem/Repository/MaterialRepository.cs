using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    class MaterialRepository : IMaterial
    {
        public int Delete(Material material)
        {
            throw new NotImplementedException();
        }

        public void Insert(Material material)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            string insertQuery = @"INSERT INTO Material 
            (Type,
            ISBN) 
            VALUES 
            (@Type,
            @ISBN)";

            con.Execute(insertQuery, material);
        }

        public int Update(Material material)
        {
            throw new NotImplementedException();
        }
    }
}
