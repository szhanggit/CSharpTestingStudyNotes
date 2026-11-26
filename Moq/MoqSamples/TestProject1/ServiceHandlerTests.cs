using Greeter1;
using GrpcServiceCaller;
using Moq;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    public class ServiceHandlerTests
    {
        ITestOutputHelper _helper;
        public ServiceHandlerTests(ITestOutputHelper helper)
        {
            _helper = helper;
        }

        /// <summary>
        /// This is a unit test which accepts name and expected string as paraeters
        /// </summary>
        /// <param name="name">Any string to create object of HelloRequest</param>
        /// <param name="expected">expected output of Greeter service when HelloRequst is provided.</param>
        [Theory]
        [InlineData("James", "Hello James")]
        [InlineData("Tony", "Hello Tony")]
        public void GetGreetMessage_WhenNameIsSupplied_ShouldReturnGreetMessage(string name, string expected)
        {
            //Arrange
            //=========
            //STEP1 -> create mock object of gRPC client using MOQ
            var mockClient = new Mock<Greeter.GreeterClient>();

            //STEP2 -> setup behaviour of gRPC client.
            mockClient
                .Setup(m => m.SayHello(new HelloRequest { Name = name }, null, null, CancellationToken.None))
                .Returns(new HelloReply { Message = expected });

            //Act
            //=========
            //STEP3 -> Create instance of the type which has unit to be tested
            //and pass gRPC's mock object as dependency.
            //Also, call the method to receive actual output.
            ServiceHandler s = new ServiceHandler(mockClient.Object);
            string actual = s.GetGreetMessage(name);

            //Asset
            //=========
            //STEP4 -> check expected and actual outpus
            _helper.WriteLine($"expected={expected} actual={actual}");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

            //STEP5 -> While unit testing, mocking is not complete until
            //all the mocked dependencie's invocations have been verified.
            mockClient.Verify(x => x.SayHello(It.IsAny<HelloRequest>(), null, null, CancellationToken.None));
        }

        /// <summary>
        /// This is a unit test which accepts name and expected string as paraeters
        /// </summary>
        /// <param name="name">Any string to create object of HelloRequest</param>
        /// <param name="expected">expected output of Greeter service when HelloRequst is provided.</param>
        [Theory]
        [InlineData("James", "Hello James")]
        [InlineData("Tony", "Hello Tony")]
        public void GetGreetMessageWithNormalClient_WhenNameIsSupplied_ShouldReturnGreetMessage(string name, string expected)
        {
            //Arrange
            //=========
            //STEP1 -> create mock object of gRPC client using MOQ
            var mockClient = new Mock<Greeter.GreeterClient>();

            //STEP2 -> setup behaviour of gRPC client.
            mockClient
                .Setup(m => m.SayHello(new HelloRequest { Name = name }, null, null, CancellationToken.None))
                .Returns(new HelloReply { Message = expected });

            //Act
            //=========
            //STEP3 -> Create instance of the type which has unit to be tested
            //and pass gRPC's mock object as dependency.
            //Also, call the method to receive actual output.
            ServiceHandler s = new ServiceHandler(null);
            string actual = s.GetGreetMessageWithNormalClient(mockClient.Object, name);

            //Asset
            //=========
            //STEP4 -> check expected and actual outpus
            _helper.WriteLine($"expected={expected} actual={actual}");
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

            //STEP5 -> While unit testing, mocking is not complete until
            //all the mocked dependencie's invocations have been verified.
            mockClient.Verify(x => x.SayHello(It.IsAny<HelloRequest>(), null, null, CancellationToken.None));
        }
    }
}
