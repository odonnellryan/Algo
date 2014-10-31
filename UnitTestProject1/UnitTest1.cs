using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> unsortedList = new List<int> { 1, 2, 5, 6, 22, 33, 3, 4, 5 };
            List<int> sortedList = RyansMergeSort.SortAndCount(unsortedList);
            Console.WriteLine(sortedList);
        }
    }
}
