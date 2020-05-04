using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyWhereWithDefaultTests
    {
        [Test]
        public void default_employee_is_Joey()
        {
            var employees = new List<Employee>
            {
                new Employee() {FirstName = "Tom", LastName = "Li", Role = Role.Engineer},
                new Employee() {FirstName = "David", LastName = "Wang", Role = Role.Designer},
            };

            var actual = LinqExtensions.JoeyDefaultIfEmpty(employees.JoeyWhere(e => e.Role == Role.Manager), new Employee {FirstName = "Joey", LastName = "Chen", Role = Role.Engineer});

            var expected = new List<Employee>
                {new Employee() {FirstName = "Joey", LastName = "Chen", Role = Role.Engineer}};

            expected.ToExpectedObject().ShouldMatch(actual);
        }
        
        [Test]
        public void when_match_should_not_return_default_employee()
        {
            var employees = new List<Employee>
            {
                new Employee() {FirstName = "Tom", LastName = "Li", Role = Role.Manager},
                new Employee() {FirstName = "David", LastName = "Wang", Role = Role.Designer},
                new Employee() {FirstName = "May", LastName = "Wang", Role = Role.Manager},
            };

            var actual = LinqExtensions.JoeyDefaultIfEmpty(employees.JoeyWhere(e => e.Role == Role.Manager), new Employee {FirstName = "Joey", LastName = "Chen", Role = Role.Engineer});

            var expected = new List<Employee>
            {
                new Employee() {FirstName = "Tom", LastName = "Li", Role = Role.Manager},
                new Employee() {FirstName = "May", LastName = "Wang", Role = Role.Manager},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}