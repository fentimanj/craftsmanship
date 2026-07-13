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
        this.currentSymbol = Symbol.O;
        
    }
}