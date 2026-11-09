namespace CharacterCopier.tests;

using src;

public class FakeSource(char[] sourceChar) : ISource
{
    public char GetChar()
    {
        return sourceChar[0];
    }
    
}