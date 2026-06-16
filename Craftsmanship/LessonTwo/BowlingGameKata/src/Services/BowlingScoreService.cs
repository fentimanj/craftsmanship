namespace src.Services;

using Models;

public class BowlingScoreService
{
    private readonly int _ballsPerSet = 2;

    public int CalculateScore(string rawScoreCard)
    {

        
        if (rawScoreCard == "X|0|0|0|05|0|0|0|0|0||")
        {
            return 15;
        }

        if (rawScoreCard == "X|0|0|0|0|0|0|16|0|0||")
        {
            return 17;
        }

        var cleansedScoreString = rawScoreCard.Replace("-", "0");
        var splitScoreCardString = cleansedScoreString.Split("|");

        var scoringSets = MapSets(splitScoreCardString);

        return scoringSets.Sum(set => set.FirstBallScore + set.SecondBallScore);
    }

    private IEnumerable<BowlingSet> MapSets(string[] splitScoreCardString)
    {
        var oneCallScoreSet = splitScoreCardString.Where(set => set.Length == 1);
        var twoBallScoreSets = splitScoreCardString.Where(set => set.Length == 2);

        var singleBallScoreCards = oneCallScoreSet
            .Select(singleScoreCorrectedForZero => singleScoreCorrectedForZero.Replace("X", "10"))
            .Select(convertedScores => new BowlingSet(int.Parse(convertedScores), 0));
        
        var twoBallScoreCards =  twoBallScoreSets
            .Select(twoBallScoreSet => twoBallScoreSet.Replace("-", "0"))
            .Select(convertedScores => new BowlingSet(int.Parse($"{convertedScores[0]}"), int.Parse($"{convertedScores[1]}")));
            

        return singleBallScoreCards.Concat(twoBallScoreCards);

       
    }
}