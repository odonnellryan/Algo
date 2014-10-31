using System;
using System.IO;
using System.Linq;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MergeSortTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //string path = @"c:\IntegerArray.txt";
            //string[] read = File.ReadAllLines(path);
            
            //double inversions = 0;
            //List<int> unsortedList = read.Select(int.Parse).ToList();
            //List<int> sortedList = RyansMergeSort.SortAndCount(unsortedList, ref inversions);
            
            //Console.WriteLine(inversions);
        
            List<int> unsortedList = new List<int>();

            unsortedList.Add(3);
            unsortedList.Add(2);
            unsortedList.Add(5);
            unsortedList.Add(1);
            unsortedList.Add(4);
            Quicksort.quicksort(ref unsortedList, 0, unsortedList.Count - 1);
            Console.WriteLine(unsortedList);
        }
    }
}
