namespace src;

public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
}

public class Board
{
    private readonly List<Tile> _plays = new();

    public Board()
    {
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                this._plays.Add(new Tile { X = i, Y = j, Symbol = ' ' });
            }
        }
    }

    public Tile TileAt(int x, int y)
    {
        return this._plays.Single(tile => tile.X == x && tile.Y == y);
    }

    public void AddTileAt(char symbol, int x, int y)
    {
        var newTile = new Tile
        {
            X = x,
            Y = y,
            Symbol = symbol
        };

        this._plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
    }
}

public class Game
{
    private readonly Board _board = new();
    private char _lastSymbol = ' ';

    public void Play(char symbol, int x, int y)
    {
        //if first move
        if (this._lastSymbol == ' ')
        {
            //if player is X
            if (symbol == 'O')
            {
                throw new Exception("Invalid first player");
            }
        }
        //if not first move but player repeated
        else if (symbol == this._lastSymbol)
        {
            throw new Exception("Invalid next player");
        }
        //if not first move but play on an already played tile
        else if (this._board.TileAt(x, y).Symbol != ' ')
        {
            throw new Exception("Invalid position");
        }

        // update game state
        this._lastSymbol = symbol;
        this._board.AddTileAt(symbol, x, y);
    }

    public char Winner()
    {
        //if the positions in first row are taken
        if (this._board.TileAt(0, 0).Symbol != ' ' &&
            this._board.TileAt(0, 1).Symbol != ' ' &&
            this._board.TileAt(0, 2).Symbol != ' ')
        {
            //if first row is full with same symbol
            if (this._board.TileAt(0, 0).Symbol ==
                this._board.TileAt(0, 1).Symbol &&
                this._board.TileAt(0, 2).Symbol ==
                this._board.TileAt(0, 1).Symbol)
            {
                return this._board.TileAt(0, 0).Symbol;
            }
        }

        //if the positions in first row are taken
        if (this._board.TileAt(1, 0).Symbol != ' ' &&
            this._board.TileAt(1, 1).Symbol != ' ' &&
            this._board.TileAt(1, 2).Symbol != ' ')
        {
            //if middle row is full with same symbol
            if (this._board.TileAt(1, 0).Symbol ==
                this._board.TileAt(1, 1).Symbol &&
                this._board.TileAt(1, 2).Symbol ==
                this._board.TileAt(1, 1).Symbol)
            {
                return this._board.TileAt(1, 0).Symbol;
            }
        }

        //if the positions in first row are taken
        if (this._board.TileAt(2, 0).Symbol != ' ' &&
            this._board.TileAt(2, 1).Symbol != ' ' &&
            this._board.TileAt(2, 2).Symbol != ' ')
        {
            //if middle row is full with same symbol
            if (this._board.TileAt(2, 0).Symbol ==
                this._board.TileAt(2, 1).Symbol &&
                this._board.TileAt(2, 2).Symbol ==
                this._board.TileAt(2, 1).Symbol)
            {
                return this._board.TileAt(2, 0).Symbol;
            }
        }

        return ' ';
    }
}