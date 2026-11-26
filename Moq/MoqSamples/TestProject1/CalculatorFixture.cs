using System;
using Xunit;

namespace TestProject1
{
    public class CalculatorFixture : IDisposable
    {
        public Calculator.Calculator CalcObject { get; private set; }

        public CalculatorFixture()
        {
            CalcObject = new Calculator.Calculator();
        }

        public void Dispose()
        {
            //In case of real word apps, data and object cleanup can be performed here
            CalcObject = null;
        }
    }

    [CollectionDefinition("Calculator collection")]
    public class CalculatorCollection : ICollectionFixture<CalculatorFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
