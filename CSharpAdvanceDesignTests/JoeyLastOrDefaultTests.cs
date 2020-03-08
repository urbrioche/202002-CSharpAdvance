using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    [Ignore("not yet")]
    public class JoeyLastOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<TSource>();
            var actual = JoeyLastOrDefault(employees);
            Assert.IsNull(actual);
        }

        private TSource JoeyLastOrDefault(IEnumerable<TSource> employees)
        {
            throw new System.NotImplementedException();
        }
    }
}