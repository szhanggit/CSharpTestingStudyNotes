using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        #region For Shared Context
        public Guid SharedContextDemoProp { get; set; }
        public Calculator()
        {
            SharedContextDemoProp = Guid.NewGuid();
        }
        #endregion

        // Add and returns the sum
        public double Add(params double[] numbers)
        {
            double sum = 0;
            foreach (double num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        // Multiply and retuns the result
        public double Multiply(params double[] numbers)
        {
            double mul = 1;
            foreach (double num in numbers)
            {
                mul *= num;
            }
            return mul;
        }

        // Subtracts small number from big number
        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        // Subtracts small number from big number
        public double Divide(double divident, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException($"Divident {divident} cannot be devided by 0");
            }
            return divident / divisor;
        }
    }
}
