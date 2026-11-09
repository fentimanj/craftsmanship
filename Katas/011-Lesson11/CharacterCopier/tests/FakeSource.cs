namespace CharacterCopier.tests;

using src;

public class FakeSource(char[] sourceChar) : ISource
{
    private int indexCounter;

    public char GetChar()
    {
        return sourceChar[this.indexCounter++];
    }
}