using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    public class CombineKeyComparer<TKey> : IComparer<Employee>
    {
        public CombineKeyComparer(Func<Employee, TKey> keySelector, IComparer<TKey> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        public Func<Employee, TKey> KeySelector { get; private set; }
        public IComparer<TKey> KeyComparer { get; private set; }

        public int Compare(Employee x, Employee y)
        {
            return KeyComparer.Compare(KeySelector(x), KeySelector(y));
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<Employee> JoeySort(this IEnumerable<Employee> employees, IComparer<Employee> comboComparer)
        {
            //selection sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var employee = elements[i];

                    if (comboComparer.Compare(employee, minElement) < 0)
                    {
                        minElement = employee;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        public static MyOrderedEnumerable JoeyOrderBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            var combineKeyComparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return new MyOrderedEnumerable(employees, combineKeyComparer);
        }

        public static MyOrderedEnumerable JoeyThenBy<TKey>(this MyOrderedEnumerable orderedEnumerable,
            Func<Employee, TKey> keySelector)
        {
            var combineKeyComparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return orderedEnumerable.Append(combineKeyComparer);
        }
    }

    [TestFixture]
    public class JoeyOrderByTests
    {
        //[Test]
        //public void orderBy_lastName()
        //{
        //    var orderedEnumerable = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //    };

        //    var actual = JoeySort(orderedEnumerable);

        //    var expected = new[]
        //    {
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //    };

        //    expected.ToExpectedObject().ShouldMatch(actual);
        //}

        [Test]
        public void orderBy_lastName_and_firstName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = employees.JoeySort(new ComboComparer(new CombineKeyComparer<string>(employee => employee.LastName, Comparer<string>.Default), new CombineKeyComparer<string>(employee => employee.FirstName, Comparer<string>.Default)));

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void orderBy_lastName_firstName_Age()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 50},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 31},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 33},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 20},
            };

            var firstKeyComparer = new CombineKeyComparer<string>(element => element.LastName, Comparer<string>.Default);
            var lastKeyComparer = new CombineKeyComparer<string>(element => element.FirstName, Comparer<string>.Default);

            var untilNowComparer = new ComboComparer(firstKeyComparer, lastKeyComparer);

            var lastComparer = new CombineKeyComparer<int>(employee => employee.Age, Comparer<int>.Default);

            var comboComparer = new ComboComparer(untilNowComparer, lastComparer);

            var actual = employees.JoeySort(comboComparer);

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 33},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 31},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 20},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 50},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void orderBy_lastName_thenBy_firstName_thenBy_Age()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 50},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 31},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 33},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 20},
            };

            //var firstKeyComparer =
            //    new CombineKeyComparer<string>(element => element.LastName, Comparer<string>.Default);
            //var lastKeyComparer =
            //    new CombineKeyComparer<string>(element => element.FirstName, Comparer<string>.Default);

            //var untilNowComparer = new ComboComparer(firstKeyComparer, lastKeyComparer);

            //var lastComparer = new CombineKeyComparer<int>(employee => employee.Age, Comparer<int>.Default);

            //var comboComparer = new ComboComparer(untilNowComparer, lastComparer);

            var actual = employees
                .JoeyOrderBy(e => e.LastName)
                .JoeyThenBy(e => e.FirstName)
                .JoeyThenBy(e => e.Age);

            //var actual = orderedEnumerable.JoeyOrderByComboComparer(comboComparer);

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 33},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 31},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 20},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 50},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

    }
}