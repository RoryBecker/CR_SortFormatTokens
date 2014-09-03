using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CR_SortFormatTokens;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class RenumberStringAndList_Tests
    {
        #region Tokens2
        [Test]
        public void Tokens2CorrectDoNothing_Test()
        {
            string String = "{0} {1}";
            List<int> List = new List<int> { 0, 1 };
            FixStringAndList(ref String, ref List);
            Assert.AreEqual("{0} {1}", String);
            Assert.AreEqual(0, List.First());
            Assert.AreEqual(1, List.Skip(1).First());
        }
        [Test]
        public void Tokens2SimpleInvert_Test()
        {
            string String = "{1} {0}";
            List<int> List = new List<int> { 1, 0 };
            FixStringAndList(ref String, ref List);
            Assert.AreEqual("{0} {1}", String);
            Assert.AreEqual(0, List.First());
            Assert.AreEqual(1, List.Skip(1).First());
        }
        #endregion
        #region Tokens3
        [Test]
        public void Tokens3CorrectDoNothing_Test()
        {
            string String = "{0} {1} {2}";
            List<int> List = new List<int> { 0, 1, 2 };
            FixStringAndList(ref String, ref List);
            Assert.AreEqual("{0} {1} {2}", String);
            Assert.AreEqual(0, List.First());
            Assert.AreEqual(1, List.Skip(1).First());
            Assert.AreEqual(2, List.Skip(2).First());
        }
        [Test]
        public void Tokens3Reversed_Test()
        {
            string String = "{2} {1} {0}";
            List<int> List = new List<int> { 2, 1, 0 };
            FixStringAndList(ref String, ref List);
            Assert.AreEqual("{0} {1} {2}", String);
            Assert.AreEqual(0, List.First());
            Assert.AreEqual(1, List.Skip(1).First());
            Assert.AreEqual(2, List.Skip(2).First());
        }
        [Test]
        public void Tokens3singleDup_Test()
        {
            string String = "{2} {1} {0}";
            List<int> List = new List<int> { 2, 1, 0 };
            FixStringAndList(ref String, ref List);
            Assert.AreEqual("{0} {1} {2}", String);
            Assert.AreEqual(0, List.First());
            Assert.AreEqual(1, List.Skip(1).First());
            Assert.AreEqual(2, List.Skip(2).First());
        }
        #endregion
        private void FixStringAndList(ref string startString, ref List<int> startList)
        {
            // gather Tokens
            var Tokens = new TokenGatherer().GetTokens(startString);
            
            // Generate map
            List<MapItem> Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);
            
            // Use map to rebuild string.
            startString = new StringTokenRenumberer().Renumber(startString, Tokens, Map);
            // use Map to rebuild list
            startList = new ListReorderer().Reorder(startList, Tokens, Map);

        }
    }
}
