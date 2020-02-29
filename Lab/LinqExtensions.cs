using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return JoeyWhere(source, (x, index) => predicate(x));
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
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


        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current);
            }
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> urls,
            Func<TSource, int, TResult> selector)
        {
            int index = 0;
            var enumerator = urls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current, index);
                index++;
            }
        }

        public static IEnumerable<TSource> JoeyTake<TSource>(this IEnumerable<TSource> source, int count)
        {
            var enumerator = source.GetEnumerator();
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

        public static IEnumerable<Employee> JoeySkip(this IEnumerable<Employee> employees, int count)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var employee = enumerator.Current;

                if (index >= count)
                {
                    yield return employee;
                }

                index++;
            }
        }

        public static bool JoeyAny(this IEnumerable<int> numbers, Func<int, bool> predicate)
        {
            var enumerator = numbers.GetEnumerator();
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

        public static bool JoeyAny(this IEnumerable<Employee> employees)
        {
            return employees.GetEnumerator().MoveNext();
        }

        public static Employee JoeyLast(this IEnumerable<Employee> employees, Func<Employee, bool> predicate)
        {
            var enumerator = employees.GetEnumerator();
            var hasMatch = false;
            Employee employee = null;
            while (enumerator.MoveNext()) 
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    hasMatch = true;
                    employee = current; 
                } 
            } 

            return hasMatch ? employee : throw new InvalidOperationException();
        }

        public static Employee JoeyLast(this IEnumerable<Employee> employees)
        {
            return employees.JoeyLast(employee => true);
        }

        public static Girl JoeySingle(this IEnumerable<Girl> girls)
        {
            var enumerator = girls.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException();
            }

            var girl = enumerator.Current;
            if (enumerator.MoveNext())
            { 
                throw new InvalidOperationException();
            }

            return girl;
        }
    }
}