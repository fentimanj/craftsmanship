namespace src;

using Enums;
using Factories;

public class TennisGame1(string player1Name, string player2Name) : ITennisGame
{
    private int playerOnePoints;
    private int playerTwoPoints;

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
        {
            this.playerOnePoints += 1;
        }
        else
        {
            this.playerTwoPoints += 1;
        }
    }

    public string GetScore()
    {
        var gameState = this.GetGameState();

        var factory = new TennisScoreStrategyFactory();
        var scoreStrategy = factory.GetStrategy(gameState);

        return scoreStrategy.GetScore(this.playerOnePoints, this.playerTwoPoints);
    }

    private GameState GetGameState()
    {
        GameState scoreType;
        if (this.IsATie())
        {
            scoreType = GameState.Tied;
        }
        else if (this.PlayerHasAdvantage())
        {
            scoreType = GameState.Advantage;
        }
        else
        {
            scoreType = GameState.InProgress;
        }

        return scoreType;
    }


    private bool PlayerHasAdvantage()
    {
        return this.playerOnePoints >= 4 || this.playerTwoPoints >= 4;
    }

    private bool IsATie()
    {
        return this.playerOnePoints == this.playerTwoPoints;
    }
}