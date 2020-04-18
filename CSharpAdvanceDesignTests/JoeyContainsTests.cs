﻿using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyContainsTests
    {
        [Test]
        public void contains_joey_chen()
        {
            var employees = new List<Employee>
            {
                new Employee(){FirstName = "Joey", LastName = "Wang"},
                new Employee(){FirstName = "Tom", LastName = "Li"},
                new Employee(){FirstName = "Joey", LastName = "Chen"},
            };

            var joey = new Employee() { FirstName = "Joey", LastName = "Chen" };

            var actual = JoeyContains(employees, joey, new EmployeeComparer());

            Assert.IsTrue(actual);
        }

        private static bool JoeyContains<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
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
    }

    internal class EmployeeComparer:IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(Employee obj)
        {
            return new { obj.FirstName, obj.LastName }.GetHashCode();
        }
    }
}