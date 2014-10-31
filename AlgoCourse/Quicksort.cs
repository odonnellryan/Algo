using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoCourse
{
    public static class Quicksort
    {
        public static void Sort(ref List<int> unsortedList, int leftIndex, int rightIndex, ref long comparisons, string testCase)
        {
            if (unsortedList.Count < 2)
            {
                return;
            }
            if (leftIndex < rightIndex)
            {
                SetPivot(ref unsortedList, leftIndex, rightIndex, testCase);
                int pivot = Partition(ref unsortedList, leftIndex, rightIndex, ref comparisons);
                Sort(ref unsortedList, leftIndex, pivot - 1, ref comparisons, testCase);
                Sort(ref unsortedList, pivot + 1, rightIndex, ref comparisons, testCase);
            }
            
        }

        private static int Partition(ref List<int> unsortedList, int leftIndex, int rightIndex, ref long comparisons)
        {
            comparisons += rightIndex - leftIndex;
            int pivot = unsortedList[leftIndex];
            int separator = leftIndex + 1;
            for (int j = leftIndex + 1; j <= rightIndex; j++)
            {
                if (unsortedList[j] < pivot)
                {
                    Swap(ref unsortedList, j, separator);
                    separator++;
                }
            }
            // move the pivot element into its proper location
            Swap(ref unsortedList, leftIndex, separator - 1);
            return separator - 1;
        }
        private static void SetPivot(ref List<int> unsortedList, int leftIndex, int rightIndex, string testCase)
        {
            // method to move the pivot to the beginning of the array subset.
            // this is implemented here, because the course insisted on using their 
            // exact partitioning algorythm (to ensure tests pass)
            // three cases:
            // 1) left (do nothing) 2) median (-of-three) 3) right (swap first with right-most)
            if (testCase == "left")
            {
                return;
            }
            if (testCase == "median")
            {
                int middleIndex;
                int size = (rightIndex - leftIndex) + 1;
                if (size < 3)
                {
                    return;
                }
                if (size % 2 != 0)
                {
                    middleIndex = leftIndex + ((size - 1) / 2);
                }
                else
                {
                    middleIndex = leftIndex + ((size / 2) - 1);
                }

                if (unsortedList[middleIndex] > unsortedList[leftIndex])
                {
                    if (unsortedList[leftIndex] > unsortedList[rightIndex])
                    {
                        // return if left is the median index, no swap needed.
                        return;
                    }
                    if (unsortedList[rightIndex] > unsortedList[middleIndex])
                    {
                        Swap(ref unsortedList, leftIndex, middleIndex);
                    }
                    else // right is the median index
                    {
                        Swap(ref unsortedList, leftIndex, rightIndex);
                    }
                }
                else // left is more than middle (MLx)
                {
                    if (unsortedList[rightIndex] > unsortedList[leftIndex])
                    {
                        // return if left is the median index, no swap needed.
                        return;
                    }
                    if (unsortedList[middleIndex] > unsortedList[rightIndex])
                    {
                        Swap(ref unsortedList, leftIndex, middleIndex);
                    }
                    else // right is the median index
                    {
                        Swap(ref unsortedList, leftIndex, rightIndex);
                    }
                }
                // naive way (using sort)
                // List<int> list = new List<int>() { unsortedList[rightIndex], unsortedList[leftIndex], unsortedList[middleIndex] };
                // list.Sort();
                // int index = unsortedList.IndexOf(list[1]);
                // Swap(ref unsortedList, leftIndex, index);
                return;
            }
            if (testCase == "right") {
                Swap(ref unsortedList, leftIndex, rightIndex);
                return;
            }
        }
        private static void Swap(ref List<int> unsortedList, int firstIndex, int secondIndex)
        {
            int tmp = unsortedList[firstIndex];
            unsortedList[firstIndex] = unsortedList[secondIndex];
            unsortedList[secondIndex] = tmp;
        }
    }
}
