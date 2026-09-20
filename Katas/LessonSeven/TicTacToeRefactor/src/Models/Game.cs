namespace src.Models;

using Enums;
using Extensions;

public class Game
{
    private readonly Board board = new();

    private Symbol lastSymbol = Symbol.Space;

    public void Play(char symbolAsChar, int x, int y) // We can't change this signature as it's the main public method
    {
        var position= new Position(x,y);

        var symbol = symbolAsChar.CharToSymbol();
        this.ValidateMove(symbol);

        this.lastSymbol = symbolAsChar.CharToSymbol();

        this.board.AddTileAt(symbol, position);
    }

    private void ValidateMove(Symbol symbol)
    {
        if (this.IsFirstMove() && IsSymbolNaught(symbol))
        {
            {
                throw new Exception("Invalid first player");
            }
        }

        if (this.IsInvalidNextPlayer(symbol))
        {
            throw new Exception("Invalid next player");
        }
    }

    private bool IsInvalidNextPlayer(Symbol symbol)
    {
        return symbol == this.lastSymbol;
    }

    private static bool IsSymbolNaught(Symbol symbol)
    {
        return symbol == Symbol.O;
    }

    private bool IsFirstMove()
    {
        return this.lastSymbol == Symbol.Space;
    }

    public char Winner() //Public interface
    {
        var winner = this.board.HasWinner();
        return winner.SymbolToChar();
    }

}