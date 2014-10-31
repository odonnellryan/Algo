﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Quicksort
    {
        public static void quicksort(ref List<int> unsortedList, int leftIndex, int rightIndex, ref double comparisons)
        {
            if (unsortedList.Count < 2)
            {
                return;
            }
            if (leftIndex < rightIndex)
            {
                int pivot = Partition(ref unsortedList, leftIndex, rightIndex, ref comparisons);
                quicksort(ref unsortedList, leftIndex, pivot - 1, ref comparisons);
                quicksort(ref unsortedList, pivot + 1, rightIndex, ref comparisons);
            }
            
        }

        public static int Partition(ref List<int> unsortedList, int leftIndex, int rightIndex, ref double comparisons)
        {
            comparisons += rightIndex - leftIndex;
            int tmp;
            int pivot = unsortedList[leftIndex];
            int separator = leftIndex + 1;
            for (int j = leftIndex + 1; j <= rightIndex; j++)
            {
                if (unsortedList[j] < pivot)
                {
                    tmp = unsortedList[j];
                    unsortedList[j] = unsortedList[separator];
                    unsortedList[separator] = tmp;
                    separator++;
                }
            }
            // move the pivot element into its proper location
            tmp = unsortedList[leftIndex];
            unsortedList[leftIndex] = unsortedList[separator - 1];
            unsortedList[separator - 1] = tmp;
            return separator - 1;
        }
    }
}
