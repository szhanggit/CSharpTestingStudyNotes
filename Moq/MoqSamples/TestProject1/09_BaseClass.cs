using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/base-class
     */
    public class _09_BaseClass
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<Person>("John");
            mock.Setup(p => p.Greet()).CallBase();
            var mock2 = new Mock<Person> { CallBase = true };
        }
    }
}
