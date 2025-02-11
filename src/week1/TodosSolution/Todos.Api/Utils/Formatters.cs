namespace Todos.Api.Utils;

public class Formatters
{
    // Method that takes two stringss and returns a string
    public static string FormatName(string firstName, string lastName)
    {
        return $"{lastName}, {firstName}";
    }
}
