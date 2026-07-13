namespace src.Models;

using Enums;

internal class Board
{
    private readonly Dictionary<Position, Symbol> symbols = new()
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

    private Symbol topRowLeftColumn() => this.symbols[Position.TopRowLeftColumn];
    private Symbol topRowCentreColumn() => this.symbols[Position.TopRowCentreColumn];
    private Symbol middleRowLeftColumn() => this.symbols[Position.MiddleRowLeftColumn];
    private Symbol middleRowRightColumn() => this.symbols[Position.MiddleRowRightColumn];
    private Symbol middleRowCentreColumn() => this.symbols[Position.MiddleRowCentreColumn];
    private Symbol bottomRowLeftColumn() => this.symbols[Position.BottomRowLeftColumn];
    private Symbol bottomRowCentreColumn() => this.symbols[Position.BottomRowCentreColumn];
    private Symbol bottomRowRightColumn() => this.symbols[Position.BottomRowRightColumn];

   

    public void AddMove(Position position, Symbol symbol)
    {
        this.symbols[position] = symbol;
    }

    public Symbol WinningSymbol()
    {
        if (this.RowInLeftColumn())
        {
            return this.topRowLeftColumn();
        }

        if (this.ThreeInCentreColumn())
        {
            return this.topRowCentreColumn();
        }
        
        return Symbol.Unknown;
    }

    private bool ThreeInCentreColumn()
    {
        return this.topRowCentreColumn() == this.middleRowCentreColumn() && this.topRowCentreColumn() == this.bottomRowCentreColumn();
    }
    
    private bool RowInLeftColumn()
    {
        return this.topRowLeftColumn() == this.middleRowLeftColumn() && this.topRowLeftColumn() == this.bottomRowLeftColumn();
    }
}