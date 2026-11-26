using System;
using System.Collections;
using System.Collections.Generic;
using TestProject1;
using Xunit;
using Xunit.Abstractions;

namespace Calculator.Tests
{
    [Collection("Calculator collection")]
    public class CalculatorTestsWithSharedContext
    {
        private CalculatorFixture _calFixture;
        private ITestOutputHelper _output;
        private Calculator _cal;
        public CalculatorTestsWithSharedContext(CalculatorFixture calFixture, ITestOutputHelper output)
        {
            _calFixture = calFixture;
            _output = output;
            _cal = calFixture.CalcObject;
        }

        #region Test Methods
        [Fact]
        public void Add_WhenMultipleNumbersProvided_ShouldReturnSum()
        {
            _output.WriteLine($"Shared context proof - {_cal.SharedContextDemoProp}");
            //Arrange - Prepare data for test
            double[] numbersToAdd = { 10, 20, 30, 40 };
            double expectedResult = 100;

            //Act - Actual execution of unit   
            double actualResult = _cal.Add(numbersToAdd);

            //Assert - Result of unit test
            Assert.Equal(expectedResult, actualResult);
        }

        //Demo of test method with Theory and InlineData attribute
        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(10, 10, 0)]
        [InlineData(10, 30, -20)]
        public void Subtract_WhenTwoNumbersProvided_ShouldReturnRemainingValue(double num1, double num2, double expectedResult)
        {
            _output.WriteLine($"Shared context proof - {_cal.SharedContextDemoProp}");
            //Arrange - Prepare data for test

            //Act - Actual execution of unit
            double actualResult = _cal.Subtract(num1, num2);

            //Assert - Result of unit test
            Assert.Equal(expectedResult, actualResult);
        }
        #endregion
    }

    [Collection("Calculator collection")]
    public class CalculatorTestsWithSharedContext2
    {
        private CalculatorFixture _calFixture;
        private Calculator _cal;
        private ITestOutputHelper _output;
        public CalculatorTestsWithSharedContext2(CalculatorFixture calFixture, ITestOutputHelper output)
        {
            _calFixture = calFixture;
            _cal = calFixture.CalcObject;
            _output = output;
        }

        #region Test Methods
        [Fact]
        public void Multiply_WhenMultipleNumbersProvided_ShouldReturnMultipliedResult()
        {
            _output.WriteLine($"Shared context proof - {_cal.SharedContextDemoProp}");
            //Arrange - Prepare data for test
            double[] numbersToAdd = { 5, 10, 100 };
            double expectedResult = 5000;

            //Act - Actual execution of unit

            double actualResult = _cal.Multiply(numbersToAdd);

            //Assert - Result of unit test
            Assert.Equal(expectedResult, actualResult);
        }
        #endregion
    }

    #region Supporting Classes
    /*public class CalculatorFixture : IDisposable
    {
        public Calculator CalcObject { get; private set; }

        public CalculatorFixture()
        {
            CalcObject = new Calculator();
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
    }*/
    #endregion
}
