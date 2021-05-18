using GTLSystem.Controller;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTLSystem.Repository;
using GTLSystem.IRepository;
using GTLSystem.Model;
using FluentAssertions;
using Autofac.Extras.Moq;

namespace GTLSystem.Controller.Tests
{
    [TestClass()]
    public class MaterialLoanControllerTests
    {
        [TestMethod()]
        public void CreateCorrectMaterialLoanTest()
        {
            //Arrange
            var loan = GetSampleLoan();
            var material = GetSampleMaterial();
            using var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialLoanRepository>()
                .Setup(x => x.Insert(loan, material)).Returns(true);

            var ctrl = mock.Create<MaterialLoanController>();

            //Act
            var result = ctrl.CreateMaterialLoan(loan, material);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod()]
        public void CreateIncorrectMaterialLoanTest()
        {
            //Arrange
            var loan = GetSampleLoan();
            var material = GetSampleMaterial();

            using var mock = AutoMock.GetLoose();

            mock.Mock<IMaterialLoanRepository>()
                .Setup(x => x.Insert(loan, material)).Returns(false);

            var ctrl = mock.Create<MaterialLoanController>();

            //Act
            var result = ctrl.CreateMaterialLoan(loan, material);

            //Assert
            result.Should().BeFalse();
        }

        private Loan GetSampleLoan()
        {
            return new Loan
            {
                LoanId = 1,
                MemberSSN = "test",
                StartDate = DateTime.Now
            };
        }

        private Material GetSampleMaterial()
        {
            return new Material
            {
                MaterialId = 1,
                Available = true,
                ISBN = "test",
                Type = "bog"
            };
        }

        private MaterialLoan GetSampleMaterialLoan()
        {
            return new MaterialLoan
            {
                LoanId = 1,
                MaterialId = 1
            };
        }

        private MaterialLoan GetSampleNullMaterialLoan()
        {
            return null;
        }
    }
}