namespace src;

using Constant;

public class Game
{
    private readonly Board board = new();

    private Symbol lastSymbol = Symbol.Space;

    // TODO: Data clump
    // TODO: Primitive Obsession - Part of public interface

    public void Play(Symbol symbol, int x, int y)
    {
        // TODO : Data clump
        this.ValidateMove(symbol);

        this.lastSymbol = symbol;

        var position = PositionMapper.Map(x, y);
        // TODO: Data clump
        this.board.AddTileAt(symbol,position);
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

    public char Winner()
    {
        return this.board.HasWinner();
    }
}