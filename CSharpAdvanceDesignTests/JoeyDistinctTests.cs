using ExpectedObjects;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyDistinctTests
    {
        [Test]
        public void distinct_numbers()
        {
            var numbers = new[] {91, 3, 91, -1};
            var actual = JoeyDistinct(numbers, EqualityComparer<int>.Default);

            var expected = new[] {91, 3, -1};

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void distinct_employees()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyDistinct(employees, new EmployeeEqualityComparer());

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TSource> JoeyDistinct<TSource>(IEnumerable<TSource> source,
            IEqualityComparer<TSource> equalityComparer)
        {
            var enumerator = source.GetEnumerator();
            var hashSet = new HashSet<TSource>(equalityComparer);
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (hashSet.Add(item))
                {
                    yield return item;
                }
            }
        }
    }

    internal class EmployeeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(Employee obj)
        {
            return new {obj.FirstName, obj.LastName}.GetHashCode();
        }
    }
}