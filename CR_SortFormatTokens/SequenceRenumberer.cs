using System;
using System.Linq;
using System.Collections.Generic;

namespace CR_SortFormatTokens
{
    public class SequenceRenumberer
    {
        public static bool RequiresRenumbering(IEnumerable<int> numbers)
        {
            List<int> SortedList = Renumber(numbers.ToList());
            if (AreEqual(numbers.ToList(), SortedList))
                return false;
            return true;
        }
        public static bool AreEqual(List<int> L1, List<int> L2)
        {
            if (L1.Count != L2.Count)
                return false;
            for (int i = 0; i < L1.Count; i++)
            {
                if (L1[i] != L2[i])
                    return false;
            }
            return true;
        }
        public static List<int> Renumber(List<int> sequence)
        {
            var temp = sequence.ToList();
            bool Renumbered;
            do
            {
                Renumbered = false;
                for (int pos = 0; pos <= temp.Count - 1; pos++)
                {
                    if (!ItemCorrect(pos, temp))
                    {
                        RenumberItem(pos, temp);
                        Renumbered = true;
                    }
                }
            } while (Renumbered);
            return temp;
        }
        public static bool ItemCorrect(int pos, List<int> list)
        {
            int TestNumber = list[pos];
            
            List<int> PriorList;
            bool isNextInSequence;
            bool isDuplicateOfPrevious;
            
            if (pos == 0)
            {
                return TestNumber == 0;
                //PriorList = new List<int>();
                //isNextInSequence = false;
                //isDuplicateOfPrevious = false;
            }
            else
            {
                PriorList = list.Take(pos).ToList();
                isNextInSequence = TestNumber == PriorList.Max() + 1;
                isDuplicateOfPrevious = PriorList.Contains(TestNumber);
            }

                        
            return isNextInSequence || isDuplicateOfPrevious;
        }
        private static void RenumberItem(int pos, List<int> list)
        {
            //// Make 1 bigger than all other items in prior list
            //// ensure other items in list with same value are also assigned this new value

            var startValue = list[pos];
            int trueValue;
            if (pos == 0)
                trueValue = 0;
            else
                trueValue = list.Take(pos).ToList().Max() + 1;
            if (startValue == trueValue)
            {
                // shouldn't be possible
                return;
            }

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index] == startValue)
                    list[index] = trueValue;
                else if (list[index] == trueValue)
                    list[index] = startValue;
            }
            


            //// Sort... but on each sort, update all duplicates aswell.
            //var startNumber = list[pos];
            //var rightNumber = list[pos + 1];
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i] == startNumber)
            //    {
            //        list[i] = rightNumber;
            //    }else if (list[i] == rightNumber)
            //    {
            //        list[i] = startNumber;
            //    }
            //}
        }
    }
}
