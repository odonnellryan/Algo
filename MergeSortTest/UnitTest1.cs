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
            string path = @"C:\Users\Ryan\Documents\1000.txt";
            string[] read = File.ReadAllLines(path);
            
            //double inversions = 0;
            List<int> unsortedList = read.Select(int.Parse).ToList();
            //List<int> sortedList = RyansMergeSort.SortAndCount(unsortedList, ref inversions);
            
            //Console.WriteLine(inversions);

            double comparisons = new double();
            Quicksort.quicksort(ref unsortedList, 0, unsortedList.Count - 1, ref comparisons);
            Console.WriteLine(comparisons);
        }
    }
}
