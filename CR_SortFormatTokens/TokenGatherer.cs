using System;
using System.Linq;
using System.Collections.Generic;

namespace CR_SortFormatTokens
{
    public class TokenGatherer
    {
        public List<Token> GetTokens(string sourceString)
        {
            List<Token> Results = new List<Token>();
            int startPoint = -1;
            int endPoint = -1;
            for (int i = 0; i < sourceString.Length; i++)
            {
                switch (sourceString[i])
                {
                    case '{':
                        startPoint = i;
                        break;
                    case '}':
                        endPoint = i;
                        break;
                    default:
                        break;
                }
                if (startPoint > -1 && endPoint > -1)
                {
                    string TokenString = sourceString.Substring(startPoint, (endPoint - startPoint) + 1);
                    Results.Add(new Token(TokenString, startPoint));
                    startPoint = -1;
                    endPoint = -1;
                }
            }
            return Results;
        }
    }
}
