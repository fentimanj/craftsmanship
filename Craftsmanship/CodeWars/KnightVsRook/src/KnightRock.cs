public class KnightRook
{
    public static string KnightVsRook(object[] rawKnightPosition, object[] rawRookPosition)
    {
        var rookPosition = new Position(rawRookPosition);
        var knightPosition = new Position(rawKnightPosition);

        if (rookPosition.IsWithinReachOfKnight(knightPosition))
        {
            return "Knight";
        }

        if (knightPosition.IsInReachOfRook(rookPosition))
        {
            return "Rook";
        }

        return "None";
    }
}

public static class PositionExtensions
{
    public static bool IsInReachOfRook(this Position knightPosition, Position rookPosition)
    {
        return rookPosition.Row == knightPosition.Row || rookPosition.Column == knightPosition.Column;
    }

    public static bool IsWithinReachOfKnight(this Position rookPosition, Position knightPosition)
    {
        return (rookPosition.Row == knightPosition.Row.TwoToLeft() || rookPosition.Row == knightPosition.Row + 2 ) && (rookPosition.Column == knightPosition.Column + 1 || rookPosition.Column == knightPosition.Column - 1 );
    }

    private static int TwoToLeft(this int rowInt)
    {
        return rowInt - 2;
    }
    
    private static int TwoToRight(this int rowInt)
    {
        return rowInt - 2;
    }
}

public class Position(object[] rawPosition)
{
    public int Row { get; } = (int)rawPosition[0];
    public int Column { get; } = ((string)rawPosition[1])[0];
}