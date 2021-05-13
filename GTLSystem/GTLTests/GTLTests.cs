using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTLSystem.Repository;
using GTLSystem.IRepository;
using GTLSystem.Model;
using FluentAssertions;
using Moq;

namespace GTLTests
{
    [TestClass]
    public class GTLTests
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
            //Arrange
            DbConnection connection = new DbConnection();
            string wrongInput = "XXX";
            TitleRepository titleRepository = new TitleRepository(connection);

            //Act
            Title title = titleRepository.GetByISBN(wrongInput);

            //Assert
            title.Should().BeNull();

        }

        [TestMethod]
        public void Test_Insert()
        {
            var titleRepoMock = new Mock<IMember>();

            titleRepoMock.Setup(x => x.GetAllMembers()).Returns
        }

        private
    }
}
