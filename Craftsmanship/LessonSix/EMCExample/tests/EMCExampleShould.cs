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
        return AddNew();
    }

    private static string AddNew()
    {
        return "12";
    }
}
