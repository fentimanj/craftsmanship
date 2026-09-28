namespace src;

using Constant;
using Enums;

public class Board
{
    private readonly List<Tile> tiles = [];

    private readonly List<(Position firstPosition, Position secondPosition, Position thirdPosition)> winningLines =
        new()
        {
            new ValueTuple<Position, Position, Position>(Position.TopLeft, Position.TopCenter, Position.TopRight),
            new ValueTuple<Position, Position, Position>(Position.MiddleLeft, Position.MiddleCenter,
                Position.MiddleRight),
            new ValueTuple<Position, Position, Position>(Position.BottomLeft, Position.BottomCenter,
                Position.BottomRight),
            new ValueTuple<Position, Position, Position>(Position.TopLeft, Position.MiddleCenter, Position.BottomRight),
            new ValueTuple<Position, Position, Position>(Position.TopRight, Position.MiddleCenter, Position.BottomLeft),
            new ValueTuple<Position, Position, Position>(Position.TopLeft, Position.MiddleLeft, Position.BottomLeft),
            new ValueTuple<Position, Position, Position>(Position.TopRight, Position.MiddleRight, Position.BottomRight),
            new ValueTuple<Position, Position, Position>(Position.TopCenter, Position.MiddleCenter,
                Position.BottomCenter)
        };

    public Board()
    {
        foreach (var position in Enum.GetValues<Position>())
        {
            this.tiles.Add(new Tile(position));
        }
    }

    public char HasWinner()
    {
        foreach (var winningLine in this.winningLines)
        {
            var winner = this.LineTaken(winningLine.firstPosition, winningLine.secondPosition,
                winningLine.thirdPosition);
            if (winner != SymbolAsChar.Space)
            {
                return winner;
            }
        }

        return SymbolAsChar.Space;
    }


    private char LineTaken(Position firstPosition, Position secondPosition, Position thirdPosition)
    {
        var firstSymbol = this.SymbolAt(firstPosition);
        var secondSymbol = this.SymbolAt(secondPosition);
        var thirdSymbol = this.SymbolAt(thirdPosition);

        var columnTaken = firstSymbol == secondSymbol && secondSymbol == thirdSymbol;

        return columnTaken ? firstSymbol : SymbolAsChar.Space;
    }

    private char SymbolAt(Position position)
    {
        return this.tiles.Single(Tile.IsAt(position)).Symbol;
    }

    // TODO: Data Clump
    public void AddTileAt(char symbol, Position position)
    {
        if (this.IsTileTaken(position))
        {
            throw new Exception("Invalid position");
        }

        var currentTile = this.tiles.Single(Tile.IsAt(position));
        currentTile.Symbol = symbol;
    }

    // TODO: data clump
    // TODO: primitive obsession
    private bool IsTileTaken(Position position)
    {
        var symbol = this.SymbolAt(position);
        return symbol != SymbolAsChar.Space;
    }
}