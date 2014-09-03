using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CR_SortFormatTokens;

namespace CR_SortFormatTokens_Tests
{
    public class Sequences
    {
        #region Sequences
        public static List<int> Sequence012345()
        {
            return new List<int> { 0, 1, 2, 3, 4, 5 };
        }
        public static List<int> Sequence543210()
        {
            return new List<int> { 5, 4, 3, 2, 1, 0 };
        }
        public static List<int> Sequence021()
        {
            return new List<int> { 0, 2, 1 };
        }
        public static List<int> Sequence012354()
        {
            return new List<int> { 0, 1, 2, 3, 5, 4 };
        }
        public static List<int> Sequence00()
        {
            return new List<int> { 0, 0 };
        }
        public static List<int> Sequence011()
        {
            return new List<int> { 0, 1, 1 };
        }
        public static List<int> Sequence010()
        {
            return new List<int> { 0, 1, 0 };
        }
        public static List<int> Sequence0010()
        {
            return new List<int> { 0, 0, 1, 0 };
        }
        #endregion
    }
}
