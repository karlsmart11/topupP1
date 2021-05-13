using GTLSystem.Model;
using GTLSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLSystem.Controller
{
    public class MaterialController
    {
        MaterialRepository materialRepository = new MaterialRepository();

        public bool RegisterMaterial(Material material)
        {
            bool result = true;
            try
            {
                materialRepository.Insert(material);
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
                materialRepository.Update(material);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public int GetNumberOfAvailableMaterials()
        {
            int res;

            try
            {
                res = materialRepository.GetNumberOfAvailable();
            }
            catch (Exception)
            {
                res = -1;
            }

            return res;
            
        }

        public int GetNumberOfUnavailableMaterials()
        {
            int res;

            try
            {
                res = materialRepository.GetNumberOfUnavailable();
            }
            catch (Exception)
            {
                res = -1;
            }

            return res;
        }
    }
}
