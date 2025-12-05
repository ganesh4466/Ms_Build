using Calculator.Operations;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests
{
    public class BasicOperationsTests
    {
        private readonly BasicOperations _basicOperations;

        public BasicOperationsTests()
        {
            _basicOperations = new BasicOperations();
        }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(-5, -3, -8)]
        [InlineData(5.5, 2.5, 8)]
        [InlineData(0, 0, 0)]
        public void Add_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Act
            var result = _basicOperations.Add(a, b);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Theory]
        [InlineData(10, 4, 6)]
        [InlineData(-10, -4, -6)]
        [InlineData(5.5, 2.5, 3)]
        public void Subtract_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Act
            var result = _basicOperations.Subtract(a, b);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Theory]
        [InlineData(6, 7, 42)]
        [InlineData(-6, 7, -42)]
        [InlineData(2.5, 4, 10)]
        [InlineData(0, 100, 0)]
        public void Multiply_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Act
            var result = _basicOperations.Multiply(a, b);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(-10, 2, -5)]
        [InlineData(5.5, 2, 2.75)]
        public void Divide_ValidInputs_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Act
            var result = _basicOperations.Divide(a, b);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Act & Assert
            _basicOperations.Invoking(b => b.Divide(10, 0))
                .Should().Throw<DivideByZeroException>()
                .WithMessage("Cannot divide by zero");
        }

        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(5, 0, 1)]
        [InlineData(4, 0.5, 2)]
        [InlineData(9, -1, 1.0/9)]
        public void Power_ValidInputs_ReturnsCorrectResult(double baseValue, double exponent, double expected)
        {
            // Act
            var result = _basicOperations.Power(baseValue, exponent);

            // Assert
            result.Should().BeApproximately(expected, 0.001);
        }

        [Fact]
        public void Power_NegativeBaseWithFractionalExponent_ThrowsArgumentException()
        {
            // Act & Assert
            _basicOperations.Invoking(b => b.Power(-4, 0.5))
                .Should().Throw<ArgumentException>()
                .WithMessage("Negative base with fractional exponent is not supported");
        }

        [Fact]
        public void OperationName_ReturnsCorrectValue()
        {
            // Assert
            _basicOperations.OperationName.Should().Be("Basic Operations");
        }
    }
}