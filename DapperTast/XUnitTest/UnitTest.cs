using DapperTast.Controllers;
using Moq;
using Quote.Service.Interfaces;
using System;
using Xunit;

namespace XUnitTest
{
    public class UnitTest
    {
        Mock<IGrammarNewService> mockRepo = new Mock<IGrammarNewService>();
        GrammarNewController controller;
        public UnitTest()
        {
         
            controller = new GrammarNewController(mockRepo.Object);
        }
        [Fact]
        public void Test1()
        {
            var ccc = controller.Test();
        }
    }
}
