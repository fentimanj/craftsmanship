namespace CharacterCopier.tests;

using FluentAssertions;
using NSubstitute;
using src;

public class CharacterCopierShould
{
    //[Fact]
    public void ReturnSingleCharsInDestination_WhenCopyInvoked_GivenSingleCharInFakeSource()
    {
        ISource source = new FakeSource(['a', '\n']);
        var destination = new SpyDestination();
        var copier = new Copier(source, destination);
        copier.Copy();

        destination.Chars.Should().Contain('a');
    }

    //[Fact]
    public void ReturnEmptyDestination_WhenCopyInvoked_GiveNewLineInFakeSource()
    {
        ISource source = new FakeSource(['\n']);
        var destination = new SpyDestination();
        var copier = new Copier(source, destination);
        copier.Copy();

        destination.Chars.Should().BeEmpty();
    }

    // [Fact]
    public void ReturnOneCharInDestination_WhenCopyInvoked_GivenOneCharAndANewLineInFakeSource()
    {
        ISource source = new FakeSource(['a', 'b', '\n']);
        var destination = new SpyDestination();
        var copier = new Copier(source, destination);

        copier.Copy();

        destination.Chars.Should().ContainInOrder('a', 'b');
    }

    //[Fact]
    public void ReturnManyCharsDestination_WhenCopyInvoked_GivenOneCharAndANewLineInFakeSource()
    {
        ISource source = new FakeSource(['a', 'b', 'c', 'd', '\n']);
        var destination = new SpyDestination();
        var copier = new Copier(source, destination);

        copier.Copy();

        destination.Chars.Should().ContainInOrder('a', 'b', 'c', 'd');
    }

    [Fact]
    public void ReturnSingleCharsInDestination_WhenCopyInvoked_GivenSingleCharUsingNSubstitute()
    {
        var source = Substitute.For<ISource>();
        source.GetChar().Returns('a', '\n');

        var destination = Substitute.For<IDestination>();

        var copier = new Copier(source, destination);
        copier.Copy();

        destination.Received(1).SetChar('a');
    }

    [Fact]
    public void ReturnEmptyDestination_WhenCopyInvoked_GiveNewLineUsingNSubstitute()
    {
        var source = Substitute.For<ISource>();
        source.GetChar().Returns('\n');

        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);
        copier.Copy();

        destination.Received(0).SetChar(Arg.Any<char>());
    }

    [Fact]
    public void ReturnManyCharsDestination_WhenCopyInvoked_GivenOneCharAndANewLineUsingNSubstitute()
    {
        var source = Substitute.For<ISource>();
        source.GetChar().Returns('a', 'b', 'c', 'd', '\n');
        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);

        copier.Copy();

        Received.InOrder(() =>
            {
                destination.SetChar('a');
                destination.SetChar('b');
                destination.SetChar('c');
                destination.SetChar('d');
            }
        );
    }
}