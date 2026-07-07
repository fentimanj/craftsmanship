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
        if (this.SymbolHasCompleteColumn(Symbol.O))
        {
            return "O";
        }
        
        if (this.SymbolHasCompleteColumn(Symbol.X))
        {
            return "X";
        }
        
        if (this.SymbolHasCompleteRow(Symbol.X))
        {
            return "X";
        }
        
        if (this.SymbolHasCompleteRow(Symbol.O))
        {
            return "O";
        }
        
        return "Unknown";
    }

    private bool SymbolHasCompleteColumn(Symbol symbol)
    {
        var leftColumn = this.ThereAreThreeInColumn(symbol, Column.Left);
        var rightColumn = this.ThereAreThreeInColumn(symbol, Column.Right);
        var centreColumn = this.ThereAreThreeInColumn(symbol, Column.Centre);
        
        return leftColumn || rightColumn || centreColumn;
    }

    private bool SymbolHasCompleteRow(Symbol symbol)
    {
        var leftRow = this.ThereAreThreeInRow(symbol, Row.Top);
        var centreRow = this.ThereAreThreeInRow(symbol, Row.Centre);
        var rightRow = this.ThereAreThreeInRow(symbol, Row.Bottom);
        
        return leftRow || rightRow || centreRow;
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