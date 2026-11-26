using EducationsMediaGroup;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1
{
    /*https://docs.educationsmediagroup.com/unit-testing-csharp/moq/quick-glance-at-moq*/
    public class _00_QuickGlanceAtMoq
    {
        [Fact]
        public void Ping_invokes_DoSomething()
        {
            // ARRANGE
            var mock = new Mock<IFoo>();
            mock.Setup(p => p.DoSomething(It.IsAny<string>())).Returns(true);
            var sut = new Service(mock.Object);

            // ACT
            sut.Ping();

            // ASSERT
            mock.Verify(p => p.DoSomething("PING"), Times.Once());
            /*
                Finally, we can use the Verify method to verify that the expected call had actually happened. 
                In this example, we verify that DoSomething was invoked exactly once with the string "PING" as parameter.             
             */
        }
    }
}
