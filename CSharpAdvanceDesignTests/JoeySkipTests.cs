using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    [Ignore("not yet")]
    public class JoeySkipTests
    {
        [Test]
        public void skip_2_employees()
        {
            var employees = GetEmployees();

            var actual = JoeySelect(employees);

            var expected = new List<TSource>
            {
                new TSource {FirstName = "David", LastName = "Chen"},
                new TSource {FirstName = "Mike", LastName = "Chang"},
                new TSource {FirstName = "Joseph", LastName = "Yao"},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        private IEnumerable<TSource> JoeySelect(IEnumerable<TSource> employees)
        {
            throw new System.NotImplementedException();
        }

        private static IEnumerable<TSource> GetEmployees()
        {
            return new List<TSource>
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
                new TSource {FirstName = "Tom", LastName = "Li"},
                new TSource {FirstName = "David", LastName = "Chen"},
                new TSource {FirstName = "Mike", LastName = "Chang"},
                new TSource {FirstName = "Joseph", LastName = "Yao"},
            };
        }
    }
}