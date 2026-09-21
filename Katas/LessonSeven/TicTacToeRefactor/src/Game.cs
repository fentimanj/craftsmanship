namespace src;

using Constant;

public class Game
{
    private readonly Board board = new();

    private char lastSymbol = SymbolAsChar.Space;

    // TODO: Data clump
    // TODO: Primitive Obsession
    public void Play(char symbol, int x, int y)
    {
        this.PlayNew(symbol.ToSymbol(), x, y);
    }

    public void PlayNew(Symbol symbol, int x, int y)
    {
        // TODO : Data clump
        this.ValidateMove(symbol, x, y);

        this.lastSymbol = symbol.ToChar();

        // TODO: Data clump
        this.board.AddTileAt(symbol.ToChar(), x, y);
    }


    private void ValidateMove(Symbol symbol, int x, int y)
    {
        if (this.IsFirstMove() && IsSymbolNaught(symbol.ToChar()))
        {
            {
                throw new Exception("Invalid first player");
            }
        }

        if (this.IsInvalidNextPlayer(symbol.ToChar()))
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