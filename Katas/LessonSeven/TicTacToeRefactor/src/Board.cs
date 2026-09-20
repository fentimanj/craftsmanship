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
                var positionNew = new Position(column, row);
                this.tiles.Add(new Tile(SymbolAsChar.Space, positionNew));
            }
        }
    }

    public char HasWinner()
    {
        for (var index = Column.Left; index <= Column.Right; index++)
        {
            var winner = this.ColumnTakenBy(index);
            if (winner != SymbolAsChar.Space)
            {
                return winner;
            }
        }

        return SymbolAsChar.Space;
    }

    private char ColumnTakenBy(Column columnIndex)
    {
        var topRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Top));
        var middleRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Middle));
        var bottomRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Bottom));

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : SymbolAsChar.Space;
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