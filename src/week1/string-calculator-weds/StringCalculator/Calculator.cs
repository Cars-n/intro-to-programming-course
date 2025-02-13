
using System.Text.RegularExpressions;
using Xunit.Sdk;

public class Calculator
{
    public int Add(string numbers)
    {
        if (Regex.IsMatch("[^0-9]")) {
            throw new InvalidOperationException("Numbers cannot be negative."); ;
        }
        string numbersCleaned = Regex.Replace(numbers, "[^0-9]", "");
        int totalSum = 0;
        for (int i = 0; i < numbersCleaned.Length; i++)
        {
            totalSum += numbersCleaned[i] - '0';
        }
        return totalSum;
    }
}
