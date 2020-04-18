using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return JoeyWhere(source, (item, index) => predicate(item));
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return JoeySelect(source, (item, index) => selector(item));
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            var index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current, index))
                {
                    yield return current;
                }

                index++;
            }
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            var index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current, index);
                index++;
            }
        }

        public static IEnumerable<TSource> JoeyTake<TSource>(this IEnumerable<TSource> employees, int count)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (index < count)
                {
                    yield return current;
                }
                else
                {
                    yield break;
                }

                index++;
            }
        }

        public static IEnumerable<TSource> JoeySkip<TSource>(this IEnumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (index >= count)
                {
                    yield return current;
                }
                index++;
            }
        }

        public static IEnumerable<TSource> JoeyTakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    yield return current;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<TSource> JoeySkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            var isStartTaking = false;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (!predicate(current) || isStartTaking)
                {
                    isStartTaking = true;
                    yield return current;
                }
                
            }
        }

        public static bool JoeyAny<TSource>(this IEnumerable<TSource> source)
        {
            return source.GetEnumerator().MoveNext();
        }

        public static bool JoeyAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool JoeyAll<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (!predicate(current))
                {
                    return false;
                }
            }

            return true;
        }

        public static TSource JoeyFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
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

        public static TSource JoeyFirst<TSource>(this IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }

            throw new InvalidOperationException($"{nameof(source)} is empty");
        }

        public static TSource JoeyLast<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            var last = default(TSource);
            var found = false;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    last = current;
                    found = true;
                }
            }

            if (found)
            {
                return last;
            }

            throw new InvalidOperationException();
        }

        public static TSource JoeyLast<TSource>(this IEnumerable<TSource> source)
        {
            return source.JoeyLast(employee => true);
        }

        public static TSource JoeyLastOrDefault<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            var last = default(TSource);
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    last = current;
                }
            }

            return last;
        }

        public static TSource JoeyLastOrDefault<TSource>(IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return default(TSource);
            }

            var last = enumerator.Current;
            while (enumerator.MoveNext())
            {
                last = enumerator.Current;
            }

            return last;
        }

        public static TSource JoeySingle<TSource>(this IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            var current = enumerator.Current;

            if (enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            return current;

        }

        public static IEnumerable<TSource> JoeyReverse<TSource>(this IEnumerable<TSource> source)
        {
            return new Stack<TSource>(source);
        }

        public static IEnumerable<TSource> JoeyDistinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> JoeyDistinct<TSource>(this IEnumerable<TSource> source)
        {
            return source.JoeyDistinct(EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> JoeyUnion<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var hashSet = new HashSet<TSource>();
            var firstEnumerator = first.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                var current = firstEnumerator.Current;
                if (hashSet.Add(current))
                {
                    yield return current;
                }
                
            }

            var secondEnumerator = second.GetEnumerator();
            while (secondEnumerator.MoveNext())
            {
                var current = secondEnumerator.Current;

                if (hashSet.Add(current))
                {
                    yield return current;
                }
            }
        }

        public static IEnumerable<TSource> JoeyIntersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var hashSet = new HashSet<TSource>(second);
            var enumerator = first.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (hashSet.Remove(current))
                {
                    yield return current;
                } 
            }
        }

        public static IEnumerable<TSource> JoeyExcept<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var hashSet = new HashSet<TSource>(second);
            var enumerator = first.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (hashSet.Add(current))
                {
                    yield return current;
                }
            }
        }

        public static IEnumerable<TSource> JoeySkipLast<TSource>(this IEnumerable<TSource> numbers, int count)
        {
            if (count <= 0)
            {
                return numbers;
            }


            return _(); IEnumerable<TSource> _()
            {
                var queue = new Queue<TSource>();
                var enumerator = numbers.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (queue.Count == count)
                    {
                        yield return queue.Dequeue();
                    }

                    queue.Enqueue(current);
                }

            }
            //var queue = new Queue<int>(numbers);

            //var enumerator = numbers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    if (queue.Count > count)
            //    {
            //        yield return queue.Dequeue();
            //    }
            //}
        }

        public static IEnumerable<IGrouping<TKey, TSource>> JoeyGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var enumerator = source.GetEnumerator();
            var myLookup = new MyLookup<TKey, TSource>();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                myLookup.AddElement(keySelector(current), current);
            }

            return myLookup;
        }

        public static bool JoeySequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var sendEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                var firstCurrent = firstEnumerator.Current;
                
                if (sendEnumerator.MoveNext())
                {
                    if (!EqualityComparer<TSource>.Default.Equals(firstCurrent, sendEnumerator.Current))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (sendEnumerator.MoveNext())
            {
                return false;
            }

            return true;

        }

        public static IEnumerable<TResult> JoeyJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, 
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector, 
            Func<TInner, TKey> innerKeySelector, 
            Func<TOuter, TInner, TResult> resultSelector)
        {
            var outerEnumerator = outer.GetEnumerator();
            var comparer = EqualityComparer<TKey>.Default;
            while (outerEnumerator.MoveNext())
            {
                var outerCurrent = outerEnumerator.Current;
                var innerEnumerator = inner.GetEnumerator();
                while (innerEnumerator.MoveNext())
                {
                    var innerCurrent = innerEnumerator.Current;
                    if (comparer.Equals(innerKeySelector(innerCurrent), outerKeySelector(outerCurrent)))
                    {
                        yield return resultSelector(outerCurrent, innerCurrent);
                    }
                }
            }
        }

        public static TAccumulate JoeyAggregate<TSource, TAccumulate>(this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                seed = func(seed, current);
            }

            return seed;
        }

        public static double? JoeyAverage(this IEnumerable<int?> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            var count = 0;
            double result = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.HasValue)
                {
                    result += current.Value;
                    count++;
                }
            }

            if (count == 0)
            {
                return null;
            }
            return result / count;
        }

        public static IEnumerable<T> JoeyCast<T>(this IEnumerable source)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return (T)current;
            }
        }

        public static IEnumerable<TSource> JoeyOfType<TSource>(this IEnumerable source)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current is TSource x)
                {
                    yield return x;
                }

            }
        }

        public static IEnumerable<TSource> JoeyAppend<TSource>(this IEnumerable<TSource> source, TSource element)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return current;
            }

            yield return element;
        }

        public static IEnumerable<TSource> JoeyConcat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var firstEnumerator = first.GetEnumerator();
            while (firstEnumerator.MoveNext())
            {
                yield return firstEnumerator.Current;
            }

            var secondEnumerator = second.GetEnumerator();
            while (secondEnumerator.MoveNext())
            {
                yield return secondEnumerator.Current;
            }
        }

        public static bool JoeyContains<TSource>(this IEnumerable<TSource> source, 
            TSource value, 
            IEqualityComparer<TSource> comparer)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (comparer.Equals(current, value))
                {
                    return true;
                }
            }

            return false;
        }

        public static int JoeyCount<TSource>(this IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            var count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }

        public static TSource JoeyElementAt<TSource>(this IEnumerable<TSource> source, int index)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (index == 0)
                {
                    return enumerator.Current;
                }
                index--;
            }

            throw new ArgumentOutOfRangeException();

        }
    }
}