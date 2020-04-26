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
        [Test]
        public void orderBy_lastName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyOrderByLastName(employees);

            var expected = new[]
            {
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

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

            Func<Employee, string> secondKeySelector = employee1 => employee1.FirstName;
            IComparer<string> secondKeyComparer = Comparer<string>.Default;
            var actual = JoeyOrderByLastNameAndFirstName(employees,
                new ComboComparer(new CombineKeyComparer(employee => employee.LastName, Comparer<string>.Default),
                    new CombineKeyComparer(secondKeySelector, secondKeyComparer)));

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> JoeyOrderByLastNameAndFirstName(
            IEnumerable<Employee> employees, IComparer<Employee> compare)
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
                    var finalCompareResult = compare.Compare(employee, minElement);

                    if (finalCompareResult < 0)
                    {
                        minElement = employee;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        private IEnumerable<Employee> JoeyOrderByLastName(IEnumerable<Employee> employees)
        {
            return JoeyOrderByLastNameAndFirstName(employees,
                new CombineKeyComparer(x => x.LastName, Comparer<string>.Default));
        }
    }
}