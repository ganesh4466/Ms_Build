using System;

namespace Calculator.Exceptions
{
    public class CalculatorException : Exception
    {
        public string Operation { get; }
        public double[] Operands { get; }

        public CalculatorException(string message, string operation, params double[] operands) 
            : base(message)
        {
            Operation = operation;
            Operands = operands;
        }

        public CalculatorException(string message, Exception innerException, string operation, params double[] operands) 
            : base(message, innerException)
        {
            Operation = operation;
            Operands = operands;
        }
    }
}