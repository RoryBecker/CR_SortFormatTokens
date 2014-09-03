using System;
using System.Linq;
using NUnit.Framework;
using CR_SortFormatTokens;
using System.Collections.Generic;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class RenumberTokensInStrings_Tests
    {
        [Test]
        public void RenumberInvertedList_Test()
        {
            string Start = "{5}, {4}, {3}, {2}, {1}, {0}";
            string Expected = "{0}, {1}, {2}, {3}, {4}, {5}";

            var Tokens = new TokenGatherer().GetTokens(Start);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);
            var Result = new StringTokenRenumberer().Renumber(Start, Tokens, Map);
            
            Assert.AreEqual(Expected, Result);
        }
        [Test]
        public void RenumberShuffledListWithDuplicates_Test()
        {
            string Start = "{3}, {0}, {2}, {0}, {1}, {0}";
            string Expected = "{0}, {1}, {2}, {1}, {3}, {1}";

            var Tokens = new TokenGatherer().GetTokens(Start);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);
            var Result = new StringTokenRenumberer().Renumber(Start, Tokens, Map);

            Assert.AreEqual(Expected, Result);
        }
        [Test]
        public void RenumberManyDuplicatesList_Test()
        {
            string Start = "{1}, {0}, {0}, {0}, {0}, {0}";
            string Expected = "{0}, {1}, {1}, {1}, {1}, {1}";

            var Tokens = new TokenGatherer().GetTokens(Start);
            var Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);
            var Result = new StringTokenRenumberer().Renumber(Start, Tokens, Map);

            Assert.AreEqual(Expected, Result);
        }
    }
}