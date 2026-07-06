namespace src.Services;

using Enums;
using Records;

public class TicTacToeGame
{
    private bool isXSymbolNext = true;
    private readonly List<Move> moves = new();
    
    public char NextSymbolIs()
    {
        return this.isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(Column column, Row row)
    {
        var move = new Move(this.NextSymbolIs(), column,row);
        this.moves.Add(move);
        this.isXSymbolNext = !this.isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (this.ThereAreThreeInColumn('O', Column.Left) ||
            this.ThereAreThreeInColumn('O', Column.Centre) ||
            this.ThereAreThreeInColumn('O', Column.Right))
        {
            return "O";
        }
        
        if (this.ThereAreThreeInColumn('X', Column.Left) ||
            this.ThereAreThreeInColumn('X', Column.Centre) ||
            this.ThereAreThreeInColumn('X', Column.Right))
        {
            return "X";
        }
        
        if (this.ThereAreThreeInRow('X', Row.Top))
        {
            return "X";
        }
        
        return "Unknown";
    }

    private bool ThereAreThreeInColumn(char symbol, Column column)
    {
        return this.moves.Count(move => move.Column == column && move.Symbol == symbol) == 3;
    } 
    
    private bool ThereAreThreeInRow(char symbol, Row row)
    {
        return this.moves.Count(move => move.Row == row && move.Symbol == symbol) == 3;
    }
    
    
    
    
}