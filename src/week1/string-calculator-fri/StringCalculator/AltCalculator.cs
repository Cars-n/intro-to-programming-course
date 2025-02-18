
using StringCalculator;

public class AltCalculator(ICalculatorOutput _output)
{
    public int Add(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }

        var result = numbers.Split(',', '\n').Select(int.Parse).Sum();
        _output.WriteLine("The result is " + result.ToString());
        return result;
    }
}