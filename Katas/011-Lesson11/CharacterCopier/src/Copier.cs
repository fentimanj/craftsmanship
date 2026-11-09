namespace CharacterCopier.src;

public class Copier
{
    private readonly ISource source;
    private readonly IDestination destination;

    public Copier(ISource source, IDestination destination)
    {
        this.source = source;
        this.destination = destination;
    }

    public void Copy()
    {
        
        var nextChar = this.source.GetChar();
        while (nextChar != '\n')
        {
            this.destination.SetChar(nextChar);
            nextChar = this.source.GetChar();
        }

    }
}