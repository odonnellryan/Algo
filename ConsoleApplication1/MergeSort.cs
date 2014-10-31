using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class RyansMergeSort
    {
        public static List<int> SortAndCount(List<int> list, ref double inversions)
        {
            if (list.Count < 2)
            {
                return list;
            }

            List<int> firstList = SortAndCount(list.Take(list.Count / 2).ToList(), ref inversions);
            List<int> secondList = SortAndCount(list.Skip(list.Count / 2).ToList(), ref inversions);

            List<int> final = MergeAndCount(firstList, secondList, ref inversions);

            return final;
        }

        private static List<int> MergeAndCount(List<int> firstList, List<int> secondList, ref double inversions)
        {
            List<int> newList = new List<int>();
            int firstCount = 0;
            int secondCount = 0;
            int newListCount = 0;
            while (firstList.Count > firstCount && secondList.Count > secondCount)
            {
                if (firstList[firstCount] < secondList[secondCount])
                {
                    newList.Add(firstList[firstCount]);
                    firstCount++;
                }
                else if (secondList[secondCount] < firstList[firstCount])
                {
                    inversions += (firstList.Count - firstCount);
                    newList.Add(secondList[secondCount]);
                    secondCount++;
                }
                else
                {
                    newList.Add(firstList[firstCount]);
                    newList.Add(secondList[secondCount]);
                    firstCount++;
                    secondCount++;
                }
                newListCount++; 
            }

            while (firstList.Count > firstCount)
            {
                newList.Add(firstList[firstCount]);
                firstCount++;
            }
            while (secondList.Count > secondCount)
            {
                newList.Add(secondList[secondCount]);
                secondCount++;
            }

            return newList;
        } 
    }
    
}
