using Calculator.Exceptions;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorIntegrationTests
    {
        private readonly Calculator.Calculator _calculator;

        public CalculatorIntegrationTests()
        {
            _calculator = new Calculator.Calculator();
        }

        [Theory]
        [InlineData("add", 5, 3, 8)]
        [InlineData("subtract", 10, 4, 6)]
        [InlineData("multiply", 6, 7, 42)]
        [InlineData("divide", 10, 2, 5)]
        [InlineData("power", 2, 3, 8)]
        [InlineData("sqrt", 16, 4)]
        [InlineData("log", 100, 2)]
        public void Calculate_ValidOperations_ReturnsCorrectResult(string operation, double a, double b, double expected)
        {
            // Act
            var result = _calculator.Calculate(operation, a, b);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Fact]
        public void Calculate_Factorial_ValidInput_ReturnsCorrectResult()
        {
            // Act
            var result = _calculator.Calculate("factorial", 5);

            // Assert
            result.Should().Be(120);
        }

        [Fact]
        public void Calculate_UnsupportedOperation_ThrowsCalculatorException()
        {
            // Act & Assert
            _calculator.Invoking(c => c.Calculate("invalid", 1, 2))
                .Should().Throw<CalculatorException>()
                .WithMessage("Operation 'invalid' is not supported");
        }

        [Fact]
        public void Calculate_DivideByZero_ThrowsCalculatorException()
        {
            // Act & Assert
            _calculator.Invoking(c => c.Calculate("divide", 10, 0))
                .Should().Throw<CalculatorException>()
                .WithMessage("Error performing divide*");
        }

        [Fact]
        public void GetAvailableOperations_ReturnsAllOperations()
        {
            // Act
            var operations = _calculator.GetAvailableOperations();

            // Assert
            operations.Should().ContainInOrder("add", "divide", "factorial", "log", "multiply", "power", "sqrt", "subtract");
            operations.Should().HaveCount(8);
        }

        [Fact]
        public void Calculate_LogarithmWithOneParameter_UsesDefaultBase()
        {
            // Act
            var result = _calculator.Calculate("log", 100);

            // Assert
            result.Should().BeApproximately(2, 0.001);
        }

        [Fact]
        public void Calculate_LogarithmWithTwoParameters_UsesSpecifiedBase()
        {
            // Act
            var result = _calculator.Calculate("log", 8, 2);

            // Assert
            result.Should().Be(3);
        }
    }
}