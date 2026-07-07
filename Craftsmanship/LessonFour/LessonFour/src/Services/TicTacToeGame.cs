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

        if (this.moves.Where(move => move.Column == column && move.Row == row).Any())
        {
            return;
        }
        
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
        
        if(this.SymbolHasDiagnolTopLeftToBottomRight(Symbol.X))
        {
            return "X";
        }
        
        if(this.SymbolHasDiagnolTopLeftToBottomRight(Symbol.O))
        {
            return "O";
        }

        if (this.SymbolHasDiagnolTopRightToBottomLeft(Symbol.X))
        {
            return "X";
        }
        
        if (this.SymbolHasDiagnolTopRightToBottomLeft(Symbol.O))
        {
            return "O";
        }
        
        
        return "Unknown";
    }

    private bool SymbolHasDiagnolTopLeftToBottomRight(Symbol symbol)
    {
        var topLeft = moves.FirstOrDefault(move => move is { Column: Column.Left, Row: Row.Top } && move.Symbol == symbol);
        var centreCentre = moves.FirstOrDefault(move => move is { Column: Column.Centre, Row: Row.Centre } && move.Symbol == symbol);
        var bottomRight = moves.FirstOrDefault(move => move is { Column: Column.Right, Row: Row.Bottom } && move.Symbol == symbol);

        return topLeft != null && centreCentre != null && bottomRight != null;
    }  
    
    private bool SymbolHasDiagnolTopRightToBottomLeft(Symbol symbol)
    {
        var topLeft = moves.FirstOrDefault(move => move is { Column: Column.Right, Row: Row.Top } && move.Symbol == symbol);
        var centreCentre = moves.FirstOrDefault(move => move is { Column: Column.Centre, Row: Row.Centre } && move.Symbol == symbol);
        var bottomRight = moves.FirstOrDefault(move => move is { Column: Column.Left, Row: Row.Bottom } && move.Symbol == symbol);

        return topLeft != null && centreCentre != null && bottomRight != null;
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