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
                this.tiles.Add(new Tile(SymbolAsChar.Space, column, row));
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
        var topRowSymbol = this.SymbolAt(PositionMapper.Map(columnIndex, Row.Top));
        var middleRowSymbol = this.SymbolAt(PositionMapper.Map(columnIndex, Row.Middle));
        var bottomRowSymbol = this.SymbolAt(PositionMapper.Map(columnIndex, Row.Bottom));

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : SymbolAsChar.Space;
    }

    // TODO: Data Clump
    private char SymbolAt(Position position)
    {
        var tile = this.tiles.Single(Tile.IsAt(position));
        return tile.GetSymbol().ToChar();
    }

    // TODO: Data Clump
    // TODO: Primitive Obsession
    public void AddTileAt(Symbol symbol, int x, int y)
    {
        if (this.IsTileTaken(PositionMapper.Map(x, y)))
        {
            throw new Exception("Invalid position");
        }

        var currentTile = this.tiles.Single(Tile.IsAt(PositionMapper.Map(x, y)));
        currentTile.MarkWith(symbol);
    }

    // TODO: data clump
    // TODO: primitive obsession
    private bool IsTileTaken(Position position)
    {
        var symbol = this.SymbolAt(position);
        return symbol != SymbolAsChar.Space;
    }
}