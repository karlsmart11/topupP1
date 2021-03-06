using Autofac.Extras.Moq;
using FluentAssertions;
using GTLSystem.Controller;
using GTLSystem.IRepository;
using GTLSystem.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GTLSystem.Controller.Tests
{
    [TestClass()]
    public class LoanControllerTests
    {
        [TestMethod()]
        public void RegisterLoanTest()
        {
            //Arrange
            using var mock = AutoMock.GetLoose();
            string ssn = "ssn";
            bool availability = true;
            var isbns = new List<string>
            {
                "isbn",
                "isbn",
                "isbn"
            };

            mock.Mock<ILoanRepository>()
                .Setup(x => x.Insert(It.IsAny<Loan>()))
                .Returns(true);

            mock.Mock<ILoanRepository>()
                .Setup(x => x.GetNewestLoan())
                .Returns(GetSampleNewestLoan());

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetBySSN(ssn))
                .Returns(GetSampleMember());

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.GetAvailableByISBN(isbns[0], availability))
                .Returns(GetsampleAvailableMaterials());

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.Update(GetsampleAvailableMaterials().ToList()[0]))
                .Returns(true);

            mock.Mock<IMaterialLoanRepository>()
                .Setup(x => x.Insert(It.IsAny<Loan>(), It.IsAny<Material>()))
                .Returns(true);

            var ctrl = mock.Create<LoanController>();

            var controllers = mock.Create<ControllerContainer>();

            //Act
            var result = ctrl.RegisterLoan(ssn, isbns, controllers);

            //Assert
            result.Should().Be(1);
        }

        [TestMethod()]
        public void RegisterLoanTestNoAvailableMaterial()
        {
            //Arrange
            using var mock = AutoMock.GetLoose();
            string ssn = "ssn";
            bool availability = true;
            var isbns = new List<string>
            {
                "isbn",
                "isby",
                "isbn"
            };

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetBySSN(ssn))
                .Returns(GetSampleMember());

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.GetAvailableByISBN(isbns[0], availability))
                .Returns(getSampleNoMaterials());

            var ctrl = mock.Create<LoanController>();

            var controllers = mock.Create<ControllerContainer>();

            //Act
            var result = ctrl.RegisterLoan(ssn, isbns, controllers);

            //Assert
            result.Should().Be(0);
        }

        [TestMethod()]
        public void RegisterLoanTestCantInsert()
        {
            //Arrange
            using var mock = AutoMock.GetLoose();
            string ssn = "ssn";
            bool availability = true;
            var isbns = new List<string>
            {
                "isbn",
                "isbn",
                "isbn"
            };

            mock.Mock<ILoanRepository>()
                .Setup(x => x.Insert(It.IsAny<Loan>()))
                .Returns(false);

            mock.Mock<ILoanRepository>()
                .Setup(x => x.GetNewestLoan())
                .Returns(GetSampleNewestLoan());

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetBySSN(ssn))
                .Returns(GetSampleMember());

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.GetAvailableByISBN(isbns[0], availability))
                .Returns(GetsampleAvailableMaterials());

            mock.Mock<IMaterialRepository>()
                .Setup(x => x.Update(GetsampleAvailableMaterials().ToList()[0]))
                .Returns(true);

            mock.Mock<IMaterialLoanRepository>()
                .Setup(x => x.Insert(It.IsAny<Loan>(), It.IsAny<Material>()))
                .Returns(true);

            var ctrl = mock.Create<LoanController>();

            var controllers = mock.Create<ControllerContainer>();

            //Act
            var result = ctrl.RegisterLoan(ssn, isbns, controllers);

            //Assert
            result.Should().Be(-1);
        }

        [TestMethod()]
        public void GetCurrentNoOfMaterialsBySSNTest()
        {
            //Arrange
            using var mock = AutoMock.GetLoose();
            string ssn = "ssn";

            mock.Mock<ILoanRepository>()
                .Setup(x => x.MaterialCountBySSN(ssn))
                .Returns(GetsampleAvailableMaterials().ToList().Count());

            var ctrl = mock.Create<LoanController>();

            //Act
            var result = ctrl.GetCurrentNoOfMaterialsBySSN(ssn);

            //Assert
            result.Should().Be(GetsampleAvailableMaterials().ToList().Count());
        }

        private List<Loan> GetSampleLoans()
        {
            return new List<Loan>()
            {
                new Loan
                {
                    StartDate = new DateTime(2001-01-01),
                    MemberSSN = "ssn"
                },
                new Loan
                {
                    StartDate = new DateTime(2001-01-01),
                    MemberSSN = "ssn"
                },
                new Loan
                {
                    StartDate = new DateTime(2001-01-01),
                    MemberSSN = "ssn"
                }
            };
        }
        private Loan GetSampleNewestLoan()
        {
            return new Loan
            {
                LoanId = 1,
                StartDate = new DateTime(2001 - 01 - 01),
                MemberSSN = "ssn"
            };
        }
        private Member GetSampleMember()
        {
            return new Member
            {
                CardExpDate = new DateTime(2002 - 01 - 01),
                Address = "address",
                Campus = "campus",
                SSN = "ssn",
                PhoneNumber = "phone"
            };
        }
        private IEnumerable<Material> GetsampleAvailableMaterials()
        {
            var materials = new Collection<Material>();

            materials.Add(new Material
            {
                Available = true,
                ISBN = "isbn",
                MaterialId = 1,
                Type = "type"
            });
            materials.Add(new Material
            {
                Available = true,
                ISBN = "isbn",
                MaterialId = 2,
                Type = "type"
            });
            materials.Add(new Material
            {
                Available = true,
                ISBN = "isbn",
                MaterialId = 3,
                Type = "type"
            });

            return materials as IEnumerable<Material>;
        }

        private IEnumerable<Material> getSampleNoMaterials()
        {
            return new Collection<Material>() as IEnumerable<Material>;
        }

        private IEnumerable<Material> GetsampleUnvailableMaterials()
        {
            var materials = new Collection<Material>();

            materials.Add(new Material
            {
                Available = false,
                ISBN = "isbn",
                MaterialId = 1,
                Type = "type"
            });
            materials.Add(new Material
            {
                Available = false,
                ISBN = "isbn",
                MaterialId = 2,
                Type = "type"
            });
            materials.Add(new Material
            {
                Available = false,
                ISBN = "isbn",
                MaterialId = 3,
                Type = "type"
            });

            return materials as IEnumerable<Material>;
        }
    }
}