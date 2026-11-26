using Moq;
using MoqQuickStart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace TestProject1
{
    public class TestQuickStart
    {
        /*
         https://github.com/Moq/moq4/wiki/Quickstart#properties
         */
        [Fact]
        public void TestMethods()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);


            // out arguments
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);


            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);


            // access invocation arguments when returning a value
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                    .Returns((string s) => s.ToLower());
            // Multiple parameters overloads available


            // throwing when invoked with specific parameters
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));


            // lazy evaluating return value
            var count = 1;
            mock.Setup(foo => foo.GetCount()).Returns(() => count);


            // async methods (see below for more about async):
            mock.Setup(foo => foo.DoSomethingAsync().Result).Returns(true);
        }

        [Fact]
        public void TestAsyncMethods()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomethingAsync().Result).Returns(true);//It is popular.
            mock.Setup(foo => foo.DoSomethingAsync()).ReturnsAsync(true);
        }

        [Fact]
        public void TestMatchingArguments()
        {
            var mock = new Mock<IFoo>();
            // any value
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);


            // any value passed in a `ref` parameter (requires Moq 4.8 or later):
            mock.Setup(foo => foo.Submit(ref It.Ref<Bar>.IsAny)).Returns(true);


            // matching Func<int>, lazy evaluated
            mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);


            // matching ranges
            mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Moq.Range.Inclusive))).Returns(true);


            // matching regex
            mock.Setup(x => x.DoSomethingStringy(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");
        }

        [Fact]
        public void TestProperties()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.Name).Returns("bar");


            // auto-mocking hierarchies (a.k.a. recursive mocks)
            mock.Setup(foo => foo.Bar.Baz.Name).Returns("baz");

            // expects an invocation to set the value to "foo"
            mock.SetupSet(foo => foo.Name = "foo");

            // or verify the setter directly
            //mock.VerifySet(foo => foo.Name = "foo");

            // start "tracking" sets/gets to this property
            mock.SetupProperty(f => f.Name);

            // alternatively, provide a default value for the stubbed property
            mock.SetupProperty(f => f.Name, "foo");


            // Now you can do:

            IFoo foo = mock.Object;
            // Initial value was stored
            Assert.Equal("foo", foo.Name);

            // New value set which changes the initial value
            foo.Name = "bar";
            Assert.Equal("bar", foo.Name);
        }

        [Fact]
        public void TestEvents()
        {
            var mock = new Mock<IFoo>();
            // Setting up an event's `add` and `remove` accessors (requires Moq 4.13 or later):
            //mock.SetupAdd(m => m.FooEvent += It.IsAny<EventHandler>());
            //mock.SetupRemove(m => m.FooEvent -= It.IsAny<EventHandler>());


        }

        [Fact]
        public void TestCallbacks()
        {
            var mock = new Mock<IFoo>();
            var calls = 0;
            var callArgs = new List<string>();

            mock.Setup(foo => foo.DoSomething("ping"))
                .Callback(() => calls++)
                .Returns(true);

            // access invocation arguments
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Callback((string s) => callArgs.Add(s))
                .Returns(true);

            // alternate equivalent generic method syntax
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Callback<string>(s => callArgs.Add(s))
                .Returns(true);

            // access arguments for methods with multiple parameters
            mock.Setup(foo => foo.DoSomething(It.IsAny<int>(), It.IsAny<string>()))
                .Callback<int, string>((i, s) => callArgs.Add(s))
                .Returns(true);

            // callbacks can be specified before and after invocation
            mock.Setup(foo => foo.DoSomething("ping"))
                .Callback(() => Console.WriteLine("Before returns"))
                .Returns(true)
                .Callback(() => Console.WriteLine("After returns"));

            // callbacks for methods with `ref` / `out` parameters are possible but require some work (and Moq 4.8 or later):
            //delegate void SubmitCallback(ref Bar bar);

            //mock.Setup(foo => foo.Submit(ref It.Ref<Bar>.IsAny))
            //    .Callback(new SubmitCallback((ref Bar bar) => Console.WriteLine("Submitting a Bar!")));


        }

        [Fact]
        public void TestReturningDiffValues()
        {
            // returning different values on each invocation
            var mock = new Mock<IFoo>();
            var calls = 0;
            mock.Setup(foo => foo.GetCount())
                .Callback(() => calls++)
                .Returns(() => calls);
            // returns 0 on first invocation, 1 on the next, and so on
            Console.WriteLine(mock.Object.GetCount());

            // access invocation arguments and set to mock setup property
            mock.SetupProperty(foo => foo.Bar);
            //mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
            //    .Callback((string s) => mock.Object.Bar = s)
            //    .Returns(true);
        }

        [Fact]
        public void TestReturnDifferentValues()//useful
        {
            var mock = new Mock<IFoo>();
            mock.SetupSequence(f => f.GetCount())
                .Returns(3)  // will be returned on 1st invocation
                .Returns(2)  // will be returned on 2nd invocation
                .Returns(1)  // will be returned on 3rd invocation
                .Returns(0)  // will be returned on 4th invocation
                .Throws(new InvalidOperationException());  // will be thrown on 5th invocation
        }


    }
}
