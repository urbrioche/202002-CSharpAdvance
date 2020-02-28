using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class GroupSumTests
    {
        [Test]
        public void group_sum_of_saving()
        {
            var accounts = new[]
            {
                new Account {Name = "Joey", Saving = 10},
                new Account {Name = "David", Saving = 20},
                new Account {Name = "Tom", Saving = 30},
                new Account {Name = "Joseph", Saving = 40},
                new Account {Name = "Jackson", Saving = 50},
                new Account {Name = "Terry", Saving = 60},
                new Account {Name = "Mary", Saving = 70},
                new Account {Name = "Peter", Saving = 80},
                new Account {Name = "Jerry", Saving = 90},
                new Account {Name = "Martin", Saving = 100},
                new Account {Name = "Bruce", Saving = 110},
            };

            //sum of all Saving of each group which 3 Account per group
            var actual = MyGroupSum(accounts, 3, account => account.Saving);

            var expected = new[] { 60, 150, 240, 210 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> MyGroupSum<TSource>(IEnumerable<TSource> source, int size, Func<TSource, int> selector)
        {
            var result = new List<int>();
            var enumerator = source.GetEnumerator();
            var sum = 0;
            var count = 0;

            var hasNext = enumerator.MoveNext();

            while(hasNext)
            {
                var item = enumerator.Current;
                if (count < size)
                {
                    sum = sum + selector(item);
                    count++;
                }

                hasNext = enumerator.MoveNext();
                if (count == size || !hasNext)
                {
                    result.Add(sum);
                    sum = 0;
                    count = 0;
                }
            }

            return result;
        }
    }
}

public class Account
{
    public int Saving { get; set; }
    public string Name { get; set; }
}

