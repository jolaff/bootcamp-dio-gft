using Xunit;
using CalculatorService.Services;

namespace Calculator.UnitTests.Services;

public class CalculatorServiceTests
{
    private readonly CalculatorServices _calculatorServices;

    public CalculatorServiceTests()
    {
        _calculatorServices = new CalculatorServices();
    }

    #region Sum Tests

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void Sum_TwoInt_ReturnInt(int x, int y, int expectedValue)
    {
        // Act
        var result = _calculatorServices.Sum(x, y);

        // Assert
        Assert.Equal(expectedValue, result);
    }

    #endregion

    #region Subtraction Tests

    [Theory]
    [InlineData(2, 2, 0)]
    [InlineData(10, 4, 6)]
    public void Subtract_TwoInt_ReturnInt(int x, int y, int expectedValue)
    {
        // Act
        var result = _calculatorServices.Subtract(x, y);

        // Assert
        Assert.Equal(expectedValue, result);
    }

    #endregion

    #region Multiplication Tests

    [Theory]
    [InlineData(0, 5)]
    [InlineData(5, 0)]
    public void Multiplication_ByZero_ReturnZero(int x, int y)
    {
        // Act
        var result = _calculatorServices.Multiplication(x, y);

        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(3, 3, 9)]
    [InlineData(4, 4, 16)]
    public void Multiplication_TwoInt_ReturnInt(int x, int y, int expectedValue)
    {
        // Act
        var result = _calculatorServices.Multiplication(x, y);

        // Assert
        Assert.Equal(expectedValue, result);
    }

    #endregion

    #region Division Tests

    [Fact]
    public void Division_ByZero_ReturnException()
    {
        // Act
        var exception = Record.Exception(() => _calculatorServices.Division(12, 0));

        // Assert
        Assert.IsType<System.DivideByZeroException>(exception);
    }

    [Theory]
    [InlineData(12, 4, 3)]
    [InlineData(25, 5, 5)]
    public void Division_TwoInt_ReturnInt(int x, int y, int expectedValue)
    {
        // Act
        var result = _calculatorServices.Division(x, y);

        // Assert
        Assert.Equal(expectedValue, result);
    }

    #endregion
}
