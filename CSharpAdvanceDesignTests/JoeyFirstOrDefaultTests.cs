﻿using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyFirstOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();

            var actual = LinqExtensions.JoeyFirstOrDefault(employees);

            Assert.IsNull(actual);
        }
    }
}