using Moq;
using MoqSamples;
using System;
using Xunit;
using Moq.Protected;
using System.Collections.Generic;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestMockProperty()
        {
            /*
             Source: https://riptutorial.com/moq
             */
            // Create and configure the mock to return a known value for the property
            var mock = new Mock<IMockTarget>();
            mock.SetupGet(x => x.PropertyToMock).Returns("FixedValue");

            // Create an instance of the class to test
            var sut = new ClassToTest();

            // Invoke the method to test, supplying the mocked instance
            var actualValue = sut.GetPrefixedValue(mock.Object);

            // Validate that the calculated value is correct
            Assert.Equal("Prefixed:FixedValue", actualValue);

            // Depending on what your method does, the mock can then be interrogated to
            // validate that the property getter was called.  In this instance, it's
            // unnecessary since we're validating it via the calculated value.
            mock.VerifyGet(x => x.PropertyToMock);
        }

        [Fact]
        public void TestProtectedMembers()
        {
            /*
             https://riptutorial.com/moq/example/27613/mocking-protected-members
             */
            var mock = new Mock<MyClass>();
            mock.Protected()
             .Setup<int>("MyProtectedGetIntMethod")
             .Returns(1);
        }

        [Fact]
        public void TestMockingVoidMethods()
        {
            /*
             https://riptutorial.com/moq/example/26784/mocking-void-methods-to-confirm-what-they-return
             */
            var logRepository = new Mock<ILogRepository>();
            logRepository.Setup(x => x.Write(It.IsAny<Exception>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            logRepository.Setup(x => x.Write(It.IsAny<Exception>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Callback<Exception, string, string, string, string, string>((ex, caller, user, machine, source, message) => { Console.WriteLine(message); });
        }

        [Fact]
        public void TestNoArgumentMethodMocking()//Useful
        {
            /*
             https://riptutorial.com/moq/example/26246/no-argument-method-mocking
             */
            var mock = new Mock<IMockable>();
            mock.Setup(x => x.DoSomething()).Returns(true);

            var result = mock.Object.DoSomething(); //true
            Assert.True(result);
        }

        [Fact]
        public void TestMockIEnumberable()
        {
            /*
             https://riptutorial.com/moq/example/23019/mocking-ienumerable
             */
            IList<DataClass> list = new List<DataClass>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new DataClass { Id = 20 + i });
            }

            var mock = new Mock<IEnumerableClass>();
            mock.Setup(x => x.GetEnumerator()).Returns(list.GetEnumerator());

            int expected = 20;
            foreach (var i in mock.Object)
            {
                Assert.Equal(expected++, i.Id);
            }
        }

        [Fact]
        public void TestAutoStubbingProperties()//Useful
        {
            /*
             https://riptutorial.com/moq/example/23014/auto-stubbing-properties
             */
            // SetupAllProperties tells mock to implement setter/getter funcationality
            var userMock = new Mock<IUser>().SetupAllProperties();

            // Invoke the code to test
            SetPropertiesOfUser(userMock.Object);

            // Validate properties have been set
            Assert.Equal(5, userMock.Object.Id);
            Assert.Equal("SomeName", userMock.Object.LastName);
        }

        void SetPropertiesOfUser(IUser user)
        {
            user.Id = 5;
            user.LastName = "SomeName";
        }

        [Fact]
        public void TestPropertiesWithPrivateSetters()
        {
            var mock = new Mock<IMockTargetV2>();
            mock.SetupGet(x => x.PropertyToMock).Returns("ExpectedValue");

            Assert.Equal("ExpectedValue", mock.Object.PropertyToMock);
        }

        [Fact]
        public void TestValidatingCallOrderImplicitly()
        {
            /*
             https://riptutorial.com/moq/example/23016/validating-call-order-implicitly
             */

            // Create mocks
            var utilityMock = new Mock<IUtility>();
            var targetMock = new Mock<ITarget>();

            // Setup expectations, note that the returns value from one call matches the expected
            // parameter for the next call in the sequence of calls we're interested in.
            utilityMock.Setup(x => x.GetInitialValue()).Returns("string");
            utilityMock.Setup(x => x.PrefixString("string")).Returns("Prefix:string");
            utilityMock.Setup(x => x.ReverseString("Prefix:string")).Returns("gnirts:xiferP");

            string expectedFinalInput = "gnirts:xiferP";

            // Invoke the method to test
            var sut = new SystemUnderTest(utilityMock.Object, targetMock.Object);
            sut.MethodToTest();

            // Validate that the final call was passed the expected value.
            targetMock.Verify(x => x.DoStuff(expectedFinalInput));
        }

        [Fact]
        public void TestValidatingCallOrderWithCallbacks()
        {
            /*
             https://riptutorial.com/moq/example/23017/validating-call-order-with-callbacks
             */

            // Create the mock (doesn't have to be in strict mode)
            var utilityMock = new Mock<IUtility>();

            // Create a variable to track the current call number
            int callOrder = 1;

            // Setup each call in the sequence to be tested.  Note that the callback validates that
            // that callOrder has the expected value, then increments it in preparation for the next
            // call.
            utilityMock.Setup(x => x.Operation1(It.IsAny<string>())).Callback(() => Assert.Equal(1, callOrder++));
            utilityMock.Setup(x => x.Operation2(It.IsAny<string>())).Callback(() => Assert.Equal(2, callOrder++));
            utilityMock.Setup(x => x.Operation3(It.IsAny<string>())).Callback(() => Assert.Equal(3, callOrder++));


            // Invoke the method to be tested
            var sut = new SystemUnderTest(utilityMock.Object);
            sut.MethodToTestV2();


            // Validate any parameters that are important, note these Verifications can occur in any
            // order.
            utilityMock.Verify(x => x.Operation2("2222"));
            utilityMock.Verify(x => x.Operation1("1111"));
            utilityMock.Verify(x => x.Operation3("3333"));
        }

        [Fact]
        public void TestValidatingCallOrderWithMockSequence()
        {
            // Create the mock, not MockBehavior.Strict tells the mock how to behave
            var utilityMock = new Mock<IUtility>(MockBehavior.Strict);

            // Create the MockSequence to validate the call order
            var sequence = new MockSequence();

            // Create the expectations, notice that the Setup is called via InSequence
            utilityMock.InSequence(sequence).Setup(x => x.Operation1(It.IsAny<string>()));
            utilityMock.InSequence(sequence).Setup(x => x.Operation2(It.IsAny<string>()));
            utilityMock.InSequence(sequence).Setup(x => x.Operation3(It.IsAny<string>()));

            // Run the method to be tested
            var sut = new SystemUnderTest(utilityMock.Object);
            sut.MethodToTestV2();

            // Verify any parameters that are cared about to the operation being orchestrated.
            // Note that the Verify calls can be in any order
            utilityMock.Verify(x => x.Operation2("2222"));
            utilityMock.Verify(x => x.Operation1("1111"));
            utilityMock.Verify(x => x.Operation3("3333"));
        }
    }
}
