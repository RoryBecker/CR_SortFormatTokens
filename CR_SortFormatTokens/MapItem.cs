using System;
using System.Linq;
using System.Collections.Generic;

namespace CR_SortFormatTokens
{
    public struct MapItem
    {
        /// <summary>
        /// the
        /// </summary>
        public int Source;
        public int Dest;
        public MapItem(int source, int dest)
        {
            Source = source;
            Dest = dest;
        }
    }
}
