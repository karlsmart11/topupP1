﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTLSystem.Repository;
using GTLSystem.Model;
using FluentAssertions;
using Autofac.Extras.Moq;

namespace GTLTests
{
    [TestClass]
    public class GTLTests
    {
        [TestMethod]
        public void Test_Title_Get_By_Correct_ISBN()
        {
            //Arrange
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

            TitleRepository titleRepository = new TitleRepository();

            //Act
            Title title = titleRepository.GetByISBN(input);

            //Assert
            title.Should().BeEquivalentTo(model);
        }

        [TestMethod]
        public void Test_Title_Get_By_Incorrect_ISBN()
        {
            using (var mock = AutoMock.GetLoose());

            //Arrange
            string wrongInput = "XXX";
            TitleRepository titleRepository = new TitleRepository();

            //Act
            Title title = titleRepository.GetByISBN(wrongInput);

            //Assert
            title.Should().BeNull();

        }
    }
}
