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
            return new TiedStrategy();
        }

        if (scoreType == GameState.InProgress)
        {
            return new InProgress();
        }
        
        throw new ArgumentOutOfRangeException(nameof(scoreType));
    }
}