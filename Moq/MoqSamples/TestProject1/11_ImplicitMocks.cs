using System;
using System.Collections.Generic;
using System.Text;
using Castle.Core.Logging;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/implicit-mocks
     */
    public class _11_ImplicitMocks
    {
        [Fact]
        public void Test0()
        {
            var logger = Mock.Of<ILogger>();
            //Equal to
            var mock = new Mock<ILogger>();
            var logger2 = mock.Object;
        }

        [Fact]
        public void Test1()
        {
            var logger = Mock.Of<ILogger>();
            var mock = Mock.Get(logger);
            //var mock = new Mock<HttpContextBase>();
            //var context = mock.Object;
            //var mockRequest = Mock.Get(context.Request);
        }
    }
}
