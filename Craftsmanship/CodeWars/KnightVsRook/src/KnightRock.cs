using src.Extensions;
using src.Models;

namespace src;

public static class KnightRook
{
    public static string KnightVsRook(object[] rawKnightPosition, object[] rawRookPosition)
    {
        var rookPosition = new Position(rawRookPosition);
        var knightPosition = new Position(rawKnightPosition);
        
        if(rookPosition.IsWithinReachOfKnight(knightPosition))
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