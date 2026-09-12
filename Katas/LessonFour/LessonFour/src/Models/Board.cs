namespace src.Models;

using Enums;
using Records;

public class Board : IBoard
{
    private readonly List<Move> moves = new();

    public bool IsMoveAllowed(Move proposedMove)
    {
        return !this.moves.Any(move => move.Column == proposedMove.Column && move.Row == proposedMove.Row);
    }

    public void AddMove(Move move)
    {
        this.moves.Add(move);
    }

    public string WinningSymbol()
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

        if (this.SymbolHasDiagonalTopLeftToBottomRight(Symbol.X))
        {
            return "X";
        }

        if (this.SymbolHasDiagonalTopLeftToBottomRight(Symbol.O))
        {
            return "O";
        }

        if (this.SymbolHasDiagonalTopRightToBottomLeft(Symbol.X))
        {
            return "X";
        }

        if (this.SymbolHasDiagonalTopRightToBottomLeft(Symbol.O))
        {
            return "O";
        }


        return "Unknown";
    }
    
    private bool SymbolHasDiagonalTopLeftToBottomRight(Symbol symbol)
    {
        var topLeft =
            this.moves.FirstOrDefault(move => move is { Column: Column.Left, Row: Row.Top } && move.Symbol == symbol);
        var centreCentre = this.moves.FirstOrDefault(move =>
            move is { Column: Column.Centre, Row: Row.Centre } && move.Symbol == symbol);
        var bottomRight = this.moves.FirstOrDefault(move =>
            move is { Column: Column.Right, Row: Row.Bottom } && move.Symbol == symbol);

        return topLeft != null && centreCentre != null && bottomRight != null;
    }

    private bool SymbolHasDiagonalTopRightToBottomLeft(Symbol symbol)
    {
        var topLeft =
            this.moves.FirstOrDefault(move => move is { Column: Column.Right, Row: Row.Top } && move.Symbol == symbol);
        var centreCentre = this.moves.FirstOrDefault(move =>
            move is { Column: Column.Centre, Row: Row.Centre } && move.Symbol == symbol);
        var bottomRight = this.moves.FirstOrDefault(move =>
            move is { Column: Column.Left, Row: Row.Bottom } && move.Symbol == symbol);

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