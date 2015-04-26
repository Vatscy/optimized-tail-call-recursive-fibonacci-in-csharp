using System;
using System.Collections.Generic;

namespace Fib
{
public static class LinqExtensions
{
  public static IEnumerable<T> Iterate<T>(this T seed, Func<T, T> iterator)
  {
    var result = seed;
    while (!result.Equals(default(T))) {
      yield return result;
      result = iterator(result);
    }
  }

  public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
  {
    foreach (var x in source)
    {
      if (predicate(x))
      {
        yield return x;
      }
    }
  }

  public static IEnumerable<U> Select<T, U>(this IEnumerable<T> source, Func<T, U> selector)
  {
    foreach (var x in source)
    {
      yield return selector(x);
    }
  }

  public static T First<T>(this IEnumerable<T> source)
  {
    foreach (var x in source)
    {
      return x;
    }
    throw new IndexOutOfRangeException();
  }
}
}