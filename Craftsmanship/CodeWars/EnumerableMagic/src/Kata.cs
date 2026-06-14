using System;

public class Kata
{
    public static bool One(int[] arr, Func<int, bool> fun)
    {
        if(arr.Contains(1))
           return true;

        return false; 
    }
}