namespace src.Services;

using Enums;

public class TicTacToe
{
    private Symbol currentSymbol = Symbol.X;

    public Symbol CurrentSymbol()
    {
        return this.currentSymbol;
    }

    public void TakeTurn()
    {
        if (this.currentSymbol == Symbol.X)
        {
            this.currentSymbol = Symbol.O;
            return;
        }

        this.currentSymbol = Symbol.X;
    }

    public string GetWinningSymbnol()
    {
        return "Unknown";
    }
}