namespace src;

using Constant;

public class Board
{
    private readonly List<Tile> tiles = [];

    public Board()
    {
        for (var column = ColumnNew.Left; column <= ColumnNew.Right; column++)
        {
            for (var row = RowNew.Top; row <= RowNew.Bottom; row++)
            {
                var positionNew = new Position(column, row);
                this.tiles.Add(new Tile(SymbolOptions.Space, positionNew));
            }
        }
    }

    public char HasWinner()
    {
        for (var index = ColumnNew.Left; index <= ColumnNew.Right; index++)
        {
            var winner = this.ColumnTakenBy(index);
            if (winner != SymbolOptions.Space)
            {
                return winner;
            }
        }

        return SymbolOptions.Space;
    }

    private char ColumnTakenBy(ColumnNew columnIndex)
    {
        var topRowSymbol = this.SymbolAt(new Position(columnIndex, RowNew.Top));
        var middleRowSymbol = this.SymbolAt(new Position(columnIndex, RowNew.Middle));
        var bottomRowSymbol = this.SymbolAt(new Position(columnIndex, RowNew.Bottom));

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