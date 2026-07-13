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
        
        var leftTop = this.symbols[Position.LeftTop];
        
        Symbol rightCentre = Symbol.Unknown;
        if (this.symbols.Keys.Contains(Position.RightCentre))
        {
            rightCentre = this.symbols[Position.RightCentre];
        }
        
        Symbol leftBottom = Symbol.Unknown;
        if(this.symbols.Keys.Contains(Position.LeftBottom))
        {
            leftBottom = this.symbols[Position.LeftBottom];
        }

        Symbol leftCentre = Symbol.Unknown;
        if(this.symbols.Keys.Contains(Position.LeftCentre))
        {
            leftCentre = this.symbols[Position.LeftCentre];
        }
        
        if(leftCentre == leftTop && leftTop == leftBottom)
        {
            return leftTop;
        }
        
        if(leftTop == rightCentre && rightCentre == leftCentre)
        {
            return leftTop;
        }
     
        
        return Symbol.Unknown;
    }
}