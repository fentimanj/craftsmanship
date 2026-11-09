namespace CharacterCopier.tests;

using FluentAssertions;
using src;

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