using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyElementAtTests
    {
        [Test]
        public void get_the_2nd_element_of_enumerable()
        {
            var employees = new List<Employee>
            {
                new Employee{FirstName = "Joey",LastName = "Chen"},
                new Employee{FirstName = "Tom",LastName = "Li"},
                new Employee{FirstName = "David",LastName = "Wang"},
            };

            var actual = JoeyElementAt(employees, 1);

            var expected = new Employee { FirstName = "Tom", LastName = "Li" };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void get_element_greater_than_total_employees()
        {
            var employees = new List<Employee>
            {
                new Employee{FirstName = "Joey",LastName = "Chen"},
                new Employee{FirstName = "Tom",LastName = "Li"},
                new Employee{FirstName = "David",LastName = "Wang"},
            };

            TestDelegate action = () => JoeyElementAt(employees, 5);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        private TSource JoeyElementAt<TSource>(IEnumerable<TSource> source, int index)
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