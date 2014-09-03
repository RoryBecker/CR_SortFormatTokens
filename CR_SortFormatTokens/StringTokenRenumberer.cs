using System;
using System.Linq;
using System.Collections.Generic;

namespace CR_SortFormatTokens
{
    public class StringTokenRenumberer
    {
        public string Renumber(string inString, List<Token> tokens, List<MapItem> map)
        {
            string outString = inString;
            for (int i = map.Count - 1; i >= 0; i--)
            {
                // Use MapItem to alter the index of the i'th token
                Token token = tokens[i];
                MapItem item = map[i];
                int rangeStart = token.Start;
                int rangeEnd = token.End;
                token.SetIndex(item.Dest);
                string newTokenText = token.ToString();
                outString = SetStringRange(outString, rangeStart, rangeEnd, newTokenText);
            }
            return outString;
        }

        public string SetStringRange(string outString, int rangeStart, int rangeEnd, string newTokenText)
        {
            string FirstBit = outString.Substring(0, rangeStart);
            string LastBit = outString.Substring(rangeEnd + 1, outString.Length - rangeEnd - 1);
            return FirstBit + newTokenText + LastBit;
        }
    }
}
