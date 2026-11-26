using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/generic-methods
     */
    public class _16_GenericMethods
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IServiceV3>();
            mock.Setup(p => p.DoSomething(It.IsAny<It.IsAnyType>())).Callback((object value) => Console.WriteLine($"DoSomething: {value}"));
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IServiceV3>();
            mock.Setup(p => p.DoSomething(It.IsAny<It.IsSubtype<IList<string>>>())).Callback((IList<string> items) => Console.WriteLine($"Received list of {items.Count} strings"));
            mock.Setup(p => p.DoSomething(It.IsAny<It.IsSubtype<IList<int>>>())).Throws<ArgumentException>();
        }
    }

    public interface IServiceV3
    {
        void DoSomething<T>(T argument);
    }
}
