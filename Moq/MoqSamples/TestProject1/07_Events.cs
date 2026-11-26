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
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/events
     */
    public class _07_Events
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.Send(It.IsAny<string>()))
                .Raises(e => e.Sent += null, (string msg) => new MessageEventArgs { Message = msg });
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IService>();
            var service = mock.Object;
            service.Sent += (object sender, MessageEventArgs args) => Console.WriteLine(args.Message);
            service.Send("Hello World");
        }

        [Fact]
        public void Test2()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.Receive()).Returns("Hello").Raises(e => e.Received += null, (string msg) => new MessageEventArgs { Message = msg });
        }

        [Fact]
        public void Test3()
        {
            var mock = new Mock<IService>();
            mock.Setup(p => p.SendAsync(It.IsAny<string>())).Returns(Task.CompletedTask).Raises(e => e.Sent += null, (string message) => new MessageEventArgs { Message = message });
            mock.Setup(p => p.ReceiveAsync()).ReturnsAsync("Hello").Raises(e => e.Received += null, (string msg) => new MessageEventArgs { Message = msg });
        }

        [Fact]
        public void Test4()
        {
            var mock = new Mock<IService>();
            mock.Raise(p => p.Sent += null, new MessageEventArgs { Message = "Hello world" });
        }
    }
}
