namespace src;

using Constant;

public class Game
{
    private readonly Board board = new();

    private char lastSymbol = Symbol.Space;

    // TODO: Data clump
    // TODO: Primitive Obsession
    public void Play(char symbol, int x, int y)
    {
        // TODO : Data clump
        this.ValidateMove(symbol, x, y);

        this.lastSymbol = symbol;

        // TODO: Data clump
        this.board.AddTileAt(symbol, x, y);
    }

    private void ValidateMove(char symbol, int x, int y)
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
        return symbol == Symbol.O;
    }

    private bool IsFirstMove()
    {
        return this.lastSymbol == Symbol.Space;
    }

    public char Winner()
    {
        return this.board.HasWinner();
    }

}