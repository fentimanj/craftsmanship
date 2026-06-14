
namespace src;

using System;
using System.Linq;

public static class Kata
{
    public static bool One(int[] arr, Func<int, bool> fun)
    {
        return arr.Count(fun) == 1;
    }
}