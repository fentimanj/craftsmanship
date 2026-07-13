namespace src.Services;

using Enums;

public class TicTacToe
{
    private Symbol symbol = Symbol.X;
    
    public Symbol CurrentSymbol()
    {
        return this.symbol;
    }

    public void TakeTurn()
    {
        this.symbol = Symbol.O;
        
    }
}