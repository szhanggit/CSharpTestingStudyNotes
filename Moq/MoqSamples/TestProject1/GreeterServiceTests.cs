using Greeter1;
using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestGrpcService;
using TestGrpcService.Services;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1
{
    public class GreeterServiceTests
    {
        private ITestOutputHelper _output;
        public GreeterServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        /// <summary>
        /// This test method tests server side gRPC service implementation
        /// </summary>
        [Fact]
        public void SayHello_WhenNameProvided_ShouldReturnGreetingMessage()
        {
            //Arrange
            //========
            //STEP1 -> Create mock objects for dependencies 
            var mocLogger = new Mock<ILogger<GreeterService>>();
            var mocServiceHelper = new Mock<IServiceHelper>();

            //STEP2 -> Arrange test data
            string name = "Kiran";
            string message = $"Hello {name}";
            var expected = new HelloReply { Message = message };
            var request = new HelloRequest { Name = name };

            //STEP3-> Create mock object of ServerCallContext using Grpc.Core.Test.TestServerCallContext class 
            var context = TestServerCallContext.Create(
                                    method: nameof(GreeterService.SayHello)
                                    , host: "localhost"
                                    , deadline: DateTime.Now.AddMinutes(30)
                                    , requestHeaders: new Metadata()
                                    , cancellationToken: CancellationToken.None
                                    , peer: "localhost:5001"
                                    , authContext: null
                                    , contextPropagationToken: null
                                    , writeHeadersFunc: (metadata) => Task.CompletedTask
                                    , writeOptionsGetter: () => new WriteOptions()
                                    , writeOptionsSetter: (writeOptions) => { }
                                    );

            //STEP5-> Setup method call in moc object
            mocServiceHelper.Setup(x => x.MessageCreator(name)).Returns(message);

            //Act
            //======
            //STEP6-> create instance of class and call the method to be tested
            var sut = new GreeterService(mocServiceHelper.Object, mocLogger.Object);
            var actual = sut.SayHello(request, context);

            //Assert
            //=========

            //STEP7-> Verify expected and actual output. Also, verify if mock object called the dependent method or not.
            _output.WriteLine($"expected.Message = {expected.Message}, actual.Result.Message = {actual.Result.Message}");
            Assert.Equal(expected.Message, actual.Result.Message);
            mocServiceHelper.Verify(v => v.MessageCreator(name));
        }

        [Theory]
        [InlineData("James", "Hello James")]
        [InlineData("Tony", "Hello Tony")]
        public void GetGreetMessage_WhenAnyStringProvided_ReturnGreetMessage(string name, string expected)
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
            //ServiceHandler s = new ServiceHandler(mockClient.Object);
            //string actual = s.GetGreetMessage(name);

            //Asset
            //=========
            //STEP4 -> check expected and actual outpus
            //_helper.WriteLine($"expected={expected} actual={actual}");
            //Assert.NotNull(actual);
            //Assert.Equal(expected, actual);

            //STEP5 -> While unit testing, mocking is not complete until
            //all the mocked dependencie's invocations have been verified.
            //mockClient.Verify(x => x.SayHello(It.IsAny<HelloRequest>(), null, null, CancellationToken.None));
        }

    }
}
