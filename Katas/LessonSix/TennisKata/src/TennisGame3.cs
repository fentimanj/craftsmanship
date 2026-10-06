using src;

public class TennisGame3 : ITennisGame
{
    private readonly string p1N;
    private readonly string p2N;
    private int p1;
    private int p2;

    public TennisGame3(string player1Name, string player2Name)
    {
        this.p1N = player1Name;
        this.p2N = player2Name;
    }

    public string GetScore()
    {
        string s;
        if (this.p1 < 4 && this.p2 < 4 && this.p1 + this.p2 < 6)
        {
            string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
            s = p[this.p1];
            return this.p1 == this.p2 ? s + "-All" : s + "-" + p[this.p2];
        }

        if (this.p1 == this.p2)
        {
            return "Deuce";
        }

        s = this.p1 > this.p2 ? this.p1N : this.p2N;
        return (this.p1 - this.p2) * (this.p1 - this.p2) == 1 ? "Advantage " + s : "Win for " + s;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
        {
            this.p1 += 1;
        }
        else
        {
            this.p2 += 1;
        }
    }
}