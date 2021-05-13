using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTLSystem.Repository;
using GTLSystem.IRepository;
using GTLSystem.Controller;
using GTLSystem.Model;
using FluentAssertions;
using Autofac.Extras.Moq;
using Moq;
using GTLSystem.IRepository;

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
            using (var mock = AutoMock.GetLoose())
            {
                //arrange
                string wrongInput = "wrongInput";
                mock.Mock<ITitle>()
                    .Setup(x => x.GetByISBN(wrongInput))
                    .Returns(GetSampleNullTitle);

                //Act
                var res = mock.Create<TitleRepository>().GetByISBN(wrongInput);

                //Assert
                res.Should().BeNull();
            }

            //Arrange
            //DbConnection connection = new DbConnection();
            //TitleRepository titleRepository = new TitleRepository(connection);
            //string wrongInput = "XXX";

            //Act
            //Title title = titleRepository.GetByISBN(wrongInput);

            //Assert
            //title.Should().BeNull();

        }

        private Title GetSampleNullTitle()
        {
            return null;
        }

        private Title GetSampleTitle()
        {
            return new Title { Author = "testAuthor",
                               Description = "testDesc",
                               Available = true,
                               ISBN = "testISBN",
                               Loanable = true,
                               Requested = false,
                               Subject = "testSubject",
                               TitleName = "testTitleName"};
        }

        [TestMethod]
        public void Test_GetAllMembers()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IMember>()
                    .Setup(x => x.GetAllMembers())
                    .Returns(GetSampleMembers());

                var ctrl = mock.Create<MemberController>();

                var test = ctrl.GetAllMembers();

                mock.Mock<IMember>()
                    .Verify(x => x.GetAllMembers(), Times.Exactly(1));
            }           
        }

        private IEnumerable<Member> GetSampleMembers()
        {
            List<Member> output = new List<Member>
            {
                new Member
                {
                    SSN = "test",
                    Campus = "testcampus",
                    Address = "testaddress",
                    PhoneNumber = "testphone",
                    CardExpDate = DateTime.MinValue
                },
                new Member
                {
                    SSN = "test2",
                    Campus = "testcampus2",
                    Address = "testaddress2",
                    PhoneNumber = "testphone2",
                    CardExpDate = DateTime.MinValue
                },
                new Member
                {
                    SSN = "test3",
                    Campus = "testcampus3",
                    Address = "testaddress3",
                    PhoneNumber = "testphone3",
                    CardExpDate = DateTime.MinValue
                }
            };
            return output;
        }
    }
}
