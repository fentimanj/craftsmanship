namespace src.Services;

using Models;

public class BowlingScoreService
{
    private readonly int _ballsPerSet = 2;

    public int CalculateScore(string rawScoreCard)
    {
        var cleansedScoreString = rawScoreCard.Replace("-", "0");
        var splitScoreCardString = cleansedScoreString.Split("|");

        var scoringSets = MapSets(splitScoreCardString);

        return scoringSets.Sum(set => set.FirstBallScore + set.SecondBallScore);
    }

    private IEnumerable<BowlingSet> MapSets(string[] splitScoreCardString)
    {
        return splitScoreCardString.Where(set => set.Length == _ballsPerSet).Select(set => new BowlingSet(int.Parse($"{set[0]}"), int.Parse($"{set[1]}")));
    }
}