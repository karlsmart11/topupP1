using GTLSystem.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLTests
{
    class MaterialRepositoryTests
    {
        [TestMethod]
        public void Test_Get_Available_Materials()
        {
            //Arrange
            var materialRepository = new MaterialRepository();

            //Act
            var value = materialRepository.GetAvailableMaterials();
            bool result;

            foreach (var item in value)
            {

            }

            //Assert

        }
    }
}
