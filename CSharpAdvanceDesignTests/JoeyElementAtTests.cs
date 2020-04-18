﻿using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyElementAtTests
    {
        [Test]
        public void get_the_2nd_element_of_enumerable()
        {
            var employees = new List<Employee>
            {
                new Employee{FirstName = "Joey",LastName = "Chen"},
                new Employee{FirstName = "Tom",LastName = "Li"},
                new Employee{FirstName = "David",LastName = "Wang"},
            };

            var actual = LinqExtensions.JoeyElementAt(employees, 1);

            var expected = new Employee { FirstName = "Tom", LastName = "Li" };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void get_element_greater_than_total_employees()
        {
            var employees = new List<Employee>
            {
                new Employee{FirstName = "Joey",LastName = "Chen"},
                new Employee{FirstName = "Tom",LastName = "Li"},
                new Employee{FirstName = "David",LastName = "Wang"},
            };

            TestDelegate action = () => LinqExtensions.JoeyElementAt(employees, 5);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
    }
}