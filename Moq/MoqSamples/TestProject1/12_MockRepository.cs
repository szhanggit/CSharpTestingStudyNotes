using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/mock-repository
     */
    public class _12_MockRepository
    {
        [Fact]
        public void Test0()
        {
            var repository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };
            var mockFoo = repository.Create<IFoo>();
            var mockBar = repository.Create<IBar>(MockBehavior.Loose);
            repository.Verify();
        }
    }
}
