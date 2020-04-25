using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    public class CombineKeyComparer
    {
        public CombineKeyComparer(Func<Employee, string> keySelector, IComparer<string> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        public Func<Employee, string> KeySelector { get; private set; }
        public IComparer<string> KeyComparer { get; private set; }

        public int Compare(Employee employee, Employee minElement)
        {
            return KeyComparer.Compare(KeySelector(employee),
                KeySelector(minElement));
        }
    }

    public class ComboKeyComparer
    {
        public ComboKeyComparer(CombineKeyComparer firstCombineKeyComparer, CombineKeyComparer secondCombineKeyComparer)
        {
            FirstCombineKeyComparer = firstCombineKeyComparer;
            SecondCombineKeyComparer = secondCombineKeyComparer;
        }

        public CombineKeyComparer FirstCombineKeyComparer { get; private set; }
        public CombineKeyComparer SecondCombineKeyComparer { get; private set; }

        public int FinalCompareResult(Employee employee, Employee minElement)
        {
            var finalCompareResult = 0;
            var firstCompareResult = FirstCombineKeyComparer.Compare(employee, minElement);
            if (firstCompareResult < 0)
            {
                finalCompareResult = firstCompareResult;
                //minElement = employee;
                //index = i;
            }
            else if (firstCompareResult == 0)
            {
                var secondCompareResult = SecondCombineKeyComparer.Compare(employee, minElement);
                if (secondCompareResult < 0)
                {
                    finalCompareResult = secondCompareResult;
                    //minElement = employee;
                    //index = i;
                }
            }

            return finalCompareResult;
        }
    }

    [TestFixture]
    public class JoeyOrderByTests
    {
        [Test]
        public void orderBy_lastName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyOrderByLastName(employees);

            var expected = new[]
            {
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

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

            Func<Employee, string> secondKeySelector = employee1 => employee1.FirstName;
            IComparer<string> secondKeyComparer = Comparer<string>.Default;
            var actual = JoeyOrderByLastNameAndFirstName(employees, new ComboKeyComparer(new CombineKeyComparer(employee => employee.LastName, Comparer<string>.Default), new CombineKeyComparer(secondKeySelector, secondKeyComparer)));

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
            IEnumerable<Employee> employees, ComboKeyComparer comboKeyComparer)
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
                    var finalCompareResult = comboKeyComparer.FinalCompareResult(employee, minElement);

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

        private IEnumerable<Employee> JoeyOrderByLastName(IEnumerable<Employee> employees)
        {
            //selection sort
            var stringComparer = Comparer<string>.Default;
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (stringComparer.Compare(elements[i].LastName, minElement.LastName) < 0)
                    {
                        minElement = elements[i];
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }
    }
}