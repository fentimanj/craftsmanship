namespace src.Extensions;

using Models;

internal static class StringArrayExtensions
{
    internal static IEnumerable<BowlingSet> MapSets(this string[] splitScoreCardString)
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