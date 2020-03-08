using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    [Ignore("not yet")]
    public class JoeyConcatTests
    {
        [Test]
        public void concat_two_employees()
        {
            var first = new List<TSource>
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
            };

            var second = new List<TSource>
            {
                new TSource {FirstName = "David", LastName = "Li"},
                new TSource {FirstName = "Tom", LastName = "Wang"},
            };

            var actual = JoeyConcat(first, second);

            var expected = new List<TSource>()
            {
                new TSource {FirstName = "Joey", LastName = "Chen"},
                new TSource {FirstName = "David", LastName = "Li"},
                new TSource {FirstName = "Tom", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TSource> JoeyConcat(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            throw new System.NotImplementedException();
        }
    }
}