using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    [Ignore("not yet")]
    public class JoeyWhereWithDefaultTests
    {
        [Test]
        public void default_employee_is_Joey()
        {
            var employees = new List<TSource>
            {
                new TSource() {FirstName = "Tom", LastName = "Li", Role = Role.Engineer},
                new TSource() {FirstName = "David", LastName = "Wang", Role = Role.Designer},
            };

            var actual = WhereWithDefault(
                employees,
                e => e.Role == Role.Manager,
                new TSource { FirstName = "Joey", LastName = "Chen", Role = Role.Engineer });

            var expected = new List<TSource>
                {new TSource() {FirstName = "Joey", LastName = "Chen", Role = Role.Engineer}};

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TSource> WhereWithDefault(IEnumerable<TSource> employees, Func<TSource, bool> predicate,
            TSource defaultSource)
        {
            throw new NotImplementedException();
        }
    }
}