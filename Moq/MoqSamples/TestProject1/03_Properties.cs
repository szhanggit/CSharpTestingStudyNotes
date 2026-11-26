using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    public class _03_Properties
    {
        /*
         https://docs.educationsmediagroup.com/unit-testing-csharp/moq/properties
         */
        [Fact]
        public void Test0()
        {
            var mock = new Mock<MyAbstractClass>();
            mock.Setup(p => p.Text).Returns("Bar");
            mock.Setup(p => p.Value).Returns(123);
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<MyAbstractClass>();
            mock.SetupGet(p => p.Text);
            mock.SetupSet(p => p.Text = It.IsAny<string>());
        }

        [Fact]
        public void Test2()
        {
            var mock = new Mock<MyClass>();
            mock.SetupProperty(p => p.Text);
            var obj = mock.Object;
            obj.Text = "Hello world";
            mock.SetupProperty(p => p.Text, "Hello world");
            Assert.Equal("Hello world", obj.Text);
        }

        [Fact]
        public void Test3()
        {
            var userMock = new Mock<MyAbstractClass>().SetupAllProperties();

            userMock.Object.Text = "Hello";

            Assert.Equal("Hello", userMock.Object.Text);
        }

        [Fact]
        public void Test4()
        {
            //var mock = new Mock<HttpContextBase>();
            //mock.SetupGet(p => p.Response.Request.UserAgent).Returns("My Browser");
        }
    }
}
