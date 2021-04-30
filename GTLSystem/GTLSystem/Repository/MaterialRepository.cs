using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

        public IEnumerable<Material> GetAvailableByISBN(string titleISBN, bool available)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

            return con.Query<Material>("GetAvailableMaterial", new { ISBN = titleISBN, Available = available }, commandType: CommandType.StoredProcedure);
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
