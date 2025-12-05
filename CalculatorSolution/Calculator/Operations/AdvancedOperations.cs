using System;

namespace Calculator.Operations
{
    public class AdvancedOperations : ICalculatorOperation
    {
        public string OperationName => "Advanced Operations";

        public double Execute(params double[] operands)
        {
            if (operands.Length == 0)
                throw new ArgumentException("At least one operand required");

            return 0; // Base implementation
        }

        public double SquareRoot(double value)
        {
            if (value < 0)
                throw new ArgumentException("Square root of negative number is not real");
            return Math.Sqrt(value);
        }

        public double Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Factorial of negative number is not defined");
            
            if (n > 170) // Practical limit for double precision
                throw new ArgumentException("Value too large for factorial calculation");
            
            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public double Logarithm(double value, double baseValue = 10)
        {
            if (value <= 0)
                throw new ArgumentException("Logarithm of non-positive number is not defined");
            if (baseValue <= 0 || Math.Abs(baseValue - 1) < double.Epsilon)
                throw new ArgumentException("Logarithm base must be positive and not equal to 1");
            
            return Math.Log(value, baseValue);
        }
    }
}