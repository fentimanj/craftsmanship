namespace src;

using Constant;
using Enums;

public class Game
{
    private readonly Board board = new();

    private char lastSymbol = SymbolAsChar.Space;

    public void Play(char symbol, Position position)
    {
        // TODO : Data clump
        this.ValidateMove(symbol);

        this.lastSymbol = symbol;

        // TODO: Data clump
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

    public char Winner()
    {
        return this.board.HasWinner();
    }

}
