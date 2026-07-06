namespace src.Services;

using Enums;

public class TicTacToeGame
{
    private readonly List<Move> moves = new();
    private bool isXSymbolNext = true;

    public char NextSymbolIs()
    {
        return this.isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(Column column, Row row)
    {
        var move = new Move(this.NextSymbolIs(), column, row);
        this.moves.Add(move);
        this.isXSymbolNext = !this.isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (this.WeHaveAColumn() != '-')
        {
            return this.WeHaveAColumn().ToString();
        }

        if (this.ThereAreThreeInRow('X', Row.Top))
        {
            return "X";
        }

        return "Unknown";
    }

    private char WeHaveAColumn()
    {
        var xInLeftColumn = this.moves.Count(move => move.Column == Column.Left && move.Symbol == 'X') == 3;
        var oInLeftColumn = this.moves.Count(move => move.Column == Column.Left && move.Symbol == 'O') == 3;

        var xInCentreColumn = this.moves.Count(move => move.Column == Column.Centre && move.Symbol == 'X') == 3;
        var oInCentreColumn = this.moves.Count(move => move.Column == Column.Centre && move.Symbol == 'O') == 3;

        var xInRightColumn = this.moves.Count(move => move.Column == Column.Right && move.Symbol == 'X') == 3;
        var oInRightColumn = this.moves.Count(move => move.Column == Column.Right && move.Symbol == 'O') == 3;

        if (xInLeftColumn || xInCentreColumn || xInRightColumn)
        {
            return 'X';
        }

        if (oInLeftColumn || oInCentreColumn || oInRightColumn)
        {
            return 'O';
        }

        return '-';
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

public record Move(char Symbol, Column Column, Row Row);