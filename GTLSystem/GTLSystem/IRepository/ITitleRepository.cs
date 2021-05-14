using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface ITitleRepository
    {
        bool Insert(Title title);
        bool Update(Title title);
        bool Delete(string titleISBN);
        Title GetByISBN(string ISBN);
    }
}
