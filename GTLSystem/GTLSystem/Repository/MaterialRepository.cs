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
    public class MaterialRepository : IMaterial
    {
        private DbConnection connection;

        public MaterialRepository()
        {

        }

        public MaterialRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public int Delete(string materialId)
        {
            var con = connection.CreateConnection();

            return con.Execute(@"DELETE FROM [dbo].[Material] WHERE Id = " + materialId);
        }

        public IEnumerable<Material> GetAvailableByISBN(string titleISBN, bool available)
        {
            var con = connection.CreateConnection();

            return con.Query<Material>("GetAvailableMaterial", new { ISBN = titleISBN, Available = available }, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Material> GetAvailableMaterials()
        {
            IEnumerable<Material> result;

            var con = connection.CreateConnection();

            try
            {
                result = con.Query<Material>("SELECT * FROM Material WHERE Available = 1");
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        public int GetNumberOfAvailable()
        {
            var con = connection.CreateConnection();

            return con.QuerySingle<int>("SELECT COUNT(Available) FROM Material WHERE Available = 1");
        }

        public int GetNumberOfUnavailable()
        {
            var con = connection.CreateConnection();

            return con.QuerySingle<int>("SELECT COUNT(Available) FROM Material WHERE Available = 0");

        }

        public void Insert(Material material)
        {
            var con = connection.CreateConnection();

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

        public bool Update(Material material)
        {
            bool result = true;
            var con = connection.CreateConnection();

            string updateQuery = @"UPDATE Material
            Set
            Type = @Type,
            ISBN = @ISBN,
            Available = @Available
            WHERE MaterialId = " + material.MaterialId;

            try
            {
                con.Execute(updateQuery, material);
            }
            catch (Exception)
            {
                result = false;
                //Console.WriteLine("THIS IS NOT A DRILL");
                //Console.WriteLine(e);
            }
            return result;
        }
    }
}
