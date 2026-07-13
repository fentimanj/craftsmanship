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

    public void TakeTurn(Column columnIndex, Row rowIndex)
    {
        this.board.AddMove(columnIndex);
        
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