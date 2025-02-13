

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("1,2", 3)]
    [InlineData("0,4", 4)]
    [InlineData("1,9", 10)]
    [InlineData("1,9,6,0,7,9,9", 41)]
    [InlineData("1\n9,6,0,7\n9\n9", 41)]
    [InlineData("//#\n1#2#3", 6)]
    [InlineData("//#\n1#2,3\n1", 7)]
    [InlineData("-1", null)]
    public void SingleDigit(string numbers, int expected)
    {
        var calculator = new Calculator();

        if (expected == null)
        {
            Assert.Throws<InvalidOperationException>(() => calculator.Add(numbers));
        }

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
