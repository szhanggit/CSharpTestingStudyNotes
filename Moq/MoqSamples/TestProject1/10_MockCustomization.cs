using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/mock-customization
     */
    public class _10_MockCustomization
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IService>(MockBehavior.Strict);
            var mock1 = new Mock<IService> { DefaultValue = DefaultValue.Empty };
            var mock2 = new Mock<IService> { DefaultValue = DefaultValue.Mock };
        }
    }
}
