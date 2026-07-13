namespace src.Models;

using Enums;

internal class Board
{
    private readonly Dictionary<Position, Symbol> symbols = new()
    {
        { Position.LeftTop, Symbol.Unknown },
        { Position.CentreTop, Symbol.Unknown },
        { Position.RightTop, Symbol.Unknown },

        { Position.LeftCentre, Symbol.Unknown },
        { Position.RightCentre, Symbol.Unknown },
        { Position.CentreCentre, Symbol.Unknown },

        { Position.LeftBottom, Symbol.Unknown },
        { Position.CentreBottom, Symbol.Unknown },
        { Position.RightBottom, Symbol.Unknown }
    };


    public void AddMove(Position position, Symbol symbol)
    {
        this.symbols[position] = symbol;
    }

    public Symbol WinningSymbol()
    {
        var leftTop = this.symbols[Position.LeftTop];
        var rightCentre = this.symbols[Position.RightCentre];
        var leftBottom = this.symbols[Position.LeftBottom];
        var leftCentre = this.symbols[Position.LeftCentre];

        if (leftCentre == leftTop && leftTop == leftBottom)
        {
            return leftTop;
        }

        if (leftTop == rightCentre && rightCentre == leftCentre)
        {
            return leftTop;
        }

        return Symbol.Unknown;
    }
}