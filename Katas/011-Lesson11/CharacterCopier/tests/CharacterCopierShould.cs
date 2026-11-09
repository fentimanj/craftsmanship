namespace CharacterCopier.tests;

using FluentAssertions;
using src;

public class CharacterCopierShould
{
    [Fact]
    public void ReturnSingleCharsInDestination_WhenCopyInvoked_GivenSingleCharInFakeSource()
    {
        ISource source = new FakeSource(['a']);
        var destination= new SpyDestination();
        Copier copier = new Copier(source, destination);
        copier.Copy();

        destination.Chars.Should().Contain('a');
    }

    [Fact]
    public void ReturnEmptyDestination_WhenCopyInvoked_GiveNewLineInFakeSource()
    {
        ISource source = new FakeSource(['\n']);
        var destination= new SpyDestination();
        Copier copier = new Copier(source, destination);
        copier.Copy();
        
        destination.Chars.Should().BeEmpty();
    }
}