namespace src;

using Constant;

public class Board
{
    private readonly List<Tile> tiles = [];

    public Board()
    {
        foreach (var postition in Enum.GetValues<Position>())
        {
            this.tiles.Add(new Tile(Symbol.Space, postition));
        }
    }

    public char HasWinner()
    {
        var winner = this.ColumnTaken();
        if (winner != SymbolAsChar.Space)
        {
            return winner;
        }

        return SymbolAsChar.Space;
    }

    private char ColumnTaken()
    {
        var topLeftSymbol = this.SymbolAt(Position.TopLeft);
        var middleLeftSymbol = this.SymbolAt(Position.MiddleLeft);
        var bottomLeftSymbol = this.SymbolAt(Position.BottomLeft);

        var leftColumnTaken = topLeftSymbol == middleLeftSymbol && middleLeftSymbol == bottomLeftSymbol;

        if (leftColumnTaken && topLeftSymbol != Symbol.Space)
        {
            return topLeftSymbol.ToChar();
        }


        var topCenterSymbol = this.SymbolAt(Position.TopCenter);
        var middleCenterSymbol = this.SymbolAt(Position.MiddleCenter);
        var bottomCenterSymbol = this.SymbolAt(Position.BottomCenter);

        var centreColumnTaken = topCenterSymbol == middleCenterSymbol && middleCenterSymbol == bottomCenterSymbol;

        if (centreColumnTaken && topCenterSymbol != Symbol.Space)
        {
            return topCenterSymbol.ToChar();
        }


        var topRightSymbol = this.SymbolAt(Position.TopRight);
        var middleRightSymbol = this.SymbolAt(Position.MiddleRight);
        var bottomRightSymbol = this.SymbolAt(Position.BottomRight);

        var rightColumnTaken = topRightSymbol == middleRightSymbol && middleRightSymbol == bottomRightSymbol;

        return rightColumnTaken ? topRightSymbol.ToChar() : Symbol.Space.ToChar();
    }

    private Symbol SymbolAt(Position position)
    {
        var tile = this.tiles.Single(Tile.IsAt(position));
        return tile.GetSymbol();
    }

    public void AddTileAt(Symbol symbol, Position position)
    {
        if (this.IsTileTaken(position))
        {
            throw new Exception("Invalid position");
        }

        var currentTile = this.tiles.Single(Tile.IsAt(position));
        currentTile.MarkWith(symbol);
    }

    private bool IsTileTaken(Position position)
    {
        var symbol = this.SymbolAt(position);
        return symbol != Symbol.Space;
    }
}