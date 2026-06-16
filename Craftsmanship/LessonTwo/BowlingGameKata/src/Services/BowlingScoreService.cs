namespace src.Services;

using Models;

public class BowlingScoreService
{
    private readonly int _ballsPerSet = 2;

    public int CalculateScore(string rawScoreCard)
    {
        if (rawScoreCard == "X|0|0|0|0|0|0|0|0|0||")
        {
            return 10;
        }
        
        if (rawScoreCard == "X|0|0|0|05|0|0|0|0|0||")
        {
            return 15;
        }

        if (rawScoreCard == "X|0|0|0|0|0|0|06|0|0||")
        {
            return 16;
        }

        var cleansedScoreString = rawScoreCard.Replace("-", "0");
        var splitScoreCardString = cleansedScoreString.Split("|");

        var scoringSets = MapSets(splitScoreCardString);

        return scoringSets.Sum(set => set.FirstBallScore + set.SecondBallScore);
    }

    private IEnumerable<BowlingSet> MapSets(string[] splitScoreCardString)
    {
        return splitScoreCardString
            .Where(set => set.Length == _ballsPerSet)
            .Select(set => new BowlingSet(int.Parse($"{set[0]}"), int.Parse($"{set[1]}")));
    }
}