using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGrpcService.Services
{
    public interface IServiceHelper
    {
        public string MessageCreator(string name);
    }

    public class ServiceHelper : IServiceHelper
    {
        public string MessageCreator(string name)
        {
            return $"Hello {name}";
        }
    }
}
