namespace src.Services;

using Models;

public class BowlingScoreService
{
    public static int CalculateScore(string rawScoreCard)
    {
        var splitScoreCardString = rawScoreCard.Split("|");

        var scoringSets = MapSets(splitScoreCardString);

        return scoringSets.Sum(set => set.FirstBallScore + set.SecondBallScore);
    }

    private static IEnumerable<BowlingSet> MapSets(string[] splitScoreCardString)
    {
        var oneCallScoreSet = splitScoreCardString.Where(set => set.Length == 1);
        var twoBallScoreSets = splitScoreCardString.Where(set => set.Length == 2);

        var singleBallScoreCards = oneCallScoreSet
            .Select(singleScoreCorrectedForZero => singleScoreCorrectedForZero.Replace("X", "10"))
            .Select(convertedScores => new BowlingSet(int.Parse(convertedScores), 0));

        var twoBallScoreCards = twoBallScoreSets
            .Select(twoBallScoreSet => twoBallScoreSet.Replace("-", "0"))
            .Select(convertedScores =>
                new BowlingSet(int.Parse($"{convertedScores[0]}"), int.Parse($"{convertedScores[1]}")));


        return singleBallScoreCards.Concat(twoBallScoreCards);
    }
}