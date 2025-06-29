using NUnit.Framework;

namespace Nunit.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 3;
        int expected = 8;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int a = 10;
        int b = 5;
        int expected = 5;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int a = 3;
        int b = 4;
        int expected = 12;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void IsEven_EvenNumber_ReturnsTrue()
    {
        // Arrange
        int number = 4;

        // Act
        bool result = _calculator.IsEven(number);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsEven_OddNumber_ReturnsFalse()
    {
        // Arrange
        int number = 3;

        // Act
        bool result = _calculator.IsEven(number);

        // Assert
        Assert.IsFalse(result);
    }
}
