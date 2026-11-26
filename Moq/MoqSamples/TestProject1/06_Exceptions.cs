using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/exceptions
     */
    public class _06_Exceptions
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.DoSomething()).Callback(() => throw new Exception());
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.DoSomething()).Throws(new Exception("My custom exception"));
            mock.Setup(p => p.DoSomethingAsync()).ThrowsAsync(new Exception("My custom exception"));
            mock.Setup(p => p.DoSomething()).Throws<Exception>();
        }

        [Fact]
        public void Test2()
        {
            var mock = new Mock<IService>();
            mock.SetupSequence(p => p.GetSomeValue()).Returns(1).Throws<Exception>();
            mock.SetupSequence(p => p.GetSomeValueAsync()).ReturnsAsync(1).ThrowsAsync(new Exception());
        }

        [Fact]
        public void Test3()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.DoSomething(It.IsAny<int>())).Throws((int value) => new Exception($"{value} is not valid"));
            mock.Setup(p => p.DoSomething(It.IsAny<int>())).Callback((int value) => throw new Exception($"{value} is not valid"));
        }
    }
}
