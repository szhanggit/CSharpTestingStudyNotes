using System;
using System.Collections.Generic;
using System.Text;
using EducationsMediaGroup;
using Moq;
using Xunit;

namespace TestProject1
{
    /*
     https://docs.educationsmediagroup.com/unit-testing-csharp/moq/custom-matchers
     */
    public class _13_CustomMatchers
    {
        [Fact]
        public void Test0()
        {
            var mock = new Mock<IService>();
            mock.Verify(p => p.DoSomething(It.Is<string>(s => s.Length > 100)));
        }

        [Fact]
        public void Test1()
        {
            var mock = new Mock<IService>();
            mock.Verify(p => p.DoSomething(ParameterExpectations.StringLongerThan(100)));
        }
    }

    public static class ParameterExpectations
    {
        [Matcher]
        public static string StringLongerThan(int size) => Moq.Match.Create<string>(s => s.Length > size);
    }    
}
