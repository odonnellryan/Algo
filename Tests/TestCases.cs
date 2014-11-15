using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoCourse
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void QuicksortTest()
        {
            const string path = @"QuickSortFullTestCase.txt";
            var read = File.ReadAllLines(path);

            // needs to pass test cases: 
            // size     first    last    median
            // 10       25       29      21
            // 100      615      587     518
            // 1000     10297    10184   8921

            var unsortedList = read.Select(int.Parse).ToList();
            var comparisons = new long();
            Quicksort.Sort(ref unsortedList, 0, unsortedList.Count - 1, ref comparisons, "left");
            //Assert.AreEqual(10297, comparisons);
            Console.WriteLine(comparisons);

            unsortedList = read.Select(int.Parse).ToList();
            comparisons = new long();
            Quicksort.Sort(ref unsortedList, 0, unsortedList.Count - 1, ref comparisons, "right");
            //Assert.AreEqual(29, comparisons);
            Console.WriteLine(comparisons);

            unsortedList = read.Select(int.Parse).ToList();
            comparisons = new long();
            Quicksort.Sort(ref unsortedList, 0, unsortedList.Count - 1, ref comparisons, "median");
            //Assert.AreEqual(8921, comparisons);
            Console.WriteLine(comparisons);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            const string path = @"MergeSortFullTestCase.txt";
            var read = File.ReadAllLines(path);

            var unsortedList = read.Select(int.Parse).ToList();

            var inversions = new long();

            MergeSort.Sort(unsortedList, ref inversions);

            // print the output - this is for an exam, we don't have anything to compare against.
            Console.WriteLine(inversions);

        }
        [TestMethod]
        public void StronglyConnectedComponentsTest()
        {
            const string path = @"SCC.txt";
            var file = new StreamReader(path);
            var newGraph = new Graph(file);

            DepthFirstSearch.Search(newGraph);
            Console.WriteLine(newGraph);
            var topSCCS = StronglyConnectedComponents.TopSCCs(newGraph);
            Console.WriteLine(topSCCS);
        }
    }
}
