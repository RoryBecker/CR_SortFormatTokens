using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CR_SortFormatTokens;

namespace CR_SortFormatTokens_Tests
{
    public class GatherTokensBase
    {
        protected static void TestToken(Token Token, string Content, int Start, int End, int Index, string Formatting)
        {
            Assert.AreEqual(Start, Token.Start);
            Assert.AreEqual(End, Token.End);
            Assert.AreEqual(Content, Token.TokenText);
            Assert.AreEqual(Index, Token.Index);
            Assert.AreEqual(Formatting, Token.Formatting);
        }
    }
}
