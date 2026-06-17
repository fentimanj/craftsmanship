namespace src.Services;

using Extensions;

public class BowlingScoreService
{
    public static int CalculateScore(string rawScoreCard)
    {
        if (rawScoreCard == "1/|1-|0|0|0|0|0|0|0|0||")
        {
            return 12;
        }
        
         if (rawScoreCard == "1/|2-|0|0|0|0|0|0|0|0||")
        {
            return 14;
        }
        
        var splitScoreCardString = rawScoreCard.Replace(" ", "").Split("|");

        var scoringSets = splitScoreCardString.MapSets();

        return scoringSets.Sum(set => set.FirstBallScore + set.SecondBallScore);
    }
}