namespace src.Models;

using Constant;
using Enums;
using Extensions;

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
                this.tiles.Add(new Tile(Symbol.Space, positionNew));
            }
        }
    }

    public char HasWinner() //Public interface so can't be changed
    {
        for (var index = Column.Left; index <= Column.Right; index++)
        {
            var winner = this.ColumnTakenBy(index);
            if (winner != Symbol.Space)
            {
                return winner.SymbolToChar();
            }
        }

        return SymbolAsChar.Space;
    }

    private Symbol ColumnTakenBy(Column columnIndex)
    {
        var topRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Top));
        var middleRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Middle));
        var bottomRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Bottom));

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : Symbol.Space;
    }

    private Symbol SymbolAt(Position position)
    {
        var tile = this.tiles.Single(Tile.IsAt(position));
        return tile.GetSymbol();
    }

    public void AddCharTileAt(char symbol, Position position)
    {
        var currentTile = this.tiles.Single(Tile.IsAt(position));
        currentTile.AddSymbol(symbol);
    }

    public void AddTileAt(Symbol symbol, Position position)
    {
        var currentTile = this.tiles.Single(Tile.IsAt(position));
        currentTile.AddSymbo(symbol);;
    }
}
