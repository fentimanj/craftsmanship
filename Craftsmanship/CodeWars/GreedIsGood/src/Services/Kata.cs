namespace src.Services;

public static class Kata
{
    public static int Score(int[] dice) {

        if (dice.Count(die => die == 1) == 1)
        {
            return 100 * dice.Count(die => die == 1);
        }    
        
        if (dice.Count(die => die == 5) == 1)
        {
            return 50 ;
        }        
        
        if (dice.Count(die => die == 1) == 2)
        {
            return 100  * dice.Count(die => die == 1);
        }  
        
        if (dice.Count(die => die == 5) == 2)
        {
            return 100;
        }
        // Fill me in!
        return 0;
    }
}