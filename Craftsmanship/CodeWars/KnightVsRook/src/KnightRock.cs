using System;

public class KnightRook
{
    public static string KnightVsRook(object[] knightPosition, object[]rookPosition)
    {
        var rookNumberRow = (int)rookPosition[0];
        var rookLetterRow = (int)((string)rookPosition[1])[0];
        var knightNumberRow = (int)knightPosition[0];
        var knightLetterRow = (int)((string)knightPosition[1])[0];
        
        if((rookNumberRow == (knightNumberRow - 2)|| rookNumberRow == (knightNumberRow + 2) )&& (rookLetterRow == (knightLetterRow + 1) || rookLetterRow == (knightLetterRow - 1) ) )
        {
            return "Knight";
        }
        
        if (rookNumberRow == knightNumberRow || rookLetterRow == knightLetterRow)
        {
            return "Rook";
        }

        return "None";
    }
}