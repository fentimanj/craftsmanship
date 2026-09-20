namespace src.Models;

using Constant;
using Extensions;

public class Game
{
    private readonly Board board = new();

    private char lastSymbol = SymbolAsChar.Space;

    public void Play(char symbolAsChar, int x, int y) // We can't change this signature as it's the main public method
    {
        var position= new Position(x,y);

        var symbol = symbolAsChar.CharToSymbol();
        this.ValidateMove(symbolAsChar);

        this.lastSymbol = symbolAsChar;

        this.board.AddTileAt(symbol, position);
    }

    private void ValidateMove(char symbol)
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

    private bool IsInvalidNextPlayer(char symbol)
    {
        return symbol == this.lastSymbol;
    }

    private static bool IsSymbolNaught(char symbol)
    {
        return symbol == SymbolAsChar.O;
    }

    private bool IsFirstMove()
    {
        return this.lastSymbol == SymbolAsChar.Space;
    }

    public char Winner() //Public interface
    {
        var winner = this.board.HasWinner();
        return winner.SymbolToChar();
    }

}