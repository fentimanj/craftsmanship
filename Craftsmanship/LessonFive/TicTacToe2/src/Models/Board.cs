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
        var winningSymbol = Symbol.Unknown;
        
        if (this.ThreeInLeftColumn())
        {
            winningSymbol = this.moves[Position.TopRowLeftColumn];
        }

        if (winningSymbol != Symbol.Unknown)
        {
            return winningSymbol;
        }

        if (this.ThreeInCentreColumn())
        {
            winningSymbol = this.moves[Position.TopRowCentreColumn];
        }
        
        if (winningSymbol != Symbol.Unknown)
        {
            return winningSymbol;
        }

        if (this.ThreeInRightColumn())
        {
            winningSymbol = this.moves[Position.TopRowRightColumn];
        }
        
        if (winningSymbol != Symbol.Unknown)
        {
            return winningSymbol;
        }

        return winningSymbol;
    }

    private bool ThreeInRightColumn()
    {
        return this.moves[Position.TopRowRightColumn] == this.moves[Position.MiddleRowRightColumn] &&
               this.moves[Position.TopRowRightColumn] == this.moves[Position.BottomRowRightColumn];
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