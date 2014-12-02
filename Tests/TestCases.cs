using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var topSccs = StronglyConnectedComponents.TopSCCs(newGraph);
            Console.WriteLine(topSccs);
        }

//        [TestMethod]
//        public void TestDijkstra()
//        {
//            const string path = @"dijkstraData.txt";
//            var findPathTo = new List<int>() {7,37,59,82,99,115,133,165,188,197};
//            var file = new StreamReader(path);
//            var dijkstra = new Dijkstra(file);
//            var paths = dijkstra.FindShortestPath(0, findPathTo);
//            Console.WriteLine(paths);
//        }
        // this works, but running time sucks.
        // to do, make this not take several minutes to work.
        [TestMethod]
        public void TestTwoSum()
        {
            const string path = @"TwoSum.txt";
            var file = new StreamReader(path);
            var twoSum = new TwoSum(file, -10000, 10000);
            Console.WriteLine(twoSum.PrintNumberOfTargetValues());

        }
    }
}
