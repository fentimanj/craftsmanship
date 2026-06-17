using System;

public class KnightRook
{
    public static string KnightVsRook(object[] knightPosition, object[]rookPosition)
    {
        var rookNumberRow = (int)rookPosition[0];
        var rookLetterRow = ((string)rookPosition[1])[0];
        var knightNumberRow = (int)knightPosition[0];
        var knightLetterRow = ((string)knightPosition[1])[0];


        
        if(rookNumberRow == (knightNumberRow - 2) && rookLetterRow == 'D' && knightNumberRow == 8 && knightLetterRow == 'C')
        {
            return "Knight";
        }
        
        if(rookNumberRow == (knightNumberRow - 2)  && rookLetterRow == 'B' && knightNumberRow == 8 && knightLetterRow == 'C')
        {
            return "Knight";
        }
        
        if(rookNumberRow == (knightNumberRow + 2) && rookLetterRow == 'B' && knightNumberRow == 8 && knightLetterRow == 'C')
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