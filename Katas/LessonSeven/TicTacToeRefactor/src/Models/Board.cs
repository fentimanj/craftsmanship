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

    public char HasWinnerAsChar()
    {
        for (var index = Column.Left; index <= Column.Right; index++)
        {
            var winner = this.ColumnTakenByChar(index);
            if (winner != SymbolAsChar.Space)
            {
                return winner;
            }
        }

        return SymbolAsChar.Space;
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

    private char ColumnTakenByChar(Column columnIndex)
    {
        var topRowSymbol = this.SymbolAsCharAt(new Position(columnIndex, Row.Top));
        var middleRowSymbol = this.SymbolAsCharAt(new Position(columnIndex, Row.Middle));
        var bottomRowSymbol = this.SymbolAsCharAt(new Position(columnIndex, Row.Bottom));

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : SymbolAsChar.Space;
    }

    private Symbol ColumnTakenBy(Column columnIndex)
    {
        var topRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Top));
        var middleRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Middle));
        var bottomRowSymbol = this.SymbolAt(new Position(columnIndex, Row.Bottom));

        var columnTaken = topRowSymbol == middleRowSymbol && middleRowSymbol == bottomRowSymbol;

        return columnTaken ? topRowSymbol : Symbol.Space;
    }
    
    private char SymbolAsCharAt(Position position)
    {
        var tile = this.tiles.Single(Tile.IsAt(position));
        return tile.GetSymbolAsChar();  
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
}