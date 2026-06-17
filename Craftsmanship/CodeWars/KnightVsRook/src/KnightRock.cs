using System;

public class KnightRook
{
    public static string KnightVsRook(object[] rawknightPosition, object[]rawrookPosition)
    {
        var rookPosition = new Position(rawrookPosition);

        var knightLetterRow = (int)((string)rawknightPosition[1])[0];
        var knightPosition = new Position(rawknightPosition);
        
        if((rookPosition.NumberRow == (knightPosition.NumberRow - 2)|| rookPosition.NumberRow == (knightPosition.NumberRow + 2) )&& (rookPosition.LetterRow == (knightLetterRow + 1) || rookPosition.LetterRow == (knightPosition.LetterRow - 1) ) )
        {
            return "Knight";
        }
        
        if (rookPosition.NumberRow == knightPosition.NumberRow || rookPosition.LetterRow == knightPosition.LetterRow)
        {
            return "Rook";
        }

        return "None";
    }

    private static bool InReachOfRook(int rookNumberRow, int knightNumberRow, int rookLetterRow, int knightLetterRow)
    {
        return rookNumberRow == knightNumberRow || rookLetterRow == knightLetterRow;
    }
}

public class Position(object[] rawPosition)
{
    public int NumberRow { get; } = (int)rawPosition[0];
    public int LetterRow { get; } = ((string)rawPosition[1])[0];
}