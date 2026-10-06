using src;

public class TennisGame2 : ITennisGame
{
    private int p1point;

    private string p1res = "";
    private int p2point;
    private string p2res = "";
    private string player1Name;
    private string player2Name;

    public TennisGame2(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.p1point = 0;
        this.player2Name = player2Name;
    }

    public string GetScore()
    {
        var score = "";
        if (this.p1point == this.p2point && this.p1point < 3)
        {
            if (this.p1point == 0)
            {
                score = "Love";
            }

            if (this.p1point == 1)
            {
                score = "Fifteen";
            }

            if (this.p1point == 2)
            {
                score = "Thirty";
            }

            score += "-All";
        }

        if (this.p1point == this.p2point && this.p1point > 2)
        {
            score = "Deuce";
        }

        if (this.p1point > 0 && this.p2point == 0)
        {
            if (this.p1point == 1)
            {
                this.p1res = "Fifteen";
            }

            if (this.p1point == 2)
            {
                this.p1res = "Thirty";
            }

            if (this.p1point == 3)
            {
                this.p1res = "Forty";
            }

            this.p2res = "Love";
            score = this.p1res + "-" + this.p2res;
        }

        if (this.p2point > 0 && this.p1point == 0)
        {
            if (this.p2point == 1)
            {
                this.p2res = "Fifteen";
            }

            if (this.p2point == 2)
            {
                this.p2res = "Thirty";
            }

            if (this.p2point == 3)
            {
                this.p2res = "Forty";
            }

            this.p1res = "Love";
            score = this.p1res + "-" + this.p2res;
        }

        if (this.p1point > this.p2point && this.p1point < 4)
        {
            if (this.p1point == 2)
            {
                this.p1res = "Thirty";
            }

            if (this.p1point == 3)
            {
                this.p1res = "Forty";
            }

            if (this.p2point == 1)
            {
                this.p2res = "Fifteen";
            }

            if (this.p2point == 2)
            {
                this.p2res = "Thirty";
            }

            score = this.p1res + "-" + this.p2res;
        }

        if (this.p2point > this.p1point && this.p2point < 4)
        {
            if (this.p2point == 2)
            {
                this.p2res = "Thirty";
            }

            if (this.p2point == 3)
            {
                this.p2res = "Forty";
            }

            if (this.p1point == 1)
            {
                this.p1res = "Fifteen";
            }

            if (this.p1point == 2)
            {
                this.p1res = "Thirty";
            }

            score = this.p1res + "-" + this.p2res;
        }

        if (this.p1point > this.p2point && this.p2point >= 3)
        {
            score = "Advantage player1";
        }

        if (this.p2point > this.p1point && this.p1point >= 3)
        {
            score = "Advantage player2";
        }

        if (this.p1point >= 4 && this.p2point >= 0 && this.p1point - this.p2point >= 2)
        {
            score = "Win for player1";
        }

        if (this.p2point >= 4 && this.p1point >= 0 && this.p2point - this.p1point >= 2)
        {
            score = "Win for player2";
        }

        return score;
    }

    public void WonPoint(string player)
    {
        if (player == "player1")
        {
            this.P1Score();
        }
        else
        {
            this.P2Score();
        }
    }

    public void SetP1Score(int number)
    {
        for (var i = 0; i < number; i++)
        {
            this.P1Score();
        }
    }

    public void SetP2Score(int number)
    {
        for (var i = 0; i < number; i++)
        {
            this.P2Score();
        }
    }

    private void P1Score()
    {
        this.p1point++;
    }

    private void P2Score()
    {
        this.p2point++;
    }
}