namespace src;

public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
}

public class Board
{
    private readonly List<Tile> tiles = [];

    public Board()
    {
        for (var xAxis = 0; xAxis < 3; xAxis++)
        {
            for (var yAxis = 0; yAxis < 3; yAxis++)
            {
                this.tiles.Add(new Tile { X = xAxis, Y = yAxis, Symbol = ' ' });
            }
        }
    }

    public Tile TileAt(int x, int y)
    {
        return this.tiles.Single(tile => tile.X == x && tile.Y == y);
    }

    public void AddTileAt(char symbol, int x, int y)
    {
        this.tiles.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
    }
}

public class Game
{
    private readonly Board board = new();
    private char lastSymbol = ' ';

    public void Play(char symbol, int x, int y)
    {
        if (this.IsFirstMove())
        {
            if (IsSymbolNaught(symbol))
            {
                throw new Exception("Invalid first player");
            }
        }
        else if (this.IsInvalidNextPlayer(symbol))
        {
            throw new Exception("Invalid next player");
        }
        else if (this.IsTileTaken(x, y))
        {
            throw new Exception("Invalid position");
        }

        this.lastSymbol = symbol;
        this.board.AddTileAt(symbol, x, y);
    }

    private bool IsTileTaken(int x, int y)
    {
        return this.board.TileAt(x, y).Symbol != ' ';
    }

    private bool IsInvalidNextPlayer(char symbol)
    {
        return symbol == this.lastSymbol;
    }

    private static bool IsSymbolNaught(char symbol)
    {
        return symbol == 'O';
    }

    private bool IsFirstMove()
    {
        return this.lastSymbol == ' ';
    }

    public char Winner()
    {
        if (this.IsFirstRowTaken())
        {
            if (this.IsThereSameSymbolInFirstRow())
            {
                return this.board.TileAt(0, 0).Symbol;
            }
        }

        if (this.IsSecondRowTaken())
        {
            if (this.IsThereSameSymbolInSecondRow())
            {
                return this.board.TileAt(1, 0).Symbol;
            }
        }

        if (this.IsThirdRowTaken())
        {
            if (this.IsThereSameSymbolInThirdRow())
            {
                return this.board.TileAt(2, 0).Symbol;
            }
        }

        return ' ';
    }

    private bool IsThereSameSymbolInThirdRow()
    {
        return this.board.TileAt(2, 0).Symbol ==
               this.board.TileAt(2, 1).Symbol &&
               this.board.TileAt(2, 2).Symbol ==
               this.board.TileAt(2, 1).Symbol;
    }

    private bool IsThirdRowTaken()
    {
        return this.board.TileAt(2, 0).Symbol != ' ' &&
               this.board.TileAt(2, 1).Symbol != ' ' &&
               this.board.TileAt(2, 2).Symbol != ' ';
    }

    private bool IsThereSameSymbolInSecondRow()
    {
        return this.board.TileAt(1, 0).Symbol ==
               this.board.TileAt(1, 1).Symbol &&
               this.board.TileAt(1, 2).Symbol ==
               this.board.TileAt(1, 1).Symbol;
    }

    private bool IsSecondRowTaken()
    {
        return this.board.TileAt(1, 0).Symbol != ' ' &&
               this.board.TileAt(1, 1).Symbol != ' ' &&
               this.board.TileAt(1, 2).Symbol != ' ';
    }

    private bool IsThereSameSymbolInFirstRow()
    {
        return this.board.TileAt(0, 0).Symbol ==
               this.board.TileAt(0, 1).Symbol &&
               this.board.TileAt(0, 2).Symbol ==
               this.board.TileAt(0, 1).Symbol;
    }

    private bool IsFirstRowTaken()
    {
        return this.IsTileTaken(0,0) &&
               this.IsTileTaken(0,1) &&
               this.IsTileTaken(0,2);
    }
}