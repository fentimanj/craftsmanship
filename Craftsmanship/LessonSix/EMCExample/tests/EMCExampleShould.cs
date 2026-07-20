using FluentAssertions;

public class EMCExampleShould
{
    [Fact]
    public void Return_When_Given()
    {
        var emcService = new EmcService();

        var partOne = 1.ToString();
        var partTwo = 2.ToString();
        var result = emcService.Add(partOne, partTwo);

        result.Should().Be("12");
    }
}

public class EmcService
{
    public string Add(string partOne, string partTwo)
    {
        return partOne + partTwo;
    }
}
