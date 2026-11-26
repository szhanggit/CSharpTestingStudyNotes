using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

//Naming convention of test project -> <ProjectNameUnderTest>.Tests
namespace Calculator.Tests
{
    //Naming convention of test class -> <ClassNameUnderTest>Tests
    public class CalculatorTests
    {
        private Calculator _cal;
        public CalculatorTests()
        {
            _cal = new Calculator();
        }

        #region Test Methods
        //Demo of test method with Fact attribute
        //Naming convention of test method -> <MethodNameUnderTest>_TestScenario_ExpectedResult()
        [Fact]
        public void Add_WhenMultipleNumbersProvided_ShouldReturnSum()
        {
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
            //Arrange - Prepare data for test

            //Act - Actual execution of unit
            double actualResult = _cal.Subtract(num1, num2);

            //Assert - Result of unit test
            Assert.Equal(expectedResult, actualResult);
        }

        //Demo of test method with Theory and MemberData attribute
        [Theory]
        [MemberData(nameof(GetDataForTesting))]
        public void Multiply_WhenMultipleNumbersProvided_ShouldReturnMultipliedValue(double[] nums, double expectedResult)
        {
            //Arrange - Prepare data for test

            //Act - Actual execution of unit
            double actualResult = _cal.Multiply(nums);

            //Assert - Result of unit test
            Assert.Equal(expectedResult, actualResult);
        }

        //Demo of test method with Theory and ClassData attribute
        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void Divide_WhenTwoNonZeroNumbersProvided_ShouldReturnDivision(double num1, double num2, double expectedResult)
        {
            //Arrange - Prepare data for test

            //Act - Actual execution of unit
            double actualResult = _cal.Divide(num1, num2);

            //Assert - Result of unit test
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Divide_WhenDividedByZero_ShouldThrowException()
        {
            //Arrange - Prepare data for test
            int num1 = 5, num2 = 0;

            //Act - Actual execution of unit

            //Assert - Result of unit test
            Assert.Throws<DivideByZeroException>(() => _cal.Divide(num1, num2));
        }
        #endregion


        #region Supporting Methods
        //This is demo test data method. 
        //Rules for MemberData method are as follow:
        //Return type should be always IEnumerable<object[]>
        //It must be static
        //It must be public
        public static IEnumerable<object[]> GetDataForTesting()
        {
            yield return new object[] { new double[] { 5, 5 }, 25 };
            yield return new object[] { new double[] { 6, 5 }, 30 };
            yield return new object[] { new double[] { 7, 5 }, 35 };
        }
        #endregion

    }

    #region Supporting Classes
    //This is demo of test class
    //Rules for ClassData method are as follow:
    //It must implement IEnumerable<object[]>
    //GetEnumerator() method returning IEnumerator<object[]> should be implemented
    class DivisionTestData : IEnumerable<object[]>
    {
        //Implement this method and return data as IEnumerator<object[]>
        public IEnumerator<object[]> GetEnumerator()
        {
            //returning data with GetEnumerator
            List<object[]> testDate = new List<object[]> {
                new object[] { 5, 5, 1 },
                new object[] { 10, 5, 2 },
                new object[] { 15, 5, 3 }
            };
            return testDate.GetEnumerator();
        }

        //Ignore this method
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /*
        //returning data with yield return
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 5, 5,  1 };
            yield return new object[] { 10, 5, 2 };
            yield return new object[] { 15, 5, 3 };
        }
        */
    }
    #endregion
}
