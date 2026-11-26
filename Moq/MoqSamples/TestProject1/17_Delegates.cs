using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/delegates
     */
    public delegate int ParseString(string value);
    public class _17_Delegates
    {
        [Fact]
        public void Test0()
        {
            var mock1 = new Mock<ParseString>();
            var mock2 = new Mock<Func<string, int>>();
            mock2.Setup(p => p(It.IsAny<string>())).Returns(42);
            var parser = Mock.Of<ParseString>();
            var func = Mock.Of<Func<string, int>>();
        }
    }
}
