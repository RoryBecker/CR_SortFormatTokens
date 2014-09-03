using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CR_SortFormatTokens;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class GatherTokens_Basic_Tests : GatherTokensBase
    {
        [Test]
        public void Gather1Token_Test()
        {
            var Tokens = new TokenGatherer().GetTokens("{0}");
            Assert.AreEqual(1, Tokens.Count);
            var Token = Tokens[0];
            TestToken(Token, "{0}", 0, 2, 0, "");
        }

        [Test]
        public void Gather2Tokens_Test()
        {
            var Tokens = new TokenGatherer().GetTokens("{0}{1}");
            Assert.AreEqual(2, Tokens.Count);
            TestToken(Tokens[0], "{0}", 0, 2, 0, "");
            TestToken(Tokens[1], "{1}", 3, 5, 1, "");
        }
        [Test]
        public void Gather3Tokens_Test()
        {
            var Tokens = new TokenGatherer().GetTokens("{0}{1}{2}");
            Assert.AreEqual(3, Tokens.Count);
            TestToken(Tokens[0], "{0}", 0, 2, 0, "");
            TestToken(Tokens[1], "{1}", 3, 5, 1, "");
            TestToken(Tokens[2], "{2}", 6, 8, 2, "");
        }
        [Test]
        public void GatherDuplicateTokens_Test()
        {
            var Tokens = new TokenGatherer().GetTokens("{0}{1}{2}{0}{1}{2}");
            Assert.AreEqual(6, Tokens.Count);
            TestToken(Tokens[0], "{0}", 0, 2, 0, "");
            TestToken(Tokens[1], "{1}", 3, 5, 1, "");
            TestToken(Tokens[2], "{2}", 6, 8, 2, "");
            TestToken(Tokens[3], "{0}", 9, 11, 0, "");
            TestToken(Tokens[4], "{1}", 12, 14, 1, "");
            TestToken(Tokens[5], "{2}", 15, 17, 2, "");
        }
    }
}