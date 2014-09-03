using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CR_SortFormatTokens;

namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class MapGeneration_Tests
    {
        [Test]
        public void GenerateMap1_Test()
        {
            List<int> Sequence = Sequences.Sequence012345(); // 0,1,2,3,4,5
            List<MapItem> Map = MapGenerator.GenerateMap(Sequence);
            Assert.Contains(new MapItem(0, 0), Map);
            Assert.Contains(new MapItem(1, 1), Map);
            Assert.Contains(new MapItem(2, 2), Map);
            Assert.Contains(new MapItem(3, 3), Map);
            Assert.Contains(new MapItem(4, 4), Map);
            Assert.Contains(new MapItem(5, 5), Map);
        }
        public void GenerateMap2_Test()
        {
            List<int> Sequence = Sequences.Sequence543210(); // 5, 4, 3, 2, 1, 0
            List<MapItem> Map = MapGenerator.GenerateMap(Sequence);
            Assert.Contains(new MapItem(5, 0), Map);
            Assert.Contains(new MapItem(4, 1), Map);
            Assert.Contains(new MapItem(3, 2), Map);
            Assert.Contains(new MapItem(2, 3), Map);
            Assert.Contains(new MapItem(1, 4), Map);
            Assert.Contains(new MapItem(0, 5), Map);
        }
    }
}
