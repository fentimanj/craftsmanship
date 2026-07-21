namespace src;

using Strategies;

public class InProgress() : ITennisScoringStrategy
{
    public string GetScore(int playerOnePoints, int playerTwoPoints)
    {
        var pointsToWin = new Dictionary<int, string>
        {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" }
        };

        var player1Score = pointsToWin[playerOnePoints];
        var player2Score = pointsToWin[playerTwoPoints];
        return player1Score + "-" + player2Score;
    }
}