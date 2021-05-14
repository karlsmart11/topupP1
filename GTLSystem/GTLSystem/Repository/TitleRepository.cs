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

        public int Delete(string titleISBN)
        {
            var con = connection.CreateConnection();

            return con.Execute(@"DELETE FROM [dbo].[Title] WHERE ISBN = " + titleISBN); 
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

        public void Insert(Title title)
        {
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

            con.Execute(insertQuery, title);
        }

        public object GetByISBN()
        {
            throw new NotImplementedException();
        }

        public int Update(Title title)
        {
            throw new NotImplementedException();
        }
    }
}
