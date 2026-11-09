namespace CharacterCopier.tests;

using src;

public class FakeSource : ISource
{
    public char GetChar()
    {
        return 'a';
    }
    
}