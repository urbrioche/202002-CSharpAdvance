using System;
using System.Collections.Generic;

static internal class lin
{
    public static TSource JoeyFirst<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            if (predicate(current))
            {
                return current;
            }
        }

        throw new InvalidOperationException($"{nameof(source)} is empty");
    }
}