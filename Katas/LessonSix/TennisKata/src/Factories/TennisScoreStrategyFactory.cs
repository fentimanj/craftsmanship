namespace src.Factories;

using Enums;
using Strategies;

public class TennisScoreStrategyFactory
{
    public ITennisScoringStrategy GetStrategy(GameState scoreType)
    {
        if (scoreType == GameState.Advantage)
        {
            return new AdvantageStrategy();
        }

        if (scoreType == GameState.Tied)
        {
            return new InProgress();
        }

        if (scoreType == GameState.InProgress)
        {
            return new TiedStrategy();
        }
        
        throw new ArgumentOutOfRangeException(nameof(scoreType));
    }
}