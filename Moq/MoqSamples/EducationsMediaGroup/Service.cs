using System;
using System.Collections.Generic;
using System.Text;

namespace EducationsMediaGroup
{
    public interface IFoo
    {
        bool DoSomething(string command);
    }
    public interface IBar
    { 
    
    }
    public class Service
    {
        private readonly IFoo _foo;

        public Service(IFoo foo)
        {
            _foo = foo ?? throw new ArgumentNullException(nameof(foo));
        }

        public void Ping()
        {
            _foo.DoSomething("PING");
        }
    }
}
