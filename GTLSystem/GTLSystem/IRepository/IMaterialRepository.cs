using GTLSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.IRepository
{
    public interface IMaterialRepository
    {
        bool Insert(Material material);
        bool Update(Material material);
        bool Delete(string materialId);
        IEnumerable<Material> GetAvailableByISBN(string titleISBN, bool available);
        int? GetNumberOfAvailable();
        int? GetNumberOfUnavailable();
        IEnumerable<Material> GetAvailableMaterials();

    }
}
