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
            
            List<int> unsortedList = read.Select(int.Parse).ToList();
            
            // needs to pass test case: 
            // first   last   median
            // 10297   10184  8921

            double comparisons = new double();
            Quicksort.quicksort(ref unsortedList, 0, unsortedList.Count - 1, ref comparisons);
            Console.WriteLine(comparisons);
        }
    }
}
