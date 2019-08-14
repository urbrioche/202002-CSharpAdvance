using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyTakeTests
    {
        [Test]
        public void take_2_employees()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Mike", LastName = "Chang"},
                new Employee {FirstName = "Joseph", LastName = "Yao"},
            };

            var actual = JoeyTake(employees, 2);

            var expected = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void take_3_employees()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Mike", LastName = "Chang"},
                new Employee {FirstName = "Joseph", LastName = "Yao"},
            };

            var actual = JoeyTake(employees, 3);

            var expected = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void take_4_names()
        {
            var names = new[] {"Tom", "Joey", "David"};

            var actual = JoeyTakeWithString(names, 3);

            var expected = new[] {"Tom", "Joey", "David"};
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<string> JoeyTakeWithString(IEnumerable<string> names, int count)
        {
            return JoeyTake(names, count);
            //var enumerator = names.GetEnumerator();
            //var index = 0;
            //while (enumerator.MoveNext())
            //{
            //    var item = enumerator.Current;

            //    if (index < count)
            //    {
            //        yield return item;
            //    }
            //    else
            //    {
            //        yield break;
            //    }

            //    index++;
            //}
        }

        private IEnumerable<TSource> JoeyTake<TSource>(IEnumerable<TSource> employees, int count)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if (index < count)
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }

                index++;
            }
        }
    }
}