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
    public class MaterialRepository : IMaterialRepository
    {
        private DbConnection _connection;

        public MaterialRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(string materialId)
        {
            bool result = true;
            var con = _connection.CreateConnection();

            try
            {
                con.Execute(@"DELETE FROM [dbo].[Material] WHERE Id = " + materialId);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public IEnumerable<Material> GetAvailableByISBN(string titleISBN, bool available)
        {
            var con = _connection.CreateConnection();

            try
            {
                return con.Query<Material>("GetAvailableMaterial", new { ISBN = titleISBN, Available = available }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Material> GetAvailableMaterials()
        {
            IEnumerable<Material> result;

            var con = _connection.CreateConnection();

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

        public int? GetNumberOfAvailable()
        {
            var con = _connection.CreateConnection();

            try
            {
                return con.QuerySingle<int>("SELECT COUNT(Available) FROM Material WHERE Available = 1");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? GetNumberOfUnavailable()
        {
            var con = _connection.CreateConnection();

            try
            {
                return con.QuerySingle<int>("SELECT COUNT(Available) FROM Material WHERE Available = 0");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Insert(Material material)
        {
            bool result = true;
            var con = _connection.CreateConnection();

            string insertQuery = @"INSERT INTO Material 
            (Type,
            ISBN, 
            Available) 
            VALUES 
            (@Type,
            @ISBN,
            @Available)";

            try
            {
                con.Execute(insertQuery, material);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool Update(Material material)
        {
            bool result = true;
            var con = _connection.CreateConnection();

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
            }

            return result;
        }
    }
}
