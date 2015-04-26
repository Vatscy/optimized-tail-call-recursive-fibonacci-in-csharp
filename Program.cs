using System;

namespace Fib
{
public class Program
{
  public static void Main(string[] args)
  {
    var n = long.Parse(Console.ReadLine());

    long? result;
    var time = Measure(() => Fib.Calculate(n).Get(), out result);

    Console.WriteLine(result);
    Console.WriteLine(time);
  }

  public static TimeSpan Measure<T>(Func<T> func, out T result)
  {
    var startTime = DateTime.Now;
    result = func();
    return DateTime.Now - startTime;
  }
}
}