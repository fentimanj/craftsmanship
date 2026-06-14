using System;

public class Kata
{
    public static bool One(int[] arr, Func<int, bool> fun)
    {
        if(arr.Where(value => fun(value)).Any())
           return true;

        return false; 
    }
}