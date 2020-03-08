using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
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
                new TSource {FirstName = "Joey", LastName = "Wang"},
                new TSource {FirstName = "Tom", LastName = "Li"},
                new TSource {FirstName = "Joseph", LastName = "Chen"},
                new TSource {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = employees.JoeySort(new ComboComparer(new CombineKeyComparer<string>(employee => employee.LastName, Comparer<string>.Default), new CombineKeyComparer<string>(employee => employee.FirstName, Comparer<string>.Default)));

            var expected = new[]
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
                new TSource {FirstName = "Joseph", LastName = "Chen"},
                new TSource {FirstName = "Tom", LastName = "Li"},
                new TSource {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void orderBy_lastName_firstName_Age()
        {
            var employees = new[]
            {
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 50},
                new TSource {FirstName = "Tom", LastName = "Li", Age = 31},
                new TSource {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new TSource {FirstName = "Joey", LastName = "Chen", Age = 33},
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 20},
            };

            var firstKeyComparer = new CombineKeyComparer<string>(element => element.LastName, Comparer<string>.Default);
            var lastKeyComparer = new CombineKeyComparer<string>(element => element.FirstName, Comparer<string>.Default);

            var untilNowComparer = new ComboComparer(firstKeyComparer, lastKeyComparer);

            var lastComparer = new CombineKeyComparer<int>(employee => employee.Age, Comparer<int>.Default);

            var comboComparer = new ComboComparer(untilNowComparer, lastComparer);

            var actual = employees.JoeySort(comboComparer);

            var expected = new[]
            {
                new TSource {FirstName = "Joey", LastName = "Chen", Age = 33},
                new TSource {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new TSource {FirstName = "Tom", LastName = "Li", Age = 31},
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 20},
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 50},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void orderBy_lastName_thenBy_firstName_thenBy_Age()
        {
            var employees = new[]
            {
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 50},
                new TSource {FirstName = "Tom", LastName = "Li", Age = 31},
                new TSource {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new TSource {FirstName = "Joey", LastName = "Chen", Age = 33},
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 20},
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
                new TSource {FirstName = "Joey", LastName = "Chen", Age = 33},
                new TSource {FirstName = "Joseph", LastName = "Chen", Age = 32},
                new TSource {FirstName = "Tom", LastName = "Li", Age = 31},
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 20},
                new TSource {FirstName = "Joey", LastName = "Wang", Age = 50},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

    }
}