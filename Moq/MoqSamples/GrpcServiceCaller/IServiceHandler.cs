using Greeter1;

namespace GrpcServiceCaller
{
    public interface IServiceHandler
    {
        public string GetGreetMessage(string name);
        public string GetGreetMessageWithNormalClient(Greeter.GreeterClient client, string name);
    }
}
