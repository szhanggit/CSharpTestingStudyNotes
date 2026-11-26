using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/results
     */
    public class _04_Results
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<MyAbstractClass>();
            mock.Setup(p => p.Property).Returns("Hello world");
            mock.Setup(p => p.GetRandomNumber()).Returns(123);
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<MyAbstractClass>();
            mock.Setup(p => p.GetValueAsync()).Returns(Task.FromResult(123));
            mock.Setup(p => p.GetValueAsync()).ReturnsAsync(123);
        }

        [Fact]
        public void Test2()
        {
            var mock = new Mock<MyAbstractClass>();
            mock.Setup(p => p.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int first, int second) => first + second);

            mock.Setup(p => p.AddAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((int first, int second) => first + second);
        }

        [Fact]
        public void Test3()
        {
            var mock = new Mock<MyAbstractClass>();
            mock.Setup(p => p.Property).Returns(null as string);
        }
    }
}
