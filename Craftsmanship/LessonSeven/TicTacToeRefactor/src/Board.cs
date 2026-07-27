namespace src;

public class Board
{
    private readonly List<Tile> tiles = [];

    public Board()
    {
        for (var xAxis = 0; xAxis < 3; xAxis++) //TODO : Magic Numbers
        {
            for (var yAxis = 0; yAxis < 3; yAxis++) // TODO : Magic Numbers
            {
                this.tiles.Add(new Tile { X = xAxis, Y = yAxis, Symbol = ' ' }); // TODO: Magic Char
            }
        }
    }

    public Tile TileAt(int x, int y) // TODO:  Primitive Obsession / Data Clump
    {
        return this.tiles.Single(tile => tile.X == x && tile.Y == y); //TODO:  Duplicated code / Feature Envy
    }

    public void AddTileAt(char symbol, int x, int y) // TODO:  Primitive Obsession / Data Clump
    {
        this.tiles.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol; //TODO:  Message Chain / Duplicated Code / Feature Envy
    }
}