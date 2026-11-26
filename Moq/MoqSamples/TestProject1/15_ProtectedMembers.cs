using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Moq.Protected;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/protected-members
     */
    public class _15_ProtectedMembers
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<ServiceBase>();
            mock.Protected().Setup("Step1").Callback(() => Console.WriteLine("Step1"));
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<ServiceBase>();
            mock.Protected().Setup("Step2", ItExpr.IsAny<string>()).Callback((string value) => Console.WriteLine($"Step2: {value}"));
        }

        [Fact]
        public void Test2()
        {
            var mock = new Mock<ServiceBase>();
            mock.Protected().SetupGet<int>("Count").Returns(42);
            mock.Protected().SetupSet<int>("Count", ItExpr.IsAny<int>()).Callback((int value) => Console.WriteLine($"Count set to {value}"));
        }


        [Fact]
        public void Test3()
        {
            var mock = new Mock<ServiceBase>();
            mock.Protected().As<IServiceBaseMapping>().Setup(p => p.Step1()).Callback(() => Console.WriteLine("Step1"));
        }

        [Fact]
        public void Test4()
        {
            var mock = new Mock<ServiceBase>();
            mock.Protected().As<IServiceBaseMapping>().Setup(p => p.Step2(It.IsAny<string>())).Callback((string value) => Console.WriteLine($"Step2: {value}"));
        }

        [Fact]
        public void Test5()
        {
            var mock = new Mock<ServiceBase>();
            mock.Protected().As<IServiceBaseMapping>().SetupProperty(p => p.Count, 42);
        }
    }

    public abstract class ServiceBase
    {
        protected abstract void Step1();
        protected abstract void Step2(string value);
        protected abstract int Count { get; set; }
        public void DoSomething(string value)
        {
            Step1();
            Step2(value);
        }
    }

    public interface IServiceBaseMapping
    {
        void Step1();
        void Step2(string value);
        int Count { get; set; }
    }
}
