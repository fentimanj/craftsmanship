namespace src;

using Constant;

public class Board
{
    private readonly List<Tile> tiles = [];
    private readonly int numberOfRows = 3;
    private readonly int numberOfColumns = 3;

    public Board()
    {
        foreach (var postition in Enum.GetValues<Position>())
        {
            this.tiles.Add(new(SymbolAsChar.Space, postition));
        }
        
    }

    public char HasWinner()
    {
        for (var index = Column.Left; index <= Column.Right; index++)
        {
            var winner = this.RowTakenBy(index);
            if (winner != SymbolAsChar.Space)
            {
                return winner;
            }
        }

        return SymbolAsChar.Space;
    }

    private char RowTakenBy(int columnIndex)
    {
        if (columnIndex == Column.Left)
        {
            var topLeftSymbol = this.SymbolAt(Position.TopLeft);
            var middleLeftSymbol = this.SymbolAt(Position.MiddleLeft);
            var bottomLeftSymbol = this.SymbolAt(Position.BottomLeft);

            var rowTaken = topLeftSymbol == middleLeftSymbol && middleLeftSymbol == bottomLeftSymbol;

            return rowTaken ? topLeftSymbol : SymbolAsChar.Space;
        }

        if (columnIndex == Column.Center)
        {
            var topCenterSymbol = this.SymbolAt(Position.TopCenter);
            var middleCenterSymbol = this.SymbolAt(Position.MiddleCenter);
            var bottomCenterSymbol = this.SymbolAt(Position.BottomCenter);
            
            var rowTaken = topCenterSymbol == middleCenterSymbol && middleCenterSymbol == bottomCenterSymbol;
            
            return rowTaken ? topCenterSymbol : SymbolAsChar.Space;
        }

        if (columnIndex == Column.Right)
        {
            var topRightSymbol = this.SymbolAt(Position.TopRight);
            var middleRightSymbol = this.SymbolAt(Position.MiddleRight);
            var bottomRightSymbol = this.SymbolAt(Position.BottomRight);
            
            var rowTaken = topRightSymbol == middleRightSymbol && middleRightSymbol == bottomRightSymbol;
            
            return rowTaken ? topRightSymbol : SymbolAsChar.Space;
        }

        return  SymbolAsChar.Space;
    }

    private char SymbolAt(Position position)
    {
        var tile = this.tiles.Single(Tile.IsAt(position));
        return tile.GetSymbol().ToChar();
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
        return symbol != SymbolAsChar.Space;
    }
}