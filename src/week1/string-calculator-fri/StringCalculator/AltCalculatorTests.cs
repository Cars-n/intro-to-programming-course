

namespace StringCalculator;
public class AltCalculatorTests
{
    [Theory]
    [InlineData("1,2,3")]
    public void CallsLoggerWithResult(string numbers)
    {
        var mockedOutput = Substitute.For<ICalculatorOutput>();
        var calculator = new AltCalculator(mockedOutput);

        calculator.Add(numbers);

        // Assert??
        mockedOutput.Received(1).WriteLine("The result is 6");
    }
}
