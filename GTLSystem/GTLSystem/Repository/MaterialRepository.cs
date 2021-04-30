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
        public int Delete(string materialId)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            return con.Execute(@"DELETE FROM [dbo].[Material] WHERE Id = " + materialId);
        }

        public void GetAvailableByISBN(string titleISBN, bool available)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            var materials = con.Query<Material>("GetAvailableMaterial", new { ISBN = titleISBN, Available = available }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void Insert(Material material)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            string insertQuery = @"INSERT INTO Material 
            (Type,
            ISBN, 
            Available) 
            VALUES 
            (@Type,
            @ISBN,
            @Available)";

            con.Execute(insertQuery, material);
        }

        public int Update(Material material)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            string updateQuery = @"UPDATE Material
            Set
            Type = @Type,
            ISBN = @ISBN,
            Available = @Available
            WHERE Id = " + material.MaterialId;

            return con.Execute(updateQuery);
        }
    }
}
