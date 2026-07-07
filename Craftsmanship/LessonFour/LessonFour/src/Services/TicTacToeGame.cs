namespace src.Services;

using Enums;
using Records;

public class TicTacToeGame
{
    private bool isXSymbolNext = true;
    private readonly List<Move> moves = new();
    
    public Symbol NextSymbolIs()
    {
        return this.isXSymbolNext ? Symbol.X : Symbol.O;
    }

    public void TakeTurn(Column column, Row row)
    {
        var move = new Move(this.NextSymbolIs(), column,row);
        this.moves.Add(move);
        this.isXSymbolNext = !this.isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (this.OHasOneInAColumn())
        {
            return "O";
        }
        
        if (this.ThereAreThreeInColumn(Symbol.X, Column.Left) ||
            this.ThereAreThreeInColumn(Symbol.X, Column.Centre) ||
            this.ThereAreThreeInColumn(Symbol.X, Column.Right))
        {
            return "X";
        }
        
        if (this.ThereAreThreeInRow(Symbol.X, Row.Top) ||
            this.ThereAreThreeInRow(Symbol.X, Row.Centre) ||
            this.ThereAreThreeInRow(Symbol.X, Row.Bottom))
        {
            return "X";
        }
        
        return "Unknown";
    }

    private bool OHasOneInAColumn()
    {
        var leftColumn = ThereAreThreeInColumn(Symbol.O, Column.Left);
        var rightColumn = ThereAreThreeInColumn(Symbol.O, Column.Right);
        var centreColumn = ThereAreThreeInColumn(Symbol.O, Column.Centre);
        
        return leftColumn || rightColumn || centreColumn;
    }
    
    private bool ThereAreThreeInColumn(Symbol symbol, Column column)
    {
        return this.moves.Count(move => move.Column == column && move.Symbol == symbol) == 3;
    } 
    
    private bool ThereAreThreeInRow(Symbol symbol, Row row)
    {
        return this.moves.Count(move => move.Row == row && move.Symbol == symbol) == 3;
    }
    
    
    
    
}