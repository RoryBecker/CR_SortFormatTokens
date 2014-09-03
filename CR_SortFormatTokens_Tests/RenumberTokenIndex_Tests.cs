using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class RenumberTokenIndex_Tests
    {

        #region RenumberTokens
        private static List<int> RenumberTokens(List<int> TokenInts)
        {
            return CR_SortFormatTokens.SequenceRenumberer.Renumber(TokenInts);
        }
        #endregion
        #region AreEqual
        private static bool AreEqual(List<int> StartList, List<int> EndList)
        {
            return CR_SortFormatTokens.SequenceRenumberer.AreEqual(StartList, EndList);
        }
        #endregion

        [Test]
        public void RenumberInvertedList_Test()
        {
            List<int> StartList = new List<int> { 5, 4, 3, 2, 1, 0 };
            List<int> EndList = new List<int> { 0, 1, 2, 3, 4, 5 };
            Assert.IsTrue(AreEqual(RenumberTokens(StartList), EndList));
        }
        [Test]
        public void RenumberShuffledListWithDuplicates_Test()
        {
            List<int> StartList = new List<int> { 3, 0, 2, 0, 1, 0 };
            List<int> EndList = new List<int> { 0, 1, 2, 1, 3, 1 };
            Assert.IsTrue(AreEqual(RenumberTokens(StartList), EndList));
        }
        private string AsString(List<int> List)
        {
            return string.Join(",", List.ToArray());
        }
        [Test]
        public void RenumberManyDuplicatesList_Test()
        {
            List<int> StartList = new List<int> { 1, 0, 0, 0, 0, 0 };
            List<int> EndList = new List<int> { 0, 1, 1, 1, 1, 1 };
            Assert.AreEqual(AsString(RenumberTokens(StartList)), AsString(EndList));
        }
        [Test]
        public void RenumberSingleNonZeroItems_Test()
        {
            List<int> StartList = new List<int> { 1 };
            Assert.AreEqual(0, RenumberTokens(StartList).First());
        }
        [Test]
        public void RenumberNonZeroItems_Test()
        {
            List<int> StartList = new List<int> { 1, 2, 3 };
            List<int> EndList = new List<int> { 0, 1, 2 };
            Assert.IsTrue(AreEqual(RenumberTokens(StartList), EndList));
        }
        [Test]
        public void RenumberNonZeroItemsWithDuplicates_Test()
        {
            List<int> StartList = new List<int> { 1, 1, 3, 4 };
            List<int> EndList = new List<int> { 0, 0, 1, 2 };
            Assert.IsTrue(AreEqual(RenumberTokens(StartList), EndList));
        }
        [Test]
        public void RenumberNonZeroItemsWithManyDuplicates_Test()
        {
            List<int> StartList = new List<int> { 1, 1, 4, 4, 8, 8, 2, 2 };
            List<int> EndList = new List<int> { 0, 0, 1, 1, 2, 2, 3, 3 };
            Assert.IsTrue(AreEqual(RenumberTokens(StartList), EndList));
        }

    }
}