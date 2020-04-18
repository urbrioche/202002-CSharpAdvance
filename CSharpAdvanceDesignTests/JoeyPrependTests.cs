using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyPrependTests
    {
        [Test]
        public void prepend_employee_to_employees()
        {
            var employees = new Employee[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var newEmployee = new Employee() { FirstName = "Tom", LastName = "Li" };

            var actual = JoeyPrepend(employees, newEmployee);

            var expected = new Employee[]
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private static IEnumerable<TSource> JoeyPrepend<TSource>(IEnumerable<TSource> source, TSource element)
        {
            yield return element;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
}