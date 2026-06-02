namespace src;

public class Kata
{
    public static bool ValidParentheses(string input)
    {
        const string matchedNeighbourPair = "()";
        
        while (input.ContainsOpenAndCloseBrackets() && input.Length > 1 && input[0] != ')')
        {
            input = input.Replace(matchedNeighbourPair, string.Empty, StringComparison.InvariantCulture);
        }
        
        return string.IsNullOrEmpty(input);
    }
}

internal static class StringExtensions
{
    public static bool ContainsOpenAndCloseBrackets(this string input)
    {
        return input.Contains('(') && input.Contains(')');
    }
}