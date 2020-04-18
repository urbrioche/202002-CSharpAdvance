using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyPrependTests
    {
        [Test]
        public void prepend_employee_to_employees()
        {
            var employees = new Employee[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var newEmployee = new Employee() { FirstName = "Tom", LastName = "Li" };

            var actual = employees.JoeyPrepend(newEmployee);

            var expected = new Employee[]
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}