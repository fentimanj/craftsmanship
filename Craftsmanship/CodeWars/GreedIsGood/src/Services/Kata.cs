namespace src.Services;

public static class Kata
{
    public static int Score(int[] dice) {

        if (dice.Count(dice => dice == 1) == 1)
        {
            return 100;
        }    
        
        if (dice.Count(dice => dice == 5) == 1)
        {
            return 50;
        }        
        
        if (dice.Count(dice => dice == 1) == 2)
        {
            return 200;
        }
        // Fill me in!
        return 0;
    }
}