namespace src;

using Constant;
using Enums;

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

    public char HasWinner()
    {
        for (var index = Column.Left; index <= Column.Right; index++)
        {
            var winner = this.ColumnTakenBy(index);
            if (winner != Symbol.Space)
            {
                return winner;
            }
        }

        return Symbol.Space;
    }

    private char ColumnTakenBy(int columnIndex)
    {
        var topRow = PositionExtentions.From(columnIndex, Row.Top);
        var middleRow = PositionExtentions.From(columnIndex, Row.Middle);
        var bottomRow = PositionExtentions.From(columnIndex, Row.Bottom);
        
        var topRowSymbol = this.SymbolAt(topRow);
        var middleRowSymbol = this.SymbolAt(middleRow);
        var bottomRowSymbol = this.SymbolAt(bottomRow);

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : Symbol.Space;
    }

    // TODO: Data Clump
    public char SymbolAt(Position position)
    {
        var (x,y) = position.ToCoordinate();
        var tile = this.tiles.Single(Tile.IsAt(x, y));
        return tile.Symbol;
    }

    // TODO: Data Clump
    public void AddTileAt(char symbol, Position position)
    {
        if (this.IsTileTaken(position))
        {
            throw new Exception("Invalid position");
        }
        var (x, y) = position.ToCoordinate();   
        var currentTile = this.tiles.Single(Tile.IsAt(x, y));
        currentTile.Symbol = symbol;
    }

    // TODO: data clump
    // TODO: primitive obsession
    private bool IsTileTaken(Position position)
    {
        var symbol = this.SymbolAt(position);
        return symbol != Symbol.Space;
    }
}