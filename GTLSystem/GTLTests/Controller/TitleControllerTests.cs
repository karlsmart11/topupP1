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

        }

        [TestMethod()]
        public void RegisterTitleTest()
        {

        }

        [TestMethod()]
        public void checkISBNTest()
        {

        }

        [TestMethod()]
        public void GetByISBNTest()
        {

        }
    }
}

namespace GTLTests
{
    [TestClass]
    public class TitleControllerTests
    {
        [TestMethod]
        public void Test_Title_Get_By_Correct_ISBN()
        {
            //Arrange
            DbConnection connection = new DbConnection();
            string input = "000458743-X";

            Title model = new Title() { 
                ISBN = "000458743-X", 
                Requested = false,
                TitleName = "Janky Promoters, The",
                Description = "alazdmzuhywkqxlblyoxqfprdllqahhzkubvvrhduqfcgvducubpwhqyuaztwqpbvvpmecftsuobiqbnlqxfvbhzfuxpmvhkjh",
                Author = "Vere Gostridge",
                Subject = "throughput",
                Loanable = true
            };

            TitleRepository titleRepository = new TitleRepository(connection);

            //Act
            Title title = titleRepository.GetByISBN(input);

            //Assert
            title.Should().BeEquivalentTo(model);
        }

        [TestMethod]
        public void Test_Title_Get_By_Incorrect_ISBN()
        {
            using var mock = AutoMock.GetLoose();
            //arrange
            string wrongInput = "wrongInput";
            mock.Mock<ITitleRepository>()
                .Setup(x => x.GetByISBN(wrongInput))
                .Returns(GetSampleNullTitle);

            //Act
            var res = mock.Create<TitleRepository>().GetByISBN(wrongInput);

            //Assert
            res.Should().BeNull();
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
