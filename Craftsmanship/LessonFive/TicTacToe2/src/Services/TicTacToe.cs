namespace src.Services;

using Enums;
using Models;

public class TicTacToe
{
    private Symbol currentSymbol = Symbol.X;
    private readonly Board board = new();
    
    public Symbol CurrentSymbol()
    {
        return this.currentSymbol;
    }
    
    public void TakeTurn(Position position)
    {
        this.board.AddMove(position, this.currentSymbol);
        
        if (this.currentSymbol == Symbol.X)
        {
            this.currentSymbol = Symbol.O;
            return;
        }

        this.currentSymbol = Symbol.X;
    }

    public Symbol GetWinningSymbnol()
    {
        return this.board.WinningSymbol();
    }
}