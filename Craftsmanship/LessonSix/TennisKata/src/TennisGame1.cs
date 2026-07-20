namespace src;

public class TennisGame1 : ITennisGame
{
    private int playerOnePoints;
    private int playerTwoPoints;
    private string player1Name;
    private string player2Name;

    public TennisGame1(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
            this.playerOnePoints += 1;
        else
            this.playerTwoPoints += 1;
    }

    public string GetScore()
    {
        string score = "";
        var tempScore = 0;  //This looks wrong
        if (this.playerOnePoints == this.playerTwoPoints)  // This is a tie
        {
            switch (this.playerOnePoints)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default: //Dodgy
                    score = "Deuce";
                    break;
            }
        }
        else if (this.playerOnePoints >= 4 || this.playerTwoPoints >= 4)  // What is 4? 
        {
            var playerOneHasAnAdvantageOf = this.playerOnePoints - this.playerTwoPoints; 
            if (playerOneHasAnAdvantageOf == 1) score = "Advantage player1";
            else if (playerOneHasAnAdvantageOf == -1) score = "Advantage player2";
            else if (playerOneHasAnAdvantageOf >= 2) score = "Win for player1";
            else score = "Win for player2";
        }
        else
        {
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = this.playerOnePoints;
                else
                {
                    score += "-";
                    tempScore = this.playerTwoPoints;
                }

                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }
        }

        return score;
    }
}