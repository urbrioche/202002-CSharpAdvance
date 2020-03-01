using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyOrderByTests
    {
        //[Test]
        //public void orderBy_lastName()
        //{
        //    var employees = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //    };

        //    var actual = JoeySort(employees);

        //    var expected = new[]
        //    {
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //    };

        //    expected.ToExpectedObject().ShouldMatch(actual);
        //}

        //[Test]
        //public void orderBy_lastName_and_firstName()
        //{
        //    var employees = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //    };

        //    IComparer<Employee> firstComparer = new CombineKeyComparer<string>(employee => employee.LastName, Comparer<string>.Default);
        //    IComparer<Employee> secondComparer = new CombineKeyComparer<string>(employee => employee.FirstName, Comparer<string>.Default);
        //    var actual = employees.JoeySort(new ComboCompare(firstComparer, secondComparer));

        //    var expected = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //    };

        //    expected.ToExpectedObject().ShouldMatch(actual);
        //}

        //[Test]
        //public void orderBy_lastName_and_firstName_age()
        //{
        //    var employees = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Chen", Age = 30},
        //        new Employee {FirstName = "Joey", LastName = "Wang", Age = 25},
        //        new Employee {FirstName = "Tom", LastName = "Li", Age = 18},
        //        new Employee {FirstName = "Joseph", LastName = "Chen", Age = 22},
        //        new Employee {FirstName = "Joey", LastName = "Chen", Age = 28},
        //    };

        //    IComparer<Employee> firstComparer = new CombineKeyComparer<string>(employee => employee.LastName, Comparer<string>.Default);
        //    IComparer<Employee> secondComparer = new CombineKeyComparer<string>(employee => employee.FirstName, Comparer<string>.Default);
        //    IComparer<Employee> thirdComparer = new CombineKeyComparer<int>(employee => employee.Age, Comparer<int>.Default);
        //    var comboCompare = new ComboCompare(new ComboCompare(firstComparer, secondComparer), thirdComparer);
        //    var actual = employees.JoeySort(comboCompare);

        //    var expected = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Chen", Age = 28},
        //        new Employee {FirstName = "Joey", LastName = "Chen", Age = 30},
        //        new Employee {FirstName = "Joseph", LastName = "Chen", Age = 22},
        //        new Employee {FirstName = "Tom", LastName = "Li", Age = 18},
        //        new Employee {FirstName = "Joey", LastName = "Wang", Age = 25},
        //    };

        //    expected.ToExpectedObject().ShouldMatch(actual);
        //}

        [Test]
        public void orderBy_lastName_and_firstName_age_orderBy_thenBy()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 30},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 25},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 18},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 22},
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 28},
            };

            var actual = employees
                .JoeyOrderBy(e => e.LastName)
                .JoeyThenBy(e => e.FirstName)
                .JoeyThenBy(e => e.Age);

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 28},
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 30},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 22},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 18},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 25},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}