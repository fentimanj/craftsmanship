public class Kata
{
    public static bool One(int[] arr, Func<int, bool> fun)
    {
        if (arr.Where(value => fun(value)).Count() == 1)
            return true;

        return false;
    }
}