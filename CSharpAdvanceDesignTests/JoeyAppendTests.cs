using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    [Ignore("not yet")]
    public class JoeyAppendTests
    {
        [Test]
        public void append_an_employee_to_employees()
        {
            var employees = new List<TSource>
            {
                new TSource() {FirstName = "Joey", LastName = "Chen"},
            };

            var newEmployee = new TSource() { FirstName = "Tom", LastName = "Li" };

            var actual = JoeyAppend(employees, newEmployee);

            var expected = new List<TSource>
            {
                new TSource() {FirstName = "Joey", LastName = "Chen"},
                new TSource() {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TSource> JoeyAppend(IEnumerable<TSource> employees, TSource newSource)
        {
            throw new System.NotImplementedException();
        }
    }
}