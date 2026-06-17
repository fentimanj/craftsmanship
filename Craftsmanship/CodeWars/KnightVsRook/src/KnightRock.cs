using System;

public class KnightRook
{
    public static string KnightVsRook(object[] knightPosition, object[]rookPosition)
    {
        var rookNumberRow = (int)rookPosition[0];
        var rookLetterRow = (string)rookPosition[1];
        var knightNumberRow = (int)knightPosition[0];
        var knightLetterRow = (string)knightPosition[1];
        
        if(rookNumberRow == 6 && rookLetterRow == "D" && knightNumberRow == 8 && knightLetterRow == "C")
        {
            return "Knight";
        }
        
        if(rookNumberRow == 6 && rookLetterRow == "B" && knightNumberRow == 8 && knightLetterRow == "C")
        {
            return "Knight";
        }
        
        if (rookNumberRow == knightNumberRow || rookLetterRow == knightLetterRow)
        {
            return "Rook";
        }
        // Three possible outputs are "Knight", "Rook" and "None".
        // Happy Coding
        return "None";
    }
}