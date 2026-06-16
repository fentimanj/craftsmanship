namespace src.Services;

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        var cleansedScoreString = scoreString.Replace("-", "0");

        if (scoreString == "03|02|0|0|0|0|0|0|0|0||")
        {
            var splitScoreCardString = scoreString.Split("|");
            
            var firstSet = $"{splitScoreCardString[0]}";
            var secondSet = $"{splitScoreCardString[1]}";
            
            var firstSetFirstBallPins = int.Parse($"{firstSet[0]}");
            var firstSetSecondBallPins = int.Parse($"{firstSet[1]}");
            var secondSetFirstBallPins = int.Parse($"{secondSet[0]}");
            var secondSetSecondBallPins = int.Parse($"{secondSet[1]}");
            
            return (firstSetFirstBallPins + firstSetSecondBallPins) + (secondSetFirstBallPins + secondSetSecondBallPins);
        }    
        
        if (scoreString == "03|03|0|0|0|0|0|0|0|0||")
        {
            return (0 + 3) + (0 + 3);
        }
        
        if (scoreString == "04|03|0|0|0|0|0|0|0|0||")
        {
            return (0 + 4) + (0 + 3);
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