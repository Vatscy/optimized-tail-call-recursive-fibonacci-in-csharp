using System;

namespace Fib
{
  public static class Fib
  {
    private static long?[] _values = null;

    public static TailRec<long?> Calculate(long? n)
    {
      _values = new long?[(int)n.Value + 1];
      return Calculate(n, TailRec<long?>.Done);
    }

    private static TailRec<long?> Calculate(long? n, Func<long?, TailRec<long?>> k)
    {
      if (n == 0) return TailRec<long?>.Call(() => k(0));
      if (n == 1) return TailRec<long?>.Call(() => k(1));

      var m = _values[n.Value];
      if (m != null) return TailRec<long?>.Call(() => k(m));

      return TailRec<long?>.Call(() => Calculate(n - 1, x => {
        return TailRec<long?>.Call(() => Calculate(n - 2, y => {
          var z = x + y;
          _values[n.Value] = z;
          return TailRec<long?>.Call(() => k(z));
        }));
      }));
    }
  }
}
