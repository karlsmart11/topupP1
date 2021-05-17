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
    public class TitleControllerTests
    {
        [TestMethod()]
        public void TitleControllerTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestMethod()]
        public void RegisterTitleTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestMethod()]
        public void checkISBNCorrectTest()
        {
            //Arrange
            string input = "correct";

            using var mock = AutoMock.GetLoose();

            mock.Mock<ITitleRepository>()
                .Setup(x => x.GetByISBN(input)).Returns(GetSampleTitle());

            var ctrl = mock.Create<TitleController>();

            //Act
            var result = ctrl.checkISBN(input);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod()]
        public void checkISBNIncorrectTest()
        {
            //Arrange
            string input = "incorrect";

            using var mock = AutoMock.GetLoose();

            mock.Mock<ITitleRepository>()
                .Setup(x => x.GetByISBN(input)).Returns(GetSampleNullTitle());

            var ctrl = mock.Create<TitleController>();

            //Act
            var result = ctrl.checkISBN(input);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void Test_Title_Get_By_Correct_ISBN()
        {
            //Arrange
            string input = "correct";

            using var mock = AutoMock.GetLoose();

            mock.Mock<ITitleRepository>()
                .Setup(x => x.GetByISBN(input)).Returns(GetSampleTitle());

            var ctrl = mock.Create<TitleController>();

            //Act
            var result = ctrl.GetByISBN(input);

            //Assert
            result.Should().BeEquivalentTo(GetSampleTitle());
        }

        [TestMethod]
        public void Test_Title_Get_By_Incorrect_ISBN()
        {
            //Arrange
            string input = "incorrect";

            using var mock = AutoMock.GetLoose();

            mock.Mock<ITitleRepository>()
                .Setup(x => x.GetByISBN(input)).Returns(GetSampleNullTitle);

            var ctrl = mock.Create<TitleController>();

            //Act
            var result = ctrl.GetByISBN(input);

            //Assert
            result.Should().BeEquivalentTo(GetSampleNullTitle());
        }

        private Title GetSampleNullTitle()
        {
            return null;
        }

        private Title GetSampleTitle()
        {
            return new Title 
            { 
                Author = "testAuthor",
                Description = "testDesc",
                Available = true,
                ISBN = "testISBN",
                Loanable = true,
                Requested = false,
                Subject = "testSubject",
                TitleName = "testTitleName"
            };
        }        
    }
}
