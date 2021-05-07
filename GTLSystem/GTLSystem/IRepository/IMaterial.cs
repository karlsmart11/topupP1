using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    interface IMaterial
    {
        void Insert(Material material);
        bool Update(Material material);
        int Delete(string materialId);
        IEnumerable<Material> GetAvailableByISBN(string titleISBN, bool available);
        int GetNumberOfAvailable();
        int GetNumberOfUnavailable();
        IEnumerable<Material> GetAvailableMaterials();

    }
}
