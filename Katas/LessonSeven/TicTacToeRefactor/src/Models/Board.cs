namespace src.Models;

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
                var positionNew = new Position(column, row);
                this.tiles.Add(new Tile(Symbol.Space, positionNew));
            }
        }
    }

    public Symbol HasWinner()
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

    private Symbol ColumnTakenBy(Column columnIndex)
    {
        if (columnIndex == Column.Left)
        {
            var leftColumn = new[]
            {
                new Position(Column.Left, Row.Top),
                new Position(Column.Left, Row.Middle),
                new Position(Column.Left, Row.Bottom)
            };
            
            if(leftColumn.All(col => SymbolAt(col) == Symbol.X)) return Symbol.X;
            if(leftColumn.All(col => SymbolAt(col) == Symbol.O)) return Symbol.O;
            if(leftColumn.All(col => SymbolAt(col) == Symbol.Space)) return Symbol.Space;
        }


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

    public void AddTileAt(Symbol symbol, Position position)
    {
        var currentTile = this.tiles.Single(Tile.IsAt(position));
        currentTile.AddSymbol(symbol);
        ;
    }
}