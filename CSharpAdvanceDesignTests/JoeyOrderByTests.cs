﻿using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyOrderByTests
    {
        //[Test]
        //public void orderBy_lastName()
        //{
        //    var employees = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //    };

        //    var actual = JoeyOrderByLastNameAndFirstName(employees);

        //    var expected = new[]
        //    {
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //    };

        //    expected.ToExpectedObject().ShouldMatch(actual);
        //}

        [Test]
        public void orderBy_lastName_and_firstName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyOrderByLastNameAndFirstName(employees, new CombineKeyComparer(employee => employee.LastName, Comparer<string>.Default), new CombineKeyComparer(employee => employee.FirstName, Comparer<string>.Default));

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }


        private IEnumerable<Employee> JoeyOrderByLastNameAndFirstName(
            IEnumerable<Employee> employees,
            IComparer<Employee> firstComparer,
            IComparer<Employee> secondComparer)
        {
            //selection sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var employee = elements[i];
                    var firstCompareResult = firstComparer.Compare(employee, minElement);
                    var secondCompareResult = secondComparer.Compare(employee, minElement);
                    var finalCompareResult = 0;
                    if (firstCompareResult < 0)
                    {
                        finalCompareResult = firstCompareResult;
                        //minElement = employee;
                        //index = i;
                    }
                    else if (firstCompareResult == 0)
                    {
                        if (secondCompareResult < 0)
                        {
                            finalCompareResult = secondCompareResult;
                            //minElement = employee;
                            //index = i;
                        }
                    }

                    if (finalCompareResult < 0)
                    {
                        minElement = employee;
                        index = i;
                    }


                }

                elements.RemoveAt(index);
                yield return minElement;
            }

        }
    }
}