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
            Positions.TopLeft,
            Positions.MiddleLeft,
            Positions.BottomLeft
        };
        var rightColumn = new List<Position>
        {
            Positions.TopRight,
            Positions.MiddleRight,
            Positions.BottomRight
        };
            

        var centerColumn = new List<Position>
        {
            Positions.TopCenter,
            Positions.MiddleCenter,
            Positions.BottomCenter
        };

        var topRow = new List<Position>
        {
            Positions.TopLeft,
            Positions.TopCenter,
            Positions.TopRight
        };  
        
        var middleRow = new List<Position>
        {
            new(Column.Left, Row.Middle),
            new(Column.Center, Row.Middle),
            new(Column.Right, Row.Middle)
        };  
        
        var bottomRow = new List<Position>
        {
            new(Column.Left, Row.Bottom),
            new(Column.Center, Row.Bottom),
            new(Column.Right, Row.Bottom)
        };
        
        var diagnolTopLeftToBottomRight = new List<Position>
        {
            new(Column.Left, Row.Top),
            new(Column.Center, Row.Middle),
            new(Column.Right, Row.Bottom)
        };
        
        var diagnolTopRightToBottomLeft = new List<Position>
        {
            new(Column.Right, Row.Top),
            new(Column.Center, Row.Middle),
            new(Column.Left, Row.Bottom)
        };

        this.winningMoves = new List<List<Position>>
        {
            leftColumn, rightColumn, centerColumn, topRow,  middleRow, bottomRow, diagnolTopLeftToBottomRight,diagnolTopRightToBottomLeft
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