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
        int Delete(Material material);
    }
}
