namespace src.Extensions;

using Models;

internal static class StringArrayExtensions
{
    internal static IEnumerable<BowlingSet> MapSets(this string[] splitScoreCardString)
    {
        var oneCallScoreSet = splitScoreCardString.Where(set => set.Length == 1);
        var twoBallScoreSets = splitScoreCardString.Where(set => set.Length == 2);

        var singleBallScoreCards = oneCallScoreSet
            .Select(scoreCard => scoreCard.Replace("X", "10"))
            .Select(convertedScores => new BowlingSet(int.Parse(convertedScores), 0));

        var twoBallScoreCards = twoBallScoreSets
            .Select(scoreCard => scoreCard.Replace("-", "0"))
            .Select(scoreCard =>
            {
                if (scoreCard[1] == '/')
                {
                    return new BowlingSet(10, 0);
                }
                return new BowlingSet(int.Parse($"{scoreCard[0]}"), int.Parse($"{scoreCard[1]}"));
            });
        
        return singleBallScoreCards.Concat(twoBallScoreCards);
    }
}