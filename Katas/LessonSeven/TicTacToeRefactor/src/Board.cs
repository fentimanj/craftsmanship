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
                var position = new Position(column, row);
                var positionNew = new PositionNew(ColumnMapper.ColumnToColumnNew(column), RowMapper.RowToRowNew(row));
                this.tiles.Add(new Tile(SymbolOptions.Space, position, positionNew));
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
        var column = ColumnMapper.ColumnToColumnNew(columnIndex);
        var topRowSymbol = this.SymbolAt(new PositionNew(column, RowNew.Top));
        var middleRowSymbol = this.SymbolAt(new PositionNew(column, RowNew.Middle));
        var bottomRowSymbol = this.SymbolAt(new PositionNew(column, RowNew.Bottom));

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : SymbolOptions.Space;
    }
    
    private char SymbolAt(PositionNew positionNew)
    {
        var tile = this.tiles.Single(Tile.IsAt(positionNew));
        return tile.GetSymbol();
    }

    public void AddTileAt(char symbol, PositionNew positionNew)
    {
        var currentTile = this.tiles.Single(Tile.IsAt(positionNew));
        currentTile.AddSymbol(symbol);
    }
}