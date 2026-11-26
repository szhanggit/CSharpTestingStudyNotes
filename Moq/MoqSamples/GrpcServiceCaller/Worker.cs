using Greeter1;
using Grpc.Net.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcServiceCaller
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceHandler _handler;

        public Worker(ILogger<Worker> logger, IServiceHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                string name = $"Agent {count++}";
                Console.WriteLine($"***************************\n{_handler.GetGreetMessage(name)}\n***************************");
                Greeter.GreeterClient client = GetGreeterClient();
                Console.WriteLine($"***************************\n{_handler.GetGreetMessageWithNormalClient(client, name)}\n***************************");
                await Task.Delay(1000, stoppingToken);
            }
        }

        private Greeter.GreeterClient GetGreeterClient()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var greeterClient = new Greeter.GreeterClient(channel);
            return greeterClient;
        }
    }
}
