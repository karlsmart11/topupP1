using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    interface IMember
    {
        void Insert(Member member);
        int Update(Member member);
        int Delete(Member member);
    }
}
