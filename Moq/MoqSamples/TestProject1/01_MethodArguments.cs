using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/method-arguments
     */
    public class _01_MethodArguments
    {
        [Fact]
        public void Test0() 
        {
            var mock = new Mock<IUserService>();
            mock.Setup(p => p.CreateUser(It.IsAny<string>()));
            mock.Setup(p => p.CreateUser("TEST_USERNAME"));
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(p => p.CreateUser(It.IsRegex("[A-Z_]+")));
            mock.Setup(p => p.GetUserById(It.IsInRange(0, 100, Moq.Range.Exclusive)));
            mock.Setup(p => p.CreateUser(It.Is<string>(s => s.StartsWith("TEST"))));
        }
    }
}
