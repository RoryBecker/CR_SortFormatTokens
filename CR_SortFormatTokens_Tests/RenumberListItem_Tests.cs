using System;
using System.Linq;
using NUnit.Framework;
using CR_SortFormatTokens;
using System.Collections.Generic;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class RenumberListItem_Tests
    {
        #region AreEqual
        private bool AreEqual(List<int> expectedList, List<int> resultList)
        {
            if (expectedList.Count != resultList.Count)
                return false;
            for (int index = 0; index < expectedList.Count - 1; index++)
            {
                if (expectedList[index] != resultList[index])
                    return false;
            }
            return true;
        }
        #endregion

        [Test]
        public void ReorderParams2ItemCorrectOrderDoNothing_Test()
        {
            var StartString = "{0}, {1}";
            var StartList = new List<int>() { 0, 1 };
            var ExpectedList = new List<int>() { 0, 1 };

            var Tokens = new TokenGatherer().GetTokens(StartString);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);

            var ResultList = new ListReorderer().Reorder(StartList, Tokens, Map);

            Assert.IsTrue(AreEqual(ExpectedList, ResultList));
        }
        [Test]
        public void ReorderParams2ItemWrongOrderInvert_Test()
        {
            var StartString = "{1}, {0}";
            var StartList = new List<int>() { 1, 0 };
            var ExpectedList = new List<int>() { 0, 1 };

            var Tokens = new TokenGatherer().GetTokens(StartString);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);

            var ResultList = new ListReorderer().Reorder(StartList, Tokens, Map);

            Assert.IsTrue(AreEqual(ExpectedList, ResultList));
        }
        [Test]
        public void ReorderParams3ItemsReverse_Test()
        {
            var StartString = "{2}, {1}, {0}";
            var StartList = new List<int>() { 2, 1, 0 };
            var ExpectedList = new List<int>() { 0, 1, 2 };

            var Tokens = new TokenGatherer().GetTokens(StartString);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);

            var ResultList = new ListReorderer().Reorder(StartList, Tokens, Map);

            Assert.IsTrue(AreEqual(ExpectedList, ResultList));
        }
        [Test]
        public void ReorderParams1ParamUsedTwice_Test()
        {
            var StartString = "{0}, {0}";
            var StartList = new List<int>() { 0 };
            var ExpectedList = new List<int>() { 0 };

            var Tokens = new TokenGatherer().GetTokens(StartString);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);

            var ResultList = new ListReorderer().Reorder(StartList, Tokens, Map);

            Assert.IsTrue(AreEqual(ExpectedList, ResultList));
        }
        [Test]
        public void ReorderParams2ParamsWithDuplicateDoNothing_Test()
        {
            var StartString = "{0}, {1}, {0}";
            var StartList = new List<int>() { 0, 1 };
            var ExpectedList = new List<int>() { 0, 1 };

            var Tokens = new TokenGatherer().GetTokens(StartString);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);

            var ResultList = new ListReorderer().Reorder(StartList, Tokens, Map);

            Assert.IsTrue(AreEqual(ExpectedList, ResultList));
        }
        [Test]
        public void ReorderParams2ParamsWithDuplicate_Test()
        {
            var StartString = "{1}, {0}, {1}";
            var StartList = new List<int>() { 0, 1 };
            var ExpectedList = new List<int>() { 1, 0 };

            var Tokens = new TokenGatherer().GetTokens(StartString);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);

            var ResultList = new ListReorderer().Reorder(StartList, Tokens, Map);

            Assert.IsTrue(AreEqual(ExpectedList, ResultList));
        }
    }
}
