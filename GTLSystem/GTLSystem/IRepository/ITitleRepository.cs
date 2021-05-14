using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface ITitleRepository
    {
        void Insert(Title title);
        int Update(Title title);
        int Delete(string titleISBN);
        Title GetByISBN(string ISBN);
    }
}
