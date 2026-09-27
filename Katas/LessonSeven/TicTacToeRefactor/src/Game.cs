namespace src;

public class Game
{
    private readonly Board board = new();

    private Symbol lastSymbol = Symbol.Space;

    public void Play(Symbol symbol, Position position)
    {
        this.ValidateMove(symbol);

        this.lastSymbol = symbol;

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

    public Symbol Winner()
    {
        return this.board.HasWinner();
    }
}