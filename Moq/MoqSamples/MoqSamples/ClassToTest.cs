using System;
using System.Collections.Generic;
using System.Text;

namespace MoqSamples
{
    public class ClassToTest
    {
        public string GetPrefixedValue(IMockTarget provider)
        {
            return "Prefixed:" + provider.PropertyToMock;
        }
    }
}
