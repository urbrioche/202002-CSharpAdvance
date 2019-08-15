using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static bool JoeyAll<TSource>(this IEnumerable<TSource> girls, Func<TSource, bool> predicate)
        {
            var enumerator = girls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!predicate(enumerator.Current)) return false;
            }

            return true;
        }

        public static bool JoeyAny<TSource>(this IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();
            return enumerator.MoveNext();
        }

        public static bool JoeyAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static double? JoeyAverage(this IEnumerable<int?> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            var result = 0;
            var count = 0;
            while (enumerator.MoveNext())
            {
                var number = enumerator.Current;
                if (number.HasValue)
                {
                    result += number.Value;
                    count++;
                }
            }

            return count == 0
                ? (double?) null
                : result / (double) count;
        }

        public static IEnumerable<Employee> JoeyDefaultIfEmpty(this IEnumerable<Employee> employees,
            Employee defaultEmployee)
        {
            return !employees.GetEnumerator().MoveNext()
                ? DefaultIfEmpty(defaultEmployee)
                : employees;
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

        public static TSource JoeyFirstOrDefault<TSource>(this IEnumerable<TSource> employees)
        {
            var enumerator = employees.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }

            return default(TSource);
        }

        public static TSource JoeyLast<TSource>(this IEnumerable<TSource> source)
        {
            var enumerator = source.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            var result = enumerator.Current;
            while (enumerator.MoveNext())
            {
                result = enumerator.Current;
            }

            return result;
        }

        public static Employee JoeyLastOrDefault(this IEnumerable<Employee> source, Func<Employee, bool> predicate)
        {
            var enumerator = source.GetEnumerator();

            var defaultResult = default(Employee);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                {
                    defaultResult = item;
                }
            }

            return defaultResult;
        }

        public static Employee JoeyLastOrDefault(this IEnumerable<Employee> source)
        {
            var defaultResult = default(Employee);
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                defaultResult = enumerator.Current;
            }

            return defaultResult;
        }

        public static IEnumerable<Employee> JoeyOrderBy(this IEnumerable<Employee> employees,
            IComparer<Employee> comparer)
        {
            return new MyOrderedEnumerable<Employee>(employees, comparer);
        }

        public static MyOrderedEnumerable<TSource> JoeyOrderBy<TSource, TKey>(this IEnumerable<TSource> employees,
            Func<TSource, TKey> keySelector, Comparer<TKey> comparer)
        {
            return new MyOrderedEnumerable<TSource>(
                employees, new CombineKeyComparer<TSource, TKey>(keySelector, comparer));
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            var index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                yield return selector(item, index);
                index++;
            }
        }

        public static IEnumerable<TSource> JoeySkip<TSource>(this IEnumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (index >= count)
                {
                    yield return item;
                }

                index++;
            }
        }

        public static IEnumerable<TSource> JoeySkipWhile<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            var isStartingTake = false;
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (!predicate(item) || isStartingTake)
                {
                    isStartingTake = true;
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> JoeyTake<TSource>(this IEnumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if (index < count)
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }

                index++;
            }
        }

        public static IEnumerable<TSource> JoeyTakeWhile<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static MyOrderedEnumerable<TSource> JoeyThenBy<TSource, TKey>(
            this MyOrderedEnumerable<TSource> employees,
            Func<TSource, TKey> keySelector, Comparer<TKey> comparer)
        {
            return employees.ConcatNextComparer(keySelector, comparer);
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item, index))
                {
                    yield return item;
                }

                index++;
            }
        }

        private static IEnumerable<Employee> DefaultIfEmpty(Employee defaultEmployee)
        {
            yield return defaultEmployee;
        }
    }
}