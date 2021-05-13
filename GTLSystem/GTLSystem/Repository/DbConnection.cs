using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    public class DbConnection
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=GTL;Trusted_Connection=True;");
        }
    }
}
