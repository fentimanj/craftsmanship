namespace src.Services;

using Enums;
using Models;
using Records;

public class TicTacToeGame
{
    private readonly Board board = new();
    private bool isXSymbolNext = true;

    public Symbol NextSymbolIs()
    {
        return this.isXSymbolNext ? Symbol.X : Symbol.O;
    }

    public void TakeTurn(Column column, Row row)
    {
        var lastestMove = new Move(this.NextSymbolIs(), column, row);

        if (!this.board.IsMoveAllowed(lastestMove))
        {
            return;
        }

        this.board.AddMove(lastestMove);

        this.isXSymbolNext = !this.isXSymbolNext;
    }

    public string WinnerIs()
    {
        return this.board.WinningSymbol();
    }
}