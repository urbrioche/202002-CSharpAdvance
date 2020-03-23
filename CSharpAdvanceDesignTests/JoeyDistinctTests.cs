using ExpectedObjects;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using Lab;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyDistinctTests
    {
        [Test]
        public void distinct_numbers()
        {
            var numbers = new[] { 91, 3, 91, -1 };
            var actual = JoeyDistinct(numbers);

            var expected = new[] { 91, 3, -1 };

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

            IEqualityComparer<Employee> comparer = new FullNameEqualityComparer();
            var actual = JoeyDistinct(employees, comparer);

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private static IEnumerable<TSource> JoeyDistinct<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return new HashSet<TSource>(source, comparer);
        }

        private static IEnumerable<TSource> JoeyDistinct<TSource>(IEnumerable<TSource> source)
        {
            return JoeyDistinct(source, EqualityComparer<TSource>.Default);
        }
    }
}