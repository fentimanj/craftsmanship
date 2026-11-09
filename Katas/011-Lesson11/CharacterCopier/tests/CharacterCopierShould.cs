namespace CharacterCopier.tests;

using FluentAssertions;

public class CharacterCopierShould
{
    [Fact]
    public void Return_When_Given()
    {
        ISource source = new FakeSource();
        var destination= new SpyDestination();
        Copier copier = new Copier(source, destination);
        copier.Copy();

        destination.Chars.Should().Contain('a');
    }
}

public class FakeSource : ISource
{
    public char GetChar()
    {
        return 'a';
    }
    
}

public class SpyDestination : IDestination
{
    public List<char> Chars { get; set; } = new List<char>();
    public void SetChar(char character)
    {
        this.Chars.Add(character);
    }
}

public class Copier
{
    private readonly ISource source;
    private readonly IDestination destination;

    public Copier(ISource source, IDestination destination)
    {
        this.source = source;
        this.destination = destination;
    }

    public void Copy()
    {
        var nextChar = source.GetChar();
        destination.SetChar(nextChar);
    }
}

public interface ISource //QUERY
{
    char GetChar(); //STUB OR A FAKE
}

public interface IDestination //COMMAND
{
    void SetChar(char character);  //MOCK OR SPY
}