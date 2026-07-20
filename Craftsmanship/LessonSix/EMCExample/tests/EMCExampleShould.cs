using FluentAssertions;

public class EMCExampleShould
{
    [Fact]
    public void Return_When_Given()
    {
        var emcService = new EmcService();
        
        var result = emcService.Add(1, 2);

        result.Should().Be("12");
    }
}

public class EmcService
{
    public string Add(int i, int i1)
    {
        var partOne = i.ToString();
        var partTwo = i1.ToString();
        return AddNew(partOne, partTwo);
    }

    public string AddNew(string partOne, string partTwo)
    {
        return partOne + partTwo;
    }
}
