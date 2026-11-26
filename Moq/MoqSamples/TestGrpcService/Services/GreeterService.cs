using Greeter1;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGrpcService.Services;

namespace TestGrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IServiceHelper _service;
        public GreeterService(IServiceHelper service, ILogger<GreeterService> logger)
        {
            _logger = logger;
            _service = service;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            string message = _service.MessageCreator(request.Name);
            return Task.FromResult(new HelloReply
            {
                Message = message
            });
        }
    }
}
