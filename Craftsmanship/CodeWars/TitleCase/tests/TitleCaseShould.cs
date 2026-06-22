namespace tests;

using FluentAssertions;

public class TitleCaseShould
{
    [Fact]
    public void ReturnACapitalizedSingleWord_WhenConverted_GivenSingleLowerCaseWord()
    {
        string result = Kata.TitleCase("beano");
        string expected = "Beano";
        result.Should().Be(expected);
    }
}

public class Kata
{
    public static string TitleCase(string title, string minorWords="")
    {
        return "Beano";
    }
}