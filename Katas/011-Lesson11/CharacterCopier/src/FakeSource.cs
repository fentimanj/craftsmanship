namespace CharacterCopier.src;

public class FakeSource : ISource
{
    public char GetChar()
    {
        return 'a';
    }
    
}