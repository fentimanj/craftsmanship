namespace src;

public class Board
{
    private readonly List<Tile> tiles = [];

    public Board()
    {
        // TODO : Magic Numbers
        for (var xAxis = 0; xAxis < 3; xAxis++)
        {
            // TODO : Magic Numbers
            for (var yAxis = 0; yAxis < 3; yAxis++)
            {
                // TODO: Magic Char
                this.tiles.Add(new Tile { X = xAxis, Y = yAxis, Symbol = ' ' });
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