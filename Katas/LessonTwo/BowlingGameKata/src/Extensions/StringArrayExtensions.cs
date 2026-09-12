namespace src.Extensions;

using Models;

internal static class StringArrayExtensions
{
    internal static IEnumerable<BowlingSet> MapSets(this string[] splitScoreCardString)
    {
        var oneBallScoreSet = splitScoreCardString.Where(set => set.Length == 1);
        var twoBallScoreSets = splitScoreCardString.Where(set => set.Length == 2);

        var singleBallScoreCards = HandleStrikeOrDoubleMiss(oneBallScoreSet);

        var twoBallScoreCards = twoBallScoreSets
            .Select(scoreCard => scoreCard.Replace("-", "0"))
            .Select(scoreCard =>
            {
                const int firstBall = 1;
                const char spare = '/';
                
                return scoreCard[firstBall] == spare
                    ? new BowlingSet(10, 0)
                    : new BowlingSet(int.Parse($"{scoreCard[0]}"), int.Parse($"{scoreCard[1]}"));
            });
        
        return singleBallScoreCards.Concat(twoBallScoreCards);
    }

    private static IEnumerable<BowlingSet> HandleStrikeOrDoubleMiss(IEnumerable<string> oneBallScoreSet)
    {
        return oneBallScoreSet
            .Select(scoreCard => scoreCard.Replace("X", "10"))
            .Select(convertedScores => new BowlingSet(int.Parse(convertedScores), 0));
    }
}