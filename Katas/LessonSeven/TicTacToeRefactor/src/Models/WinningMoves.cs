namespace src.Models;

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
            Positions.MiddleLeft,
            Positions.MiddleCenter,
            Positions.MiddleRight
        };

        var bottomRow = new List<Position>
        {
            Positions.BottomLeft,
            Positions.BottomCenter,
            Positions.BottomRight
        };


        var diagonalTopLeftToBottomRight = new List<Position>
        {
            Positions.TopLeft,
            Positions.MiddleCenter,
            Positions.BottomRight
        };

        var diagonalTopRightToBottomLeft = new List<Position>
        {
            Positions.TopRight,
            Positions.MiddleCenter,
            Positions.BottomLeft
        };

        this.winningMoves = new List<List<Position>>
        {
            leftColumn,
            rightColumn,
            centerColumn,
            topRow,
            middleRow,
            bottomRow,
            diagonalTopLeftToBottomRight,
            diagonalTopRightToBottomLeft
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