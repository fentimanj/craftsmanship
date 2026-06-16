namespace src.Services;

using Extensions;

public class BowlingScoreService
{
    public static int CalculateScore(string rawScoreCard)
    {
        var splitScoreCardString = rawScoreCard.Replace(" ", "").Split("|");

        var scoringSets = splitScoreCardString.MapSets();

        return scoringSets.Sum(set => set.FirstBallScore + set.SecondBallScore);
    }
}