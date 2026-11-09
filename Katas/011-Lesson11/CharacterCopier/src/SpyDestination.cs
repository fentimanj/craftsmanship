namespace CharacterCopier.src;

public class SpyDestination : IDestination
{
    public List<char> Chars { get; set; } = new List<char>();
    public void SetChar(char character)
    {
        this.Chars.Add(character);
    }
}