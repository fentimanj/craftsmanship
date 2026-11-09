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
        if(nextChar == '\n') return;
        this.destination.SetChar(nextChar);
    }
}