namespace src.Services;

using Enums;

public class TicTacToe
{
    private Symbol Symbol = Symbol.X;
    
    public Symbol CurrentSymbol()
    {
        return Symbol;
    }

    public void TakeTurn()
    {
        Symbol = Symbol.O;
        
    }
}