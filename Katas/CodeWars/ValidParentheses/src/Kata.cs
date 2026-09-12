namespace src;

public static class Kata
{
    public static bool ValidParentheses(string input)
    {
        while (input.ContainsOpenAndCloseBrackets() && input.CanStillBeProcessed() && input.StartsCorrectly())
            input = input.RemoveMatchedPairs();

        return string.IsNullOrEmpty(input);
    }
}

internal static class StringExtensions
{
    public static bool ContainsOpenAndCloseBrackets(this string input)
    {
        return input.Contains('(') && input.Contains(')');
    }

    public static bool CanStillBeProcessed(this string input)
    {
        return input.Length > 1;
    }

    public static bool StartsCorrectly(this string input)
    {
        return input[0] != ')';
    }

    public static string RemoveMatchedPairs(this string input)
    {
        const string matchedNeighbourPair = "()";
        return input.Replace(matchedNeighbourPair, string.Empty, StringComparison.InvariantCulture);
    }
}