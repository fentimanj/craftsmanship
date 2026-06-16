namespace src.Services;

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        if (scoreString[1] == '|')
        {
            return 0;
        }
        
        if (scoreString[1] != '|' && scoreString[1] != '-')
        {
            var firstBallPinsAsString = $"{scoreString[0]}";
            var secondBallPinsAsString = $"{scoreString[1]}";
            return int.Parse(firstBallPinsAsString) + int.Parse(secondBallPinsAsString);
        }

        var score = int.Parse(scoreString.Substring(0, 1));
        return score;
    }
}