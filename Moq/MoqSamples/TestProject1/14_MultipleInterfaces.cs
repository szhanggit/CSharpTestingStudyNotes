using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/multiple-interfaces
     */
    public class  _14_MultipleInterfaces
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IDependency>();
            mock.As<IDisposable>().Setup(p => p.Dispose());
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IDependency>();
            var mockDisposable = mock.As<IDisposable>();
            mockDisposable.Verify(p => p.Dispose(), Times.Once());
        }
    }

    public interface IDependency { }

    public class Dependency : IDependency, IDisposable
    {
        public void Dispose()
        { 
            throw new NotImplementedException();
        }
    }

    public class ServiceV2
    {
        private readonly IDependency _dependency;
        public ServiceV2(IDependency dependency) { _dependency = dependency; }
        public void DoSomething()
        {
            using (_dependency as IDisposable) { }
        }
        public void Dispose() { }
    }
}
