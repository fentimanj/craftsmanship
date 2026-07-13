namespace src.Models;

using Enums;

internal class Board
{
    private readonly Dictionary<Position, Symbol> moves = new()
    {
        { Position.TopRowLeftColumn, Symbol.Unknown },
        { Position.TopRowCentreColumn, Symbol.Unknown },
        { Position.TopRowRightColumn, Symbol.Unknown },

        { Position.MiddleRowLeftColumn, Symbol.Unknown },
        { Position.MiddleRowRightColumn, Symbol.Unknown },
        { Position.MiddleRowCentreColumn, Symbol.Unknown },

        { Position.BottomRowLeftColumn, Symbol.Unknown },
        { Position.BottomRowCentreColumn, Symbol.Unknown },
        { Position.BottomRowRightColumn, Symbol.Unknown }
    };
    
    public void AddMove(Position position, Symbol symbol)
    {
        this.moves[position] = symbol;
    }

    public Symbol WinningSymbol()
    {
        if (this.ThreeInLeftColumn())
        {
            return this.moves[Position.TopRowLeftColumn];
        }

        if (this.ThreeInCentreColumn())
        {
            return this.moves[Position.TopRowCentreColumn];
        }
        
        return Symbol.Unknown;
    }

    private bool ThreeInCentreColumn()
    {
        return this.moves[Position.TopRowCentreColumn] == this.moves[Position.MiddleRowCentreColumn] 
               && this.moves[Position.TopRowCentreColumn] == this.moves[Position.BottomRowCentreColumn];
    }
    
    private bool ThreeInLeftColumn()
    {
        return this.moves[Position.TopRowLeftColumn] == this.moves[Position.MiddleRowLeftColumn] 
               && this.moves[Position.TopRowLeftColumn] == this.moves[Position.BottomRowLeftColumn];
    }
}