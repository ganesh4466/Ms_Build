using System;

namespace Calculator.Operations
{
    public class BasicOperations : ICalculatorOperation
    {
        public string OperationName => "Basic Operations";

        public double Execute(params double[] operands)
        {
            if (operands.Length < 2)
                throw new ArgumentException("At least two operands required");

            return 0; // Base implementation
        }

        public double Add(double a, double b) => a + b;

        public double Subtract(double a, double b) => a - b;

        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (Math.Abs(b) < double.Epsilon)
                throw new DivideByZeroException("Cannot divide by zero");
            return a / b;
        }

        public double Power(double baseValue, double exponent)
        {
            if (baseValue < 0 && Math.Abs(exponent % 1) > double.Epsilon)
                throw new ArgumentException("Negative base with fractional exponent is not supported");
            return Math.Pow(baseValue, exponent);
        }
    }
}