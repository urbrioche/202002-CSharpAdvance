using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    [Ignore("not yet")]
    public class JoeyPrependTests
    {
        [Test]
        public void prepend_employee_to_employees()
        {
            var employees = new TSource[]
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
            };

            var newEmployee = new TSource() { FirstName = "Tom", LastName = "Li" };

            var actual = JoeyPrepend(employees, newEmployee);

            var expected = new TSource[]
            {
                new TSource {FirstName = "Tom", LastName = "Li"},
                new TSource {FirstName = "Joey", LastName = "Chen"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TSource> JoeyPrepend(IEnumerable<TSource> employees, TSource newSource)
        {
            throw new System.NotImplementedException();
        }
    }
}