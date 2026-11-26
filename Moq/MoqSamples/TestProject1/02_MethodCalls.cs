using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/method-calls
     */
    public class _02_MethodCalls
    {
        public delegate void DoSomethingCallback(ref string value);
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(p => p.DoSomething(It.IsAny<string>()));
            mock.Setup(p => p.DoSomethingAsync(It.IsAny<string>()));
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IUserService>();
            mock.SetupSequence(p => p.GetSomething(It.IsAny<string>()))
                .Returns(1)
                .Returns(2)
                .Returns(3);

            mock.SetupSequence(p => p.DoSomething(It.IsAny<string>()))
                .Pass()
                .Pass()
                .Pass();
            /*
             In case the configured method has no return type, Pass can be used to configure an uneventful invocation.
             */
        }

        [Fact]
        public void Test2()
        {
            var mockFirst = new Mock<IFirstService>(MockBehavior.Strict);

            var sequence = new MockSequence();

            mockFirst.InSequence(sequence).Setup(p => p.DoWithInteger(1));
            mockFirst.InSequence(sequence).Setup(p => p.DoWithInteger(2));
        }

        [Fact]
        public void Test3()
        {
            var mockFirst = new Mock<IFirstService>(MockBehavior.Strict);

            var sequence = new MockSequence();

            mockFirst.InSequence(sequence).Setup(p => p.DoWithString(It.IsAny<string>()));
            mockFirst.InSequence(sequence).Setup(p => p.DoWithInteger(It.IsAny<int>()));
        }

        [Fact]
        public void Test4()
        {
            var mockFirst = new Mock<IFirstService>(MockBehavior.Strict);
            var mockSecond = new Mock<ISecondService>(MockBehavior.Strict);

            var sequence = new MockSequence();

            mockFirst.InSequence(sequence).Setup(p => p.DoWithInteger(1));
            mockSecond.InSequence(sequence).Setup(p => p.DoWithDate(DateTime.Today));
        }

        [Fact]
        public void Test5()
        {
            var mock = new Mock<IUserService>();
            //mock.Setup(p => p.DoSomething(It.IsAny<string>()));
            mock.Setup(p => p.DoSomething(ref It.Ref<string>.IsAny));

            var value = "This is a test value";
            mock.Setup(p => p.DoSomething(ref value));
        }

        [Fact]
        public void Test6()
        {
            var mock = new Mock<IUserService>();
            var newValue = "This is the new referenced value";
            //mock.Setup(p => p.DoSomething(It.Ref<string>.IsAny))
            //    .Callback(new DoSomethingCallback((ref string value) => value = newValue));
        }

        [Fact]
        public void Test7()
        {
            var mock = new Mock<IUserService>();
            var value = "This is the expected out value";
            mock.Setup(p => p.DoSomethingV2(out value));
        }

        [Fact]
        public void Test8()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(p => p.DoSomethingAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()));
            mock.Setup(p => p.DoSomethingAsync(It.IsAny<string>(), default));
        }

    }
}
