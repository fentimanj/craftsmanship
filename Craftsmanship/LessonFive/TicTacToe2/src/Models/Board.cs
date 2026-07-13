namespace src.Models;

using Enums;

internal class Board
{
    private readonly List<Column> columns = new();

    public void AddMove(Column column)
    {
        this.columns.Add(column);
    }

    public Symbol WinningSymbol()
    {
        if (this.columns.Count == 5)
        {
            return Symbol.X;
        }
        
        return Symbol.Unknown;
    }
}