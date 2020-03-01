using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    public class ComboCompare:IComparer<Employee>
    {
        public ComboCompare(IComparer<Employee> firstComparer, IComparer<Employee> secondComparer)
        {
            FirstComparer = firstComparer;
            SecondComparer = secondComparer;
        }

        public IComparer<Employee> FirstComparer { get; private set; }
        public IComparer<Employee> SecondComparer { get; private set; }

        public int Compare(Employee x, Employee y)
        {
            var firstCompareResult = FirstComparer.Compare(x, y);
            var secondCompareResult = SecondComparer.Compare(x, y);

            if (firstCompareResult != 0)
            {
                return firstCompareResult;
            }

            if (secondCompareResult != 0)
            {
                return secondCompareResult;
            }

            return 0;
            //if (firstCompareResult < 0)
            //{
            //    return firstCompareResult;
            //    //finalCompareResult = firstCompareResult;
            //    //y = x;
            //    //index = i;
            //}

            //if (firstCompareResult == 0)
            //{
            //    if (secondCompareResult < 0)
            //    {
            //        return secondCompareResult;
            //        //finalCompareResult = secondCompareResult;
            //        //y = x;
            //        //index = i;
            //    }
            //}

            //return 0;
        }
    }

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

            IComparer<Employee> firstComparer = new CombineKeyComparer<string>(employee => employee.LastName, Comparer<string>.Default);
            IComparer<Employee> secondComparer = new CombineKeyComparer<string>(employee => employee.FirstName, Comparer<string>.Default);
            var actual = JoeyOrderByLastNameAndFirstName(
                employees, 
                new ComboCompare(firstComparer, secondComparer));

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void orderBy_lastName_and_firstName_age()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 30},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 25},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 18},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 22},
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 28},
            };

            IComparer<Employee> firstComparer = new CombineKeyComparer<string>(employee => employee.LastName, Comparer<string>.Default);
            IComparer<Employee> secondComparer = new CombineKeyComparer<string>(employee => employee.FirstName, Comparer<string>.Default);
            IComparer<Employee> thirdComparer = new CombineKeyComparer<int>(employee => employee.Age, Comparer<int>.Default);
            var comboCompare = new ComboCompare(new ComboCompare(firstComparer, secondComparer), thirdComparer);
            var actual = JoeyOrderByLastNameAndFirstName(
                employees, 
                comboCompare);

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 28},
                new Employee {FirstName = "Joey", LastName = "Chen", Age = 30},
                new Employee {FirstName = "Joseph", LastName = "Chen", Age = 22},
                new Employee {FirstName = "Tom", LastName = "Li", Age = 18},
                new Employee {FirstName = "Joey", LastName = "Wang", Age = 25},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> JoeyOrderByLastNameAndFirstName(
            IEnumerable<Employee> employees, IComparer<Employee> comboCompare)
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

                    if (comboCompare.Compare(employee, minElement) < 0)
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