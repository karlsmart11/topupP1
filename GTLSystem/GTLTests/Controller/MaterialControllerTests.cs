using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTLSystem.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using GTLSystem.Model;
using Autofac.Extras.Moq;
using GTLSystem.IRepository;
using FluentAssertions;
using System.Linq;
using Moq;

namespace GTLSystem.Controller.Tests
{
    [TestClass()]
    public class MaterialControllerTests
    {
        [TestMethod()]
        public void RegisterMaterialTestTrue()
        {
            //Arrange
            Material material = getSampleMaterials()[0];

            var mock = AutoMock.GetLoose();

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
            Material material = getSampleMaterials()[0];

            var mock = AutoMock.GetLoose();

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
            Material material = getSampleMaterials()[0];

            var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.Update(material))
                .Returns(true);

            var ctrl = mock.Create<MaterialController>();

            //Act
            var result = ctrl.ReserveMaterial(material);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod()]
        public void GetAvailableMaterialsTest()
        {
            //Arrange
            var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.GetAvailableMaterials())
                .Returns(getSampleMaterials);

            var ctrl = mock.Create<MaterialController>();

            //Act
            var result = ctrl.GetAvailableMaterials();

            //Assert
            result.Should().BeEquivalentTo(getSampleMaterials());

            mock.Mock<IMaterialRepository>()
            .Verify(x => x.GetAvailableMaterials(), Times.Exactly(1));
        }

        [TestMethod()]
        public void GetNumberOfAvailableMaterialsTest()
        {
            //Arrange
            int? amount = 1;
            var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.GetNumberOfAvailable())
                .Returns(amount);

            var ctrl = mock.Create<MaterialController>();

            //Act
            var result = ctrl.GetNumberOfAvailableMaterials();

            //Assert
            result.Should().Be(amount);
        }

        [TestMethod()]
        public void GetNumberOfUnavailableMaterialsTest()
        {
            //Arrange
            int? amount = 1;
            var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.GetNumberOfUnavailable())
                .Returns(amount);

            var ctrl = mock.Create<MaterialController>();

            //Act
            var result = ctrl.GetNumberOfUnavailableMaterials();

            //Assert
            result.Should().Be(amount);
        }

        [TestMethod()]
        public void GetAvailableByISBNTest()
        {
            //Arrange
            var mock = AutoMock.GetLoose();
            var isbn = "test";
            var availability = true;

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.GetAvailableByISBN(isbn, availability))
                .Returns(getSampleMaterials);

            var ctrl = mock.Create<MaterialController>();

            //Act
            var result = ctrl.GetAvailableByISBN(isbn, availability);

            //Assert
            result.Should().BeEquivalentTo(getSampleMaterials());
        }

        public List<Material> getSampleMaterials()
        {
            return new List<Material>()
            {
                new Material
                {
                    Available = true,
                    Type = "test",
                    ISBN = "test",
                    MaterialId = 0
                },
                new Material
                {
                    Available = true,
                    Type = "test",
                    ISBN = "test",
                    MaterialId = 1
                },
                new Material
                {
                    Available = false,
                    Type = "test",
                    ISBN = "test",
                    MaterialId = 2
                }
            };
        }
    }
}