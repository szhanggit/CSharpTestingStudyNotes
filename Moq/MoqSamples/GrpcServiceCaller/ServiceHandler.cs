using Greeter1;
using Grpc.Net.Client;
using GrpcServiceCaller;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServiceCaller
{
    public class ServiceHandler : IServiceHandler
    {
        private readonly Greeter.GreeterClient _client;

        public ServiceHandler(Greeter.GreeterClient client)
        {
            _client = client;
        }

        /// <summary>
        /// This method uses object of Greeter.GreeterClient to invoke SayHello method of Greeter service
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetGreetMessage(string name)
        {
            string msg = null;
            var reply = _client.SayHello(new HelloRequest { Name = name });
            if (reply != null)
            {
                msg = reply.Message;
            }
            return msg;
        }

        /// <summary>
        /// This method creates an object of Greeter.GreeterClient to invoke SayHello method of Greeter service
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetGreetMessageWithNormalClient(Greeter.GreeterClient grpcClient, string name)
        {
            string msg = null;
            var reply = grpcClient.SayHello(new HelloRequest { Name = name });
            if (reply != null)
            {
                msg = reply.Message;
            }
            return msg;
        }
    }
}
