using Calculator.Operations;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests
{
    public class AdvancedOperationsTests
    {
        private readonly AdvancedOperations _advancedOperations;

        public AdvancedOperationsTests()
        {
            _advancedOperations = new AdvancedOperations();
        }

        [Theory]
        [InlineData(16, 4)]
        [InlineData(25, 5)]
        [InlineData(0, 0)]
        [InlineData(2.25, 1.5)]
        public void SquareRoot_ValidInputs_ReturnsCorrectResult(double value, double expected)
        {
            // Act
            var result = _advancedOperations.SquareRoot(value);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Fact]
        public void SquareRoot_NegativeNumber_ThrowsArgumentException()
        {
            // Act & Assert
            _advancedOperations.Invoking(a => a.SquareRoot(-1))
                .Should().Throw<ArgumentException>()
                .WithMessage("Square root of negative number is not real");
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(5, 120)]
        [InlineData(7, 5040)]
        public void Factorial_ValidInputs_ReturnsCorrectResult(int n, double expected)
        {
            // Act
            var result = _advancedOperations.Factorial(n);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Fact]
        public void Factorial_NegativeNumber_ThrowsArgumentException()
        {
            // Act & Assert
            _advancedOperations.Invoking(a => a.Factorial(-5))
                .Should().Throw<ArgumentException>()
                .WithMessage("Factorial of negative number is not defined");
        }

        [Fact]
        public void Factorial_TooLargeNumber_ThrowsArgumentException()
        {
            // Act & Assert
            _advancedOperations.Invoking(a => a.Factorial(200))
                .Should().Throw<ArgumentException>()
                .WithMessage("Value too large for factorial calculation");
        }

        [Theory]
        [InlineData(100, 10, 2)]
        [InlineData(1, 10, 0)]
        [InlineData(8, 2, 3)]
        public void Logarithm_ValidInputs_ReturnsCorrectResult(double value, double baseValue, double expected)
        {
            // Act
            var result = _advancedOperations.Logarithm(value, baseValue);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Fact]
        public void Logarithm_DefaultBase_ReturnsBase10Logarithm()
        {
            // Act
            var result = _advancedOperations.Logarithm(100);

            // Assert
            result.Should().BeApproximately(2, 0.001);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void Logarithm_NonPositiveValue_ThrowsArgumentException(double value)
        {
            // Act & Assert
            _advancedOperations.Invoking(a => a.Logarithm(value))
                .Should().Throw<ArgumentException>()
                .WithMessage("Logarithm of non-positive number is not defined");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(1)]
        public void Logarithm_InvalidBase_ThrowsArgumentException(double baseValue)
        {
            // Act & Assert
            _advancedOperations.Invoking(a => a.Logarithm(10, baseValue))
                .Should().Throw<ArgumentException>()
                .WithMessage("Logarithm base must be positive and not equal to 1");
        }

        [Fact]
        public void OperationName_ReturnsCorrectValue()
        {
            // Assert
            _advancedOperations.OperationName.Should().Be("Advanced Operations");
        }
    }
}