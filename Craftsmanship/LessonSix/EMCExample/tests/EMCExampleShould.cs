using FluentAssertions;

public class EMCExampleShould
{
    [Fact]
    public void Return_When_Given()
    {
        var emcService = new EmcService();

        var couple = new Couple(1, 2);
        var result = emcService.Add(couple);

        result.Should().Be("12");
    }
}

public class EmcService
{
    public string Add(Couple couple)
    {
        return couple.iInteger + couple.i1Integer;
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
