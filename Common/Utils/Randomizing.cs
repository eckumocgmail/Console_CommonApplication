
using System;

public class Randomizing
{
    private static Random R = new Random();
    public static int GetRandomInt(int from, int to)
    {
        R.NextDouble();
        R.NextDouble();
        return (int)(Math.Floor(R.NextDouble() * (to - from)) + from);
    }

    public static dynamic GetRandomDate(DateTime now, DateTime dateTime)
    {
        TimeSpan uTimeSpan = (now - dateTime);
        return now.AddSeconds(Randomizing.GetRandomInt(0, uTimeSpan.Seconds - 1));
    }
}
