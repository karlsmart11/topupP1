using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface IMemberRepository
    {
        void Insert(Member member);
        int Update(Member member);
        int Delete(string memberSSN);
        Member GetBySSN(string SSN);
        IEnumerable<Member> GetAllMembers();
    }
}
