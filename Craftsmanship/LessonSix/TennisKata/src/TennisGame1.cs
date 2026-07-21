namespace src;

public class TennisGame1 : ITennisGame
{
    private string player1Name;
    private string player2Name;
    private int playerOnePoints;
    private int playerTwoPoints;

    public TennisGame1(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

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
        var score = "";
        
        if (this.playerOnePoints == this.playerTwoPoints) // This is a tie
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
        else if (this.playerOnePoints >= 4 || this.playerTwoPoints >= 4)
        {
            var differenceInPoints = this.playerOnePoints - this.playerTwoPoints;
            if (differenceInPoints == 1)
            {
                score = "Advantage player1";
            }
            else if (differenceInPoints == -1)
            {
                score = "Advantage player2";
            }
            else if (differenceInPoints >= 2)
            {
                score = "Win for player1";
            }
            else
            {
                score = "Win for player2";
            }
        }
        else
        {
            for (var playerIndex = 1; playerIndex <= 2; playerIndex++)  //This goes around twice
            {
                var tempPoints = 0; //This looks wrong
                if (playerIndex == 1)
                {
                    tempPoints = this.playerOnePoints;
                }
                else
                {
                    score += "-";
                    tempPoints = this.playerTwoPoints;
                }

                switch (tempPoints)
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