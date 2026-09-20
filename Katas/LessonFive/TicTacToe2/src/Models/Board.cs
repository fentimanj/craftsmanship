namespace src.Models;

using Enums;

internal class Board
{
    private readonly Dictionary<Position, Symbol> moves = new()
    {
        { Position.TopRowLeftColumn, Symbol.Space },
        { Position.TopRowCentreColumn, Symbol.Space },
        { Position.TopRowRightColumn, Symbol.Space },

        { Position.MiddleRowLeftColumn, Symbol.Space },
        { Position.MiddleRowRightColumn, Symbol.Space },
        { Position.MiddleRowCentreColumn, Symbol.Space },

        { Position.BottomRowLeftColumn, Symbol.Space },
        { Position.BottomRowCentreColumn, Symbol.Space },
        { Position.BottomRowRightColumn, Symbol.Space }
    };
    
    public void AddMove(Position position, Symbol symbol)
    {
        this.moves[position] = symbol;
    }

    public Symbol WinningSymbol()
    {
        var winningSymbol = Symbol.Space;
        
        if (this.ThreeInLeftColumn())
        {
            winningSymbol = this.moves[Position.TopRowLeftColumn];
        }

        if (winningSymbol != Symbol.Space)
        {
            return winningSymbol;
        }

        if (this.ThreeInCentreColumn())
        {
            winningSymbol = this.moves[Position.TopRowCentreColumn];
        }
        
        if (winningSymbol != Symbol.Space)
        {
            return winningSymbol;
        }

        if (this.ThreeInRightColumn())
        {
            winningSymbol = this.moves[Position.TopRowRightColumn];
        }
        
        if (winningSymbol != Symbol.Space)
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