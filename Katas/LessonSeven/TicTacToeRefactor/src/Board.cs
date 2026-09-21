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
                this.tiles.Add(new Tile(SymbolAsChar.Space) { X = column, Y = row });
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

    private char ColumnTakenBy(int columnIndex)
    {
        var topRowSymbol = this.SymbolAt(columnIndex, Row.Top);
        var middleRowSymbol = this.SymbolAt(columnIndex, Row.Middle);
        var bottomRowSymbol = this.SymbolAt(columnIndex, Row.Bottom);

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : SymbolAsChar.Space;
    }

    // TODO: Data Clump
    public char SymbolAt(int x, int y)
    {
        var tile = this.tiles.Single(Tile.IsAt(x, y));
        return tile.GetSymbol();
    }

    // TODO: Data Clump
    public void AddTileAt(char symbol, int x, int y)
    {
        if (this.IsTileTaken(x, y))
        {
            throw new Exception("Invalid position");
        }

        var currentTile = this.tiles.Single(Tile.IsAt(x, y));
        currentTile.MarkWith(symbol);
    }

    // TODO: data clump
    // TODO: primitive obsession
    private bool IsTileTaken(int x, int y)
    {
        var symbol = this.SymbolAt(x, y);
        return symbol != SymbolAsChar.Space;
    }
}