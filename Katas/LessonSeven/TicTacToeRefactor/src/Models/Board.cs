namespace src.Models;

using Constant;
using Enums;

public class Board
{
    private readonly List<Tile> tiles = [];
    private readonly WinningMoves winningMoves;

    public Board()
    {
        for (var column = Column.Left; column <= Column.Right; column++)
        {
            for (var row = Row.Top; row <= Row.Bottom; row++)
            {
                var positionNew = new Position(column, row);
                this.tiles.Add(new Tile(Symbol.Space, positionNew));
            }
        }

        this.winningMoves = new WinningMoves();
    }

    public Symbol HasWinner()
    {
        return this.winningMoves.CheckForWinningSymbol(this.tiles);
    }

    public void AddTileAt(Symbol symbol, Position position)
    {
        var currentTile = this.tiles.Single(Tile.IsAt(position));
        currentTile.AddSymbol(symbol);
    }
}