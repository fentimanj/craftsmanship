namespace src.Services;

using Enums;

public class TicTacToe
{
    private Symbol currentSymbol = Symbol.X;
    private int NumberOfMoves = 0;

    public Symbol CurrentSymbol()
    {
        return this.currentSymbol;
    }

    public void TakeTurn(int columnIndex, int rowIndex)
    {
        NumberOfMoves++;
        if (this.currentSymbol == Symbol.X)
        {
            this.currentSymbol = Symbol.O;
            return;
        }

        this.currentSymbol = Symbol.X;
    }

    public Symbol GetWinningSymbnol()
    {
        if (NumberOfMoves == 1)
        {
            return Symbol.Unknown;
        }

        return Symbol.X;
    }
}