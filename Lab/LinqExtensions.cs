using System;
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
    }
}