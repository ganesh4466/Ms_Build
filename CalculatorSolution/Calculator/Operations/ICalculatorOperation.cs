namespace Calculator.Operations
{
    public interface ICalculatorOperation
    {
        string OperationName { get; }
        double Execute(params double[] operands);
    }
}