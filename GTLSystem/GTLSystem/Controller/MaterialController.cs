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
        //static DbConnection connection = new DbConnection();
        //private IMaterialRepository materialRepository = new MaterialRepository(connection);

        //private static IMaterialRepository materialRepository
        //{
        //    get => ServiceLocator.GetRequiredService<IMaterialRepository>();
        //}

        IMaterialRepository _materialRepository;

        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public bool RegisterMaterial(Material material)
        {
            bool result = true;
            try
            {
                _materialRepository.Insert(material);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public bool ReserveMaterial(Material material)
        {
            bool result = true;

            material.Available = false;

            try
            {                
                _materialRepository.Update(material);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public IEnumerable<Material> GetAvailableMaterials()
        {
            return _materialRepository.GetAvailableMaterials();
        }

        public int? GetNumberOfAvailableMaterials()
        {
            int? res;

            try
            {
                res = _materialRepository.GetNumberOfAvailable();
            }
            catch (Exception)
            {
                res = -1;
            }

            return res;
            
        }

        public int? GetNumberOfUnavailableMaterials()
        {
            int? res;

            try
            {
                res = _materialRepository.GetNumberOfUnavailable();
            }
            catch (Exception)
            {
                res = -1;
            }

            return res;
        }
    }
}
