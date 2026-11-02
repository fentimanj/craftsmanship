namespace TennisKata.src;

public interface ITennisGame
{
    void WonPoint(string playerName);
    string GetScore();
}