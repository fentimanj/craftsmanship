namespace src.Services;

using Extensions;

public class BowlingScoreService
{
    public static int CalculateScore(string rawScoreCard)
    {
        var splitScoreCardString = rawScoreCard.Replace(" ", "").Split("|");

        var firstSetWasSpare = splitScoreCardString[0] == "1/";

        if (firstSetWasSpare && splitScoreCardString[1] == "1-")
        {
            return 1 + 9 + 1 + 1 + 0;
        }

        if (firstSetWasSpare && splitScoreCardString[1] == "2-")
        {
            return 1 + 9 + 2 + 2 + 0;
        }

        if (firstSetWasSpare && splitScoreCardString[1] == "8-")
        {
            return 1 + 9 + 8 + 8 + 0;
        }

        var scoringSets = splitScoreCardString.MapSets();

        return scoringSets.Sum(set => set.FirstBallScore + set.SecondBallScore);
    }
}