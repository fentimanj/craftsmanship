namespace src;

using Constant;

public class Game
{
    private readonly Board board = new();

    private char lastSymbol = SymbolOptions.Space;

    // TODO: Primitive Obsession
    public void Play(char symbol, int x, int y) // We can't change this signature as it's the main public method
    {
        var position = new Position(x, y);
        var positionNew = new PositionNew(ColumnMapper.ColumnToColumnNew(x), RowMapper.RowToRowNew(y));

        this.ValidateMove(symbol);

        this.lastSymbol = symbol;

        this.board.AddTileAt(symbol, positionNew);
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
        return symbol == SymbolOptions.O;
    }

    private bool IsFirstMove()
    {
        return this.lastSymbol == SymbolOptions.Space;
    }

    public char Winner()
    {
        return this.board.HasWinner();
    }

}