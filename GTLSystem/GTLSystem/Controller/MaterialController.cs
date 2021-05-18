using GTLSystem.IRepository;
using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    public class MaterialController
    {
        IMaterialRepository _materialRepository;

        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public bool RegisterMaterial(Material material)
        {
            return _materialRepository.Insert(material);
        }

        public bool ReserveMaterial(Material material)
        {
            material.Available = false;

            return _materialRepository.Update(material);
        }

        public IEnumerable<Material> GetAvailableMaterials()
        {
            return _materialRepository.GetAvailableMaterials();
        }


        public int? GetNumberOfAvailableMaterials()
        {
            return _materialRepository.GetNumberOfAvailable();            
        }

        public int? GetNumberOfUnavailableMaterials()
        {
            return _materialRepository.GetNumberOfUnavailable();
        }

        public IEnumerable<Material> GetAvailableByISBN(string isbn, bool available)
        {
            return _materialRepository.GetAvailableByISBN(isbn, available);
        }
    }
}
