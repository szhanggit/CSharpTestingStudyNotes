using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/verifications
     */
    public class _08_Verifications
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.Send(It.IsAny<string>())).Verifiable();
            mock.VerifyAll();
            mock.Setup(p => p.Send(It.IsAny<string>())).Verifiable("Send was never invoked");
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.Send(It.IsAny<string>()));
            mock.Verify(p => p.Send(It.IsAny<string>()));

            mock.Verify(p => p.Send(It.IsAny<string>()), "Send was never invoked");
            mock.Verify(p => p.Send(It.IsAny<string>()), Times.AtLeastOnce());
            mock.Verify(p => p.Send(It.IsAny<string>()), Times.AtLeastOnce(), "Send was never invoked");
            mock.Verify(p => p.Send(It.IsAny<string>()), () => Times.AtLeastOnce(), "Send was never invoked");
        }

        [Fact]
        public void Test2()
        {
            var mock = new Mock<IService>();
            mock.SetupProperty(p => p.ContentType, "text/plain").Verify();
            mock.SetupGet(p => p.ContentType).Returns("text/plain").Verifiable();
            mock.SetupSet(p => p.ContentType = It.IsAny<string>()).Verifiable();

            mock.VerifyGet(p => p.ContentType, Times.Once());
            mock.VerifySet(p => p.ContentType = "text/plain", Times.Once());
        }

        [Fact]
        public void Test3()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.Send(It.IsAny<string>()));
            mock.Verify(p => p.Send("Hello world"), Times.Once());
            mock.Setup(p => p.Send("Hello world")).Verifiable();
            mock.VerifyAll();
            mock.Setup(p => p.Send(It.IsAny<string>())).Verifiable();
            mock.VerifyAll();
            mock.Setup(p => p.Send("Hello world"));
            mock.Verify(p => p.Send("Hello world"), Times.Once());
        }

        [Fact]
        public void Test4()
        {
            var mock = new Mock<IService>();
            mock.VerifyAdd(p => p.Sent += It.IsAny<EventHandler<MessageEventArgs>>());
            mock.VerifyRemove(p => p.Sent -= It.IsAny<EventHandler<MessageEventArgs>>());
        }
    }
}
