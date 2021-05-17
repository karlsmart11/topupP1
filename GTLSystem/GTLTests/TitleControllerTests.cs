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

namespace GTLTests
{
    [TestClass]
    public class TitleControllerTests
    {
        [TestMethod]
        public void Test_Title_Get_By_Correct_ISBN()
        {
            string input = "correct";

            using var mock = AutoMock.GetLoose();

            mock.Mock<ITitleRepository>()
                .Setup(x => x.GetByISBN(input)).Returns(GetSampleTitle());

            var ctrl = mock.Create<TitleController>();

            var obj = ctrl.GetByISBN(input);

            obj.Should().BeEquivalentTo(GetSampleTitle());
        }

        [TestMethod]
        public void Test_Title_Get_By_Incorrect_ISBN()
        {
            string input = "incorrect";

            using var mock = AutoMock.GetLoose();

            mock.Mock<ITitleRepository>()
                .Setup(x => x.GetByISBN(input)).Returns(GetSampleNullTitle);

            var ctrl = mock.Create<TitleController>();

            var obj = ctrl.GetByISBN(input);

            obj.Should().BeEquivalentTo(GetSampleNullTitle());
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
