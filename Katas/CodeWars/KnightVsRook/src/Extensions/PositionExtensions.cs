namespace src.Extensions;

using Models;

public static class PositionExtensions
{
    public static bool IsInReachOfRook(this Position knightPosition, Position rookPosition)
    {
        return rookPosition.Row == knightPosition.Row || rookPosition.Column == knightPosition.Column;
    }
    
    public static bool IsWithinReachOfKnight(this Position rookPosition, Position knightPosition)
    {
        return ((rookPosition.Row == knightPosition.Row - 2 || rookPosition.Row == knightPosition.Row + 2) &&
                (rookPosition.Column == knightPosition.Column + 1 || rookPosition.Column == knightPosition.Column - 1))
               ||
               ((rookPosition.Row == knightPosition.Row - 1 || rookPosition.Row == knightPosition.Row + 1) &&
                (rookPosition.Column == knightPosition.Column + 2 || rookPosition.Column == knightPosition.Column - 2));
    }
   
}