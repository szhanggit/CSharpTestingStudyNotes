using System;
using System.Collections.Generic;
using System.Text;

namespace MoqSamples
{
    public interface IMockTargetV2 
    {
        string PropertyToMock { get; }
    }
    public class MockTarget : IMockTargetV2
    {
        public virtual string PropertyToMock { get; private set; }
    }
}
