using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    [Ignore("not yet")]
    public class JoeyElementAtTests
    {
        [Test]
        public void get_the_2nd_element_of_enumerable()
        {
            var employees = new List<TSource>
            {
                new TSource{FirstName = "Joey",LastName = "Chen"},
                new TSource{FirstName = "Tom",LastName = "Li"},
                new TSource{FirstName = "David",LastName = "Wang"},
            };

            var actual = JoeyElementAt(employees, 1);

            var expected = new TSource { FirstName = "Tom", LastName = "Li" };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        private TSource JoeyElementAt(IEnumerable<TSource> employees, int index)
        {
            throw new System.NotImplementedException();
        }
    }
}