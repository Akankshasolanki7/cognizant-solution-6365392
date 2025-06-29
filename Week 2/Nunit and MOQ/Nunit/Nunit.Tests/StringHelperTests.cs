using NUnit.Framework;

namespace Nunit.Tests;

[TestFixture]
public class StringHelperTests
{
    private StringHelper _stringHelper;

    [SetUp]
    public void Setup()
    {
        _stringHelper = new StringHelper();
    }

    [Test]
    public void Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "hello";
        string expected = "olleh";

        // Act
        string result = _stringHelper.Reverse(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CountWords_SimpleString_ReturnsCorrectCount()
    {
        // Arrange
        string input = "Hello world";
        int expected = 2;

        // Act
        int result = _stringHelper.CountWords(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void IsPalindrome_ValidPalindrome_ReturnsTrue()
    {
        // Arrange
        string input = "racecar";

        // Act
        bool result = _stringHelper.IsPalindrome(input);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsPalindrome_NotPalindrome_ReturnsFalse()
    {
        // Arrange
        string input = "hello";

        // Act
        bool result = _stringHelper.IsPalindrome(input);

        // Assert
        Assert.IsFalse(result);
    }
}
