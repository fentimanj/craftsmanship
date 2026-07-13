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
        if (currentSymbol == Symbol.X)
        {
            this.currentSymbol = Symbol.O;
        }
        else
        {
            this.currentSymbol = Symbol.X;
        }

    }
}