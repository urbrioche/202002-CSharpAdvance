using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    [Ignore("not yet")]
    public class JoeyTakeTests
    {
        [Test]
        public void take_2_employees()
        {
            var employees = GetEmployees();

            var actual = JoeyTake(employees);

            var expected = new List<TSource>
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
                new TSource {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private IEnumerable<TSource> JoeyTake(IEnumerable<TSource> employees)
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