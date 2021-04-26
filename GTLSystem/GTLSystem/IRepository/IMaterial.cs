using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    interface IMaterial
    {
        void Insert(Material material);
        int Update(Material material);
        int Delete(string materialId);
        void GetAvailableByISBN(string titleISBN, bool available);
    }
}
