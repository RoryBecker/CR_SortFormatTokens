using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;
using DevExpress.Refactor;

namespace CR_SortFormatTokens
{
    public class ListReorderer
    {
        public List<T> Reorder<T>(List<T> startList, List<Token> tokens, List<MapItem> map)
        {
            List<T> ResultList = new List<T>();
            // Add things to the list in the order dictated by the map
            var MapItems = from item in map orderby item.Dest group item by new { item.Dest } into MyGroup select MyGroup.FirstOrDefault();
            //var MapItems = from item in map orderby item.Dest select item;
            foreach (MapItem item in MapItems)
            {
                ResultList.Add(startList[item.Source]);
            }
            return ResultList;
        }
    }

}
