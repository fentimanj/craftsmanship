namespace src.Models;

using Enums;

internal class Board
{
   private readonly Dictionary<Position, Symbol> symbols = new();

   public void AddMove(Position position, Symbol symbol)
    {
        this.symbols.Add(position, symbol);
    }

    public Symbol WinningSymbol()
    {
        if (this.symbols.Count == 5)
        {
            return Symbol.X;
        } 
        
        if (this.symbols.Count == 6)
        {
            return Symbol.O;
        }
        
        return Symbol.Unknown;
    }
}