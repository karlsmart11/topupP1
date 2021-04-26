﻿using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    class TitleRepository : ITitle
    {
        public int Delete(Title title)
        {
            throw new NotImplementedException();
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
