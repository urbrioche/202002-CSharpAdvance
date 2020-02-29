using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyFirstTests
    {
        [Test]
        public void get_first_girl()
        {
            var girls = new[]
            {
                new Girl(){Age = 60},
                new Girl(){Age = 20},
                new Girl(){Age = 30},
            };

            var girl = girls.JoeyFirst();
            var expected = new Girl { Age = 60 };

            expected.ToExpectedObject().ShouldEqual(girl);
        }

        [Test]
        public void get_first_girl_when_no_girls()
        {
            var girls = new Girl[]
            {
            };

            TestDelegate action = () => girls.JoeyFirst();
            Assert.Throws<InvalidOperationException>(action);
        }

        [Test]
        public void get_first_chen()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
            var employee = employees.JoeyFirst(current => current.LastName == "Chen");
            new Employee() { FirstName = "Joey", LastName = "Chen" }.ToExpectedObject().ShouldMatch(employee);
        }
    }
}