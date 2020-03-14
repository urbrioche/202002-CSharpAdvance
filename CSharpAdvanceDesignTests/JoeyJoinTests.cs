using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyJoinTests
    {
        [Test]
        public void all_pets_and_owner()
        {
            var david = new Employee { FirstName = "David", LastName = "Chen" };
            var joey = new Employee { FirstName = "Joey", LastName = "Chen" };
            var tom = new Employee { FirstName = "Tom", LastName = "Chen" };

            var employees = new[]
            {
                david,
                joey,
                tom
            };

            var pets = new Pet[]
            {
                new Pet() {Name = "Lala", Owner = joey},
                new Pet() {Name = "Didi", Owner = david},
                new Pet() {Name = "Fufu", Owner = tom},
                new Pet() {Name = "QQ", Owner = joey},
            };


            var actual = JoeyJoin(employees, pets, employee => employee, pet => pet.Owner, (employee, pet) => Tuple.Create(employee.FirstName, pet.Name), EqualityComparer<Employee>.Default);

            var expected = new[]
            {
                Tuple.Create("David", "Didi"),
                Tuple.Create("Joey", "Lala"),
                Tuple.Create("Joey", "QQ"),
                Tuple.Create("Tom", "Fufu"),
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TResult> JoeyJoin<TOuter,TInner, TKey, TResult>(
            IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector, 
            IEqualityComparer<TKey> comparer)
        {
            var outerEnumerator = outer.GetEnumerator();
            while (outerEnumerator.MoveNext())
            {
                var outerCurrent = outerEnumerator.Current;
                var innerEnumerator = inner.GetEnumerator();
                while (innerEnumerator.MoveNext())
                {
                    var innerCurrent = innerEnumerator.Current;

                    if (comparer.Equals(outerKeySelector(outerCurrent), innerKeySelector(innerCurrent)))
                    {
                        yield return resultSelector(outerCurrent, innerCurrent);
                    }
                }
                
            }
        }
    }
}