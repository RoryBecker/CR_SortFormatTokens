using System;
using System.Linq;
using System.Collections.Generic;

namespace CR_SortFormatTokens
{
    public class Token
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public int IndexStart { get; private set; }
        public int IndexEnd { get; private set; }
        public int IndexLength { get; private set; }

        public string TokenText { get; private set; }
        public string TokenInner { get; private set; }

        public string Formatting { get; private set; }
        public int Index { get; private set; }

        public Token(string tokenString, int start)
        {
            Start = start;
            End = start + tokenString.Length - 1;
            TokenText = tokenString;
            TokenInner = TokenText.Substring(1, TokenText.Length - 2);

            IndexStart = start + 1; // First char after '{'
            ReParseTokenInner();
        }
        private void ReParseTokenInner()
        {
            string IndexString = TokenInner.Split(':')[0];
            Index = int.Parse(IndexString);
            IndexLength = IndexString.Length;
            IndexEnd = IndexStart + IndexLength - 1;

            Formatting = TokenInner.Contains(':') ? TokenInner.Split(':')[1] : String.Empty;
        }
        public void SetIndex(int Index)
        {
            TokenInner = Index.ToString();
            if (Formatting != String.Empty)
            {
                TokenInner += ":" + Formatting;
            }
            ReParseTokenInner();
        }
        public override string ToString()
        {
            return "{" + TokenInner + "}";
        }
    }
}
