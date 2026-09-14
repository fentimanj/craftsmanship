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
                var position = new Position(){Column = column, Row = row};
                this.tiles.Add(new Tile(column, row, SymbolOptions.Space, position));
            }
        }
    }

    public char HasWinner()
    {
        for (var index = Column.Left; index <= Column.Right; index++)
        {
            var winner = this.ColumnTakenBy(index);
            if (winner != SymbolOptions.Space)
            {
                return winner;
            }
        }

        return SymbolOptions.Space;
    }

    private char ColumnTakenBy(int columnIndex)
    {
        var topRowSymbol = this.SymbolAt(columnIndex, Row.Top);
        var middleRowSymbol = this.SymbolAt(columnIndex, Row.Middle);
        var bottomRowSymbol = this.SymbolAt(columnIndex, Row.Bottom);

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : SymbolOptions.Space;
    }

    // TODO: Data Clump
    private char SymbolAt(int x, int y)
    {
        var tile = this.tiles.Single(Tile.IsAt(x, y));
        return tile.GetSymbol();
    }

    // TODO: Data Clump
    public void AddTileAt(char symbol, int x, int y)
    {
        var currentTile = this.tiles.Single(Tile.IsAt(x, y));
        currentTile.AddSymbol(symbol);
    }
}