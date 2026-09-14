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
        var topRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Top));
        var middleRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Middle));
        var bottomRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Bottom));

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : SymbolOptions.Space;
    }
    
    private char SymbolAt(Position position)
    {
        var tile = this.tiles.Single(Tile.IsAt(position));
        return tile.GetSymbol();
    }
    public void AddTileAt(char symbol, Position position)
    {
        var currentTile = this.tiles.Single(Tile.IsAt(position));
        currentTile.AddSymbol(symbol);
    }
}