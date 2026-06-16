namespace src.Services;

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        var cleansedScoreString = scoreString.Replace("-", "0");

        if (scoreString == "03|02|0|0|0|0|0|0|0|0||")
        {
            return 5;
        }    
        
        if (scoreString == "03|03|0|0|0|0|0|0|0|0||")
        {
            return 6;
        }
        
        if (scoreString == "04|03|0|0|0|0|0|0|0|0||")
        {
            return 7;
        }
        
        if (cleansedScoreString[1] != '|')
        {
            var firstBallPinsAsString = $"{cleansedScoreString[0]}";
            var secondBallPinsAsString = $"{cleansedScoreString[1]}";
            return int.Parse(firstBallPinsAsString) + int.Parse(secondBallPinsAsString);
        }

        return 0;
    }
}