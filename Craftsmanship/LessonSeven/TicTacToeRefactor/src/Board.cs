namespace src;

using Constant;

public class Board
{
    private readonly List<Tile> tiles = [];

    public Board()
    {
        for (var column = Column.Left; column <= Column.Right; column++)
        {
            for (var row = Row.Top; row <= Row.Bottom; row++)
            {
                this.tiles.Add(new Tile { X = column, Y = row, Symbol = Symbol.Space });
            }
        }
    }

    // TODO: Data Clump
    public Tile TileAt(int x, int y)
    {
        return this.tiles.Single(Tile.IsAt(x, y));
    }

    public char SymbolAt(int x, int y)
    {
        var tile = this.tiles.Single(Tile.IsAt(x, y));
        return tile.Symbol;
    }

    // TODO: Data Clump
    public void AddTileAt(char symbol, int x, int y)
    {
        // TODO: Message Chain
        this.tiles.Single(Tile.IsAt(x, y)).Symbol = symbol;
    }
}