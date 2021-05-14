using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface IMemberRepository
    {
        bool Insert(Member member);
        bool Update(Member member);
        bool Delete(string memberSSN);
        Member GetBySSN(string SSN);
        IEnumerable<Member> GetAllMembers();
    }
}
