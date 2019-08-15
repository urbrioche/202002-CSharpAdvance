using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyCastTests
    {
        [Test]
        public void cast_int_exception_when_ArrayList_has_string()
        {
            var arrayList = new ArrayList {1, "2", 3};

            void TestDelegate() => arrayList.JoeyCast<int>().ToList();

            Assert.Throws<InvalidCastException>(TestDelegate);
        }
    }
}