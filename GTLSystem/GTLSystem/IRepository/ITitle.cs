using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    interface ITitle
    {
        void Insert(Title title);
        int Update(Title title);
        int Delete(string titleISBN);
    }
}
