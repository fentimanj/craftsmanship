namespace CharacterCopier.tests;

using src;

public class SpyDestination : IDestination
{
    public List<char> Chars { get; } = [];
    public void SetChar(char character)
    {
        this.Chars.Add(character);
    }
}