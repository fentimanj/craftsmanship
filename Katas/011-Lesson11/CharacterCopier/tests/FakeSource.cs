namespace CharacterCopier.tests;

using src;

public class FakeSource(char[] sourceChar) : ISource
{
    private int indexCounter = 0;
    public char GetChar()
    {
        if (indexCounter < sourceChar.Length)
        {
            return sourceChar[this.indexCounter++];
        }

        return '\n';
    }
    
}