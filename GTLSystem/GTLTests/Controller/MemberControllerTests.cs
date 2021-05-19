using GTLSystem.Controller;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTLSystem.Repository;
using GTLSystem.IRepository;
using GTLSystem.Model;
using FluentAssertions;
using Autofac.Extras.Moq;
using Moq;

namespace GTLSystem.Controller.Tests
{
    [TestClass()]
    public class MemberControllerTests
    {
        [TestMethod()]
        public void CheckCorrectSSNTest()
        {
            //Arrange
            string ssn = "ssn";
            var mock = AutoMock.GetLoose();

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetBySSN(ssn)).Returns(GetSampleMember);

            var ctrl = mock.Create<MemberController>();

            //Act
            var result = ctrl.CheckSSN(ssn);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod()]
        public void CheckIncorrectSSNTest()
        {
            //Arrange
            string ssn = "wrongssn";
            var mock = AutoMock.GetLoose();

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetBySSN(ssn)).Returns(GetSampleNullMember);

            var ctrl = mock.Create<MemberController>();

            //Act
            var result = ctrl.CheckSSN(ssn);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod()]
        public void GetAllMembersTest()
        {
            //Arrange
            var mock = AutoMock.GetLoose();

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetAllMembers()).Returns(GetSampleMembers());

            var ctrl = mock.Create<MemberController>();

            //Act
            var result = ctrl.GetAllMembers();

            //Assert
            result.Should().BeEquivalentTo(GetSampleMembers());
        }

        [TestMethod()]
        public void GetBySSNTest()
        {
            //Arrange
            string ssn = "ssn";
            var mock = AutoMock.GetLoose();

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetBySSN(ssn)).Returns(GetSampleMember());

            var ctrl = mock.Create<MemberController>();

            //Act
            var result = ctrl.GetBySSN(ssn);

            //Assert
            result.Should().BeEquivalentTo(GetSampleMember());
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

        private Member GetSampleMember()
        {
            return new Member
            {
                SSN = "test",
                Campus = "testcampus",
                Address = "testaddress",
                PhoneNumber = "testphone",
                CardExpDate = DateTime.MinValue
            };
        }

        private Member GetSampleNullMember()
        {
            return null;
        }
    }
}