using Dapper;
using GTLSystem.IRepository;
using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GTLSystem.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private DbConnection connection;

        public MemberRepository()
        {

        }

        public MemberRepository(DbConnection connection)
        {
            this.connection = connection;
        }

        public int Delete(string memberSSN)
        {
            var con = connection.CreateConnection();

            return con.Execute(@"DELETE FROM [dbo].[Member] WHERE SSN = " + memberSSN);

        }

        public IEnumerable<Member> GetAllMembers()
        {
            IEnumerable<Member> result;

            var con = connection.CreateConnection();

            try
            {
                result = con.Query<Member>("SELECT * FROM Member");
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        public Member GetBySSN(string memberSSN)
        {
            Member result;

            var con = connection.CreateConnection();

            string query = @"SELECT * FROM [dbo].[Member] where SSN = " + memberSSN;

            try
            {
                result = con.QueryFirst<Member>(query);
            }
            catch (Exception)
            {
                result = null;                
            }

            return result;
        }

        public void Insert(Member member)
        {
            throw new NotImplementedException();
        }

        public int Update(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
