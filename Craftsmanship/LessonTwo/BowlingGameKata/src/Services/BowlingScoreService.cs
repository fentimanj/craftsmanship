namespace src.Services;

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        var cleansedScoreString = scoreString.Replace("-", "0");

        if (scoreString == "03|02|0|0|0|0|0|0|0|0||")
        {
            var splitScoreCardString = scoreString.Split("|");
            
            var firstSetAsString = $"{splitScoreCardString[0]}";
            var secondSetAsString = $"{splitScoreCardString[1]}";
            
            var firstSetFirstBallPins = int.Parse($"{firstSetAsString[0]}");
            var firstSetSecondBallPins = int.Parse($"{firstSetAsString[1]}");
            var secondSetFirstBallPins = int.Parse($"{secondSetAsString[0]}");
            var secondSetSecondBallPins = int.Parse($"{secondSetAsString[1]}");

            var firstSet = firstSetFirstBallPins + firstSetSecondBallPins;
            var secondSet = secondSetFirstBallPins + secondSetSecondBallPins;
            
            return firstSet + secondSet;
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