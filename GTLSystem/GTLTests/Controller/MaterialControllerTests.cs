using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTLSystem.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using GTLSystem.Model;
using Autofac.Extras.Moq;
using GTLSystem.IRepository;
using FluentAssertions;

namespace GTLSystem.Controller.Tests
{
    [TestClass()]
    public class MaterialControllerTests
    {
        [TestMethod()]
        public void RegisterMaterialTestTrue()
        {
            //Arrange
            Material material = new Material { Available = true,
                                               ISBN = "test",
                                               MaterialId = 0,
                                               Type = "test"};

            using var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.Insert(material))
                .Returns(true);

            //Act
            var ctrl = mock.Create<MaterialController>();

            var result = ctrl.RegisterMaterial(material);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod()]
        public void RegisterMaterialTestFalse()
        {
            //Arrange
            Material material = new Material
            {
                Available = true,
                ISBN = "test",
                MaterialId = 0,
                Type = "test"
            };

            using var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.Insert(material))
                .Returns(false);

            var ctrl = mock.Create<MaterialController>();

            //Act
            var result = ctrl.RegisterMaterial(material);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod()]
        public void ReserveMaterialTest()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod()]
        public void GetAvailableMaterialsTest()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod()]
        public void GetNumberOfAvailableMaterialsTest()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod()]
        public void GetNumberOfUnavailableMaterialsTest()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod()]
        public void GetAvailableByISBNTest()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}