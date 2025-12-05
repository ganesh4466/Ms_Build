using Calculator.Exceptions;
using Calculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Calculator
    {
        private readonly Dictionary<string, ICalculatorOperation> _operations;
        private readonly BasicOperations _basicOperations;
        private readonly AdvancedOperations _advancedOperations;

        public Calculator()
        {
            _basicOperations = new BasicOperations();
            _advancedOperations = new AdvancedOperations();
            
            _operations = new Dictionary<string, ICalculatorOperation>
            {
                ["add"] = _basicOperations,
                ["subtract"] = _basicOperations,
                ["multiply"] = _basicOperations,
                ["divide"] = _basicOperations,
                ["power"] = _basicOperations,
                ["sqrt"] = _advancedOperations,
                ["factorial"] = _advancedOperations,
                ["log"] = _advancedOperations
            };
        }

        public double Calculate(string operation, params double[] operands)
        {
            if (!_operations.ContainsKey(operation.ToLower()))
                throw new CalculatorException($"Operation '{operation}' is not supported", operation, operands);

            try
            {
                return operation.ToLower() switch
                {
                    "add" => _basicOperations.Add(operands[0], operands[1]),
                    "subtract" => _basicOperations.Subtract(operands[0], operands[1]),
                    "multiply" => _basicOperations.Multiply(operands[0], operands[1]),
                    "divide" => _basicOperations.Divide(operands[0], operands[1]),
                    "power" => _basicOperations.Power(operands[0], operands[1]),
                    "sqrt" => _advancedOperations.SquareRoot(operands[0]),
                    "factorial" => _advancedOperations.Factorial((int)operands[0]),
                    "log" => operands.Length == 1 
                        ? _advancedOperations.Logarithm(operands[0])
                        : _advancedOperations.Logarithm(operands[0], operands[1]),
                    _ => throw new CalculatorException($"Unhandled operation: {operation}", operation, operands)
                };
            }
            catch (Exception ex) when (ex is not CalculatorException)
            {
                throw new CalculatorException($"Error performing {operation}: {ex.Message}", ex, operation, operands);
            }
        }

        public IEnumerable<string> GetAvailableOperations()
        {
            return _operations.Keys.OrderBy(k => k);
        }
    }
}