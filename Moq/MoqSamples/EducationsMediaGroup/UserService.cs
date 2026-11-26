using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducationsMediaGroup
{
    public interface IUserService {
        void CreateUser(string UserName);
        void GetUserById(int Id);
        void DoSomething(string param);
        Task DoSomethingAsync(string param);
        int GetSomething(string param);
        void DoSomething(ref string param);
        void DoSomethingV2(out string param);
        void DoSomeThingWithDefaultValue(string operation = "DEFAULT_OPERATION", string offset = "offset");
        Task DoSomethingAsync(string operation, CancellationToken cancellationToken);
    }
    public class UserService : IUserService
    {
        public void CreateUser(string UserName)
        { 
        
        }

        public void GetUserById(int Id)
        { 
        
        }

        public void DoSomething(string param)
        { 
            
        }

        public async Task DoSomethingAsync(string param)
        { 
        
        }

        public int GetSomething(string param)
        {
            return 1;
        }

        public void DoSomething(ref string param)
        {

        }

        public void DoSomethingV2(out string param)
        {
            param = "";
        }

        public void DoSomeThingWithDefaultValue(string operation = "DEFAULT_OPERATION", string offset = "offset")
        { 
            
        }

        public async Task DoSomethingAsync(string operation, CancellationToken cancellationToken)
        { 
        
        }
    }
}
