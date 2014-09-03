using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CR_SortFormatTokens;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class GatherTokens_Formatting_Tests : GatherTokensBase
    {
        [Test]
        public void Gather1Token_Test()
        {
            var Tokens = new TokenGatherer().GetTokens("{0:00.###}");
            Assert.AreEqual(1, Tokens.Count);
            TestToken(Tokens[0], "{0:00.###}", 0, 9, 0, "00.###");
        }
    }
}
