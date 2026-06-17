using System;

public class KnightRook
{
    public static string KnightVsRook(object[] rawknightPosition, object[]rawrookPosition)
    {
        var rookPosition = new Position(rawrookPosition);

        var knightLetterRow = (int)((string)rawknightPosition[1])[0];
        var knightPosition = new Position(rawknightPosition);
        
        if((rookPosition.Row == (knightPosition.Row - 2) || rookPosition.Row == (knightPosition.Row + 2) ) && (rookPosition.Column == (knightLetterRow + 1) || rookPosition.Column == (knightPosition.Column - 1) ) )
        {
            return "Knight";
        }
        
        if (knightPosition.IsInReachOfRook(rookPosition))
        {
            return "Rook";
        }

        return "None";
    }

    private static bool IsInReachOfRook(Position knightPosition, Position rookPosition)
    {
        return rookPosition.Row == knightPosition.Row || rookPosition.Column == knightPosition.Column;
    }
}

public static class PositionExtensions
{
    public static bool IsInReachOfRook(this Position knightPosition, Position rookPosition)
    {
        return rookPosition.Row == knightPosition.Row || rookPosition.Column == knightPosition.Column;
    }
}

public class Position(object[] rawPosition)
{
    public int Row { get; } = (int)rawPosition[0];
    public int Column { get; } = ((string)rawPosition[1])[0];
}