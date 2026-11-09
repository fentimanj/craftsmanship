namespace CharacterCopier.tests;

using FluentAssertions;
using src;

public class CharacterCopierShould
{
    [Fact]
    public void ReturnSingleCharsInDestination_WhenCopyInvoked_GivenSingleCharInFakeSource()
    {
        ISource source = new FakeSource(['a', '\n']);
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
    
    [Fact]
    public void ReturnOneCharInDestination_WhenCopyInvoked_GivenOneCharAndANewLineInFakeSource()
    {
        ISource source = new FakeSource(['a', 'b', '\n']);
        var destination= new SpyDestination();
        var copier = new Copier(source, destination);
        
        copier.Copy();

        destination.Chars.Should().ContainInOrder('a', 'b');
    } 
    
    [Fact]
    public void ReturnManyCharsDestination_WhenCopyInvoked_GivenOneCharAndANewLineInFakeSource()
    {
        ISource source = new FakeSource(['a', 'b', 'c', 'd', '\n']);
        var destination= new SpyDestination();
        var copier = new Copier(source, destination);
        
        copier.Copy();

        destination.Chars.Should().ContainInOrder('a', 'b', 'c', 'd');
    }
}