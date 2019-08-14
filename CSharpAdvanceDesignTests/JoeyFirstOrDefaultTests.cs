using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyFirstOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();

            var actual = JoeyFirstOrDefault(employees);

            Assert.IsNull(actual);
        }

        [Test]
        public void nullable_of_int_first_or_default()
        {
            var numbers = new List<int?>();

            var actual = JoeyFirstOrDefaultForNullableInt(numbers);

            Assert.IsNull(actual);
        }

        private int? JoeyFirstOrDefaultForNullableInt(IEnumerable<int?> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }

            return default(int?);
        }

        private Employee JoeyFirstOrDefault(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }

            return default(Employee);
        }
    }
}