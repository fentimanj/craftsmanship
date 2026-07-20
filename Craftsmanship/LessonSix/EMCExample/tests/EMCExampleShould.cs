using FluentAssertions;

public class EMCExampleShould
{
    [Fact]
    public void Return_When_Given()
    {
        var emcService = new EmcService();
        
        var result = emcService.AddOld(1, 2);

        result.Should().Be("12");
    }
}

public class EmcService
{
    public string AddOld(int i, int i1)
    {
        var partOne = i.ToString();
        var partTwo = i1.ToString();
        var couple = new Couple(i, i1);
        return this.Add(partOne, partTwo);
    }

    public string Add(string partOne, string partTwo)
    {
        return partOne + partTwo;
    }
}

public class Couple
{
    public readonly string iInteger;
    public readonly string i1Integer;

    public Couple(int i, int i1)
    {
        this.iInteger = i.ToString();
        this.i1Integer = i1.ToString();
    }
}
