using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    public class TitleRepository : ITitle
    {
        private DbConnection connection;

        public TitleRepository() { }

        public TitleRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public int Delete(string titleISBN)
        {
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

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
            var cs = @"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;";

            using var con = new SqlConnection(cs);
            con.Open();

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

        public int Update(Title title)
        {
            throw new NotImplementedException();
        }
    }
}
