namespace src;

public static class Column
{
    public const int Left = 0;
    public const int Center = 1;
    public const int Right = 2;
}

public static class Row
{
    public const int Top = 0;
    public const int Center = 1;
    public const int Bottom = 2;
}

public class Board
{
    private readonly List<Tile> tiles = [];

    public Board()
    {
        for (var column = Column.Left; column <= Column.Right; column++)
        {
            for (var row = Row.Top; row <= Row.Bottom; row++)
            {
                // TODO: Magic Char
                this.tiles.Add(new Tile { X = column, Y = row, Symbol = ' ' });
            }
        }
    }

    // TODO: Primitive Obsession
    // TODO: Data Clump
    public Tile TileAt(int x, int y)
    {
        // TODO:  Duplicated code
        // TODO: Feature Envy
        // Extract predicate, move to Tile class
        return this.tiles.Single(tile => tile.X == x && tile.Y == y);
    }

    // TODO: Primitive Obsession
    // TODO: Data Clump
    public void AddTileAt(char symbol, int x, int y)
    {
        // TODO: Message Chain
        // TODO: Duplicated Code
        // TODO: Feature Envy
        this.tiles.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
    }
}