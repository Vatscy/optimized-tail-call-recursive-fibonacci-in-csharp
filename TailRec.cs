using System;
using System.Collections.Generic;

namespace Fib
{
  public class TailRec<T>
  {
    private readonly Func<TailRec<T>> _next;
    private readonly bool _done;
    private readonly T _result;

    private TailRec(Func<TailRec<T>> next, bool done, T result)
    {
      _next = next;
      _done = done;
      _result = result;
    }

    public T Get()
    {
      return this.Iterate(x => x._next()).Where(x => x._done).Select(x => x._result).First();
    }

    public static TailRec<T> Call(Func<TailRec<T>> next)
    {
      return new TailRec<T>(next, false, default(T));
    }

    public static TailRec<T> Done(T result)
    {
      return new TailRec<T>(() => null, true, result);
    }
  }
}
