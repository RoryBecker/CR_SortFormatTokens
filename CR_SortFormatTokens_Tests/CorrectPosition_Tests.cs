using System;
using System.Linq;
using NUnit.Framework;
using CR_SortFormatTokens;
using System.Collections.Generic;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class CorrectPosition_Tests
    {
        private readonly List<int> List1 = new List<int> { 0, 1, 2, 3, 5, 4, 6 };

        [Test]
        public void Test1()
        {
            Assert.IsTrue(SequenceRenumberer.ItemCorrect(0, List1));
        }
        [Test]
        public void Test2()
        {
            Assert.IsTrue(SequenceRenumberer.ItemCorrect(1, List1));
        }
        [Test]
        public void Test3()
        {
            Assert.IsTrue(SequenceRenumberer.ItemCorrect(2, List1));
        }
        [Test]
        public void Test4()
        {
            Assert.IsTrue(SequenceRenumberer.ItemCorrect(3, List1));
        }
        [Test]
        public void Test5()
        {
            Assert.IsFalse(SequenceRenumberer.ItemCorrect(4, List1));
        }
        [Test]
        public void Test6()
        {
            Assert.IsFalse(SequenceRenumberer.ItemCorrect(5, List1));
        }
        [Test]
        public void Test7()
        {
            Assert.IsTrue(SequenceRenumberer.ItemCorrect(6, List1));
        }
    }
}