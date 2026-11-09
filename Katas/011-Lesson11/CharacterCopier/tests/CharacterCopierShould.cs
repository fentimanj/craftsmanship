namespace CharacterCopier.tests;

using FluentAssertions;
using src;

public class CharacterCopierShould
{
    [Fact]
    public void ReturnCharsInDestination_WhenCopyInvoked_GivenSimpleSetup()
    {
        ISource source = new FakeSource();
        var destination= new SpyDestination();
        Copier copier = new Copier(source, destination);
        copier.Copy();

        destination.Chars.Should().Contain('a');
    }
}