namespace src.Models;

using Constant;
using Enums;

public class WinningMoves
{
    private readonly List<List<Position>> winningMoves;

    public WinningMoves()
    {
        var leftColumn = new List<Position>
        {
            new(Column.Left, Row.Top),
            new(Column.Left, Row.Middle),
            new(Column.Left, Row.Bottom)
        };
        var rightColumn = new List<Position>
        {
            new(Column.Right, Row.Top),
            new(Column.Right, Row.Middle),
            new(Column.Right, Row.Bottom)
        };

        var centerColumn = new List<Position>
        {
            new(Column.Center, Row.Top),
            new(Column.Center, Row.Middle),
            new(Column.Center, Row.Bottom)
        };

        var topRow = new List<Position>
        {
            new(Column.Left, Row.Top),
            new(Column.Center, Row.Top),
            new(Column.Right, Row.Top)
        };

        this.winningMoves = new List<List<Position>>
        {
            leftColumn, rightColumn, centerColumn, topRow
        };
    }

    public Symbol CheckForWinningSymbol(List<Tile> tiles)
    {
        
        foreach (var winningMove in this.winningMoves)
        {
            if (winningMove.All(col => this.SymbolAt(col, tiles) == Symbol.X))
            {
                return Symbol.X;
            }

            if (winningMove.All(col => this.SymbolAt(col, tiles) == Symbol.O))
            {
                return Symbol.O;
            }
        }
        
        return Symbol.Space;
    }
    
    private Symbol SymbolAt(Position position, List<Tile> tiles)
    {
        var tile = tiles.Single(Tile.IsAt(position));
        return tile.GetSymbol();
    }
}