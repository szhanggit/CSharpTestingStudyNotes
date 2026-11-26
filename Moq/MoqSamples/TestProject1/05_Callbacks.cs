using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/callbacks
     */
    public class _05_Callbacks
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.DoSomething()).Callback(() => Console.WriteLine("Here"));
            mock.Setup(p => p.DoSomethingMore(It.IsAny<int>())).Callback(() => Console.WriteLine($"Incoming call"));
            mock.Setup(p => p.DoSomethingMore(It.IsAny<int>())).Callback((int a) => Console.WriteLine($"Incoming call: {a}"));
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<MyAbstractClass>();
            mock.SetupGet(p => p.Property).Callback(() => Console.WriteLine("Getter invoked"));
            mock.SetupSet(p => p.Property = It.IsAny<string>()).Callback((string str) => Console.WriteLine($"Setter received value: {str}"));
        }

        [Fact]
        public void Test2()
        {
            int value = 0;
            var mock = new Mock<IService>();
            mock.Setup(p => p.DoSomething(It.IsAny<int>())).Callback((int x) => value = x);

            int counter = 0;
            mock.Setup(p => p.DoSomething()).Callback(() => { if (counter++ >= 5) throw new Exception(); });

            mock.SetupSequence(p => p.DoSomething())
            .Pass()
            .Pass()
            .Pass()
            .Pass()
            .Pass()
            .Throws<Exception>();
        }

        [Fact]
        public void Test3()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.DoSomething(It.IsAny<int>())).Callback((int value) =>
            {
                DoSomething();
                DoSomethingWithValue(value);
            });
        }

        private void DoSomething() { }
        private void DoSomethingWithValue(int i) { }
    }
}
