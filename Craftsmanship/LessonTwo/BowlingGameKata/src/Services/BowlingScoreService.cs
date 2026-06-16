namespace src.Services;

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        if (scoreString.Contains("01")) return int.Parse($"{scoreString[1]}");

        if (scoreString.Contains("02")) return int.Parse($"{scoreString[1]}");

        if (scoreString.Contains("03")) return int.Parse($"{scoreString[1]}");

        var score = int.Parse(scoreString.Substring(0, 1));
        return score;
    }
}