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
                this.tiles.Add(new Tile { X = column, Y = row, Symbol = Symbol.Space });
            }
        }
    }

    public char ColumnTakenBy(int columnIndex)
    {
        var topRowSymbol = this.SymbolAt(columnIndex, Row.Top);
        var middleRowSymbol = this.SymbolAt(columnIndex, Row.Middle);
        var bottomRowSymbol = this.SymbolAt(columnIndex, Row.Bottom);
        
        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;
        
        return columnTaken ? topRowSymbol : Symbol.Space;
    }

    // TODO: Data Clump
    public char SymbolAt(int x, int y)
    {
        var tile = this.tiles.Single(Tile.IsAt(x, y));
        return tile.Symbol;
    }

    // TODO: Data Clump
    public void AddTileAt(char symbol, int x, int y)
    {
        if (this.IsTileTaken(x, y))
        {
            throw new Exception("Invalid position");
        }
        var currentTile = this.tiles.Single(Tile.IsAt(x, y));
        currentTile.Symbol = symbol;
    }
    
    // TODO: data clump
    // TODO: primitive obsession
    private bool IsTileTaken(int x, int y)
    {
        var symbol = this.SymbolAt(x, y);
        return symbol != Symbol.Space;
    }
}