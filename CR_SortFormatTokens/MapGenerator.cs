using System;
using System.Linq;
using System.Collections.Generic;

namespace CR_SortFormatTokens
{
    public class MapGenerator
    {
        public static List<MapItem> GenerateMap(IEnumerable<int> list)
        {
            return GenerateMap(list.ToList());
        }
        public static List<MapItem> GenerateMap(List<int> startList)
        {
            var endList = CR_SortFormatTokens.SequenceRenumberer.Renumber(startList);
            List<MapItem> Map = new List<MapItem>();
            for (int i = 0; i < endList.Count; i++)
            {
                Map.Add(new MapItem(startList[i], endList[i]));
            }
            return Map;
        }

    }
}
