using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    public class TitleRepository : ITitleRepository
    {
        private DbConnection connection;

        public TitleRepository() { }

        public TitleRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public bool Delete(string titleISBN)
        {
            bool result = true;
            var con = connection.CreateConnection();

            try
            {
                con.Execute(@"DELETE FROM [dbo].[Title] WHERE ISBN = " + titleISBN); 
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


        public Title GetByISBN(string titleISBN)
        {
            Title result;

            var con = connection.CreateConnection();

            try
            {
                result = con.QueryFirst<Title>("SELECT * FROM Title where ISBN = '" + titleISBN + "'");
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }

        public bool Insert(Title title)
        {
            bool result = true;
            var con = connection.CreateConnection();

            string insertQuery = @"INSERT INTO Title 
            (ISBN, 
            Requested, 
            TitleName, 
            Description, 
            Available, 
            Author, 
            Subject, 
            Loanable)
            VALUES
            (@ISBN, 
            @Requested, 
            @TitleName,  
            @Description, 
            @Available, 
            @Author, 
            @Subject, 
            @Loanable)";

            try
            {
                con.Execute(insertQuery, title);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public object GetByISBN()
        {
            throw new NotImplementedException();
        }

        public bool Update(Title title)
        {
            throw new NotImplementedException();
        }
    }
}
