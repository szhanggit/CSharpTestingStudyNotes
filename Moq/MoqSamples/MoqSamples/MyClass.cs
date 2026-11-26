using System;
using System.Collections.Generic;
using System.Text;

namespace MoqSamples
{
    public abstract class MyAbstractClass
    {
        protected abstract int MyProtectedGetIntMethod();
    }

    public class MyClass : MyAbstractClass
    {
        protected override int MyProtectedGetIntMethod()
        {
            return 1;
        }
    }
}
