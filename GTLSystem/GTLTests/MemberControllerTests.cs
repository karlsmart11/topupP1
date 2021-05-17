using Autofac.Extras.Moq;
using GTLSystem.Controller;
using GTLSystem.IRepository;
using GTLSystem.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTLTests
{
    class MemberControllerTests
    {
        [TestMethod]
        public void Test_GetAllMembers()
        {
            using var mock = AutoMock.GetLoose();

            mock.Mock<IMemberRepository>()
                .Setup(x => x.GetAllMembers()).Returns(GetSampleMembers());

            var ctrl = mock.Create<MemberController>();

            ctrl.GetAllMembers();

            mock.Mock<IMemberRepository>()
                .Verify(x => x.GetAllMembers(), Times.Exactly(1));
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
