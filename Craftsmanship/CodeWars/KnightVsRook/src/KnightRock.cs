using System;

public class KnightRook
{
    public static string KnightVsRook(object[] knightPosition, object[]rookPosition)
    {
        if ((int)rookPosition[0] == (int)knightPosition[0])
        {
            return "Rook";
        }
        // Three possible outputs are "Knight", "Rook" and "None".
        // Happy Coding
        return "None";
    }
}