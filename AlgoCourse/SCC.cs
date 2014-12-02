using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlgoCourse
{
    public partial class Graph {

        public partial class Node
        {
            public int leader = 0;
            public int Id;
            public int FinishingTime = 0;
            public bool explored = false;
            public List<Node> Children = new List<Node>();
            public List<Node> Parents = new List<Node>();
            public Node(int id)
            {
                Id = id;
            }
        }

        public Dictionary<int, Node> NodeCollection = new Dictionary<int, Node>();
        public Dictionary<int, Node> NodeCollectionFinish = new Dictionary<int, Node>();

        public Graph(TextReader graphData)
        {
            string line;
            while ((line = graphData.ReadLine()) != null)
            {
                var data = line.Split(' ');
                var parentNode = Int32.Parse(data[0]);
                var childNode = Int32.Parse(data[1]);

                Utils.AddNodes(ref NodeCollection, parentNode, childNode);

            }
        }

    }

    public static class Utils
    {
        public static void AddNodes(ref Dictionary<int, Graph.Node> nodeCol, int parentNode, int childNode)
        {

            if (!nodeCol.ContainsKey(childNode))
            {
                nodeCol[childNode] = new Graph.Node(childNode);
            }

            if (!nodeCol.ContainsKey(parentNode))
            {
                nodeCol[parentNode] = new Graph.Node(parentNode);
            }

            nodeCol[parentNode].Children.Add(nodeCol[childNode]);
            nodeCol[childNode].Parents.Add(nodeCol[parentNode]);
        }
    }

    public class DepthFirstSearch
    {
        public static void Search(Graph graph)
        {
            var finishingTime = 0;
            // will want to loop over the items in sequence. 
            var keys = graph.NodeCollection.Keys.ToList();
            keys.Sort();

            for (var key = keys.Count(); key > 0; key--)
            {
                if (!graph.NodeCollection[key].explored)
                {
                    SetFinishingTime(graph, ref finishingTime, key);
                }
            }

            for (var key = keys.Count(); key > 0; key--)
            {
                foreach (var child in graph.NodeCollection[key].Children)
                {
                    Utils.AddNodes(ref graph.NodeCollectionFinish, graph.NodeCollection[key].FinishingTime, child.FinishingTime);
                }
            }

            keys = graph.NodeCollectionFinish.Keys.ToList();
            keys.Sort();

            for (var key = keys.Count(); key > 0; key--)
            {
                if (!graph.NodeCollectionFinish[key].explored)
                {
                    SetLeader(graph, key, key);
                }
            }

        }

        static void SetLeader(Graph graph, int leader, int key)
        {
            var stack = new Stack<Graph.Node>();
            stack.Push(graph.NodeCollectionFinish[key]);
            while (stack.Count != 0)
            {
                var curNode = stack.Pop();
                if (!curNode.explored)
                {
                    curNode.explored = true;
                    stack.Push(curNode);
                    foreach (Graph.Node child in curNode.Children)
                    {
                        if (!child.explored)
                        {
                            stack.Push(child);
                        }
                    }
                }
                else
                {
                    if (curNode.leader == 0)
                    {
                        curNode.leader = leader;
                    }
                }
            }
        }

        static void SetFinishingTime(Graph graph, ref int finishingTime, int key)
        {
            var stack = new Stack<Graph.Node>();
            stack.Push(graph.NodeCollection[key]);

            while (stack.Count != 0)
            {
                var curNode = stack.Pop();
                if (!curNode.explored)
                {
                    curNode.explored = true;
                    stack.Push(curNode);
                    foreach (Graph.Node parent in curNode.Parents)
                    {
                        if (!parent.explored)
                        {
                            stack.Push(parent);
                        }
                    }
                }
                else
                {
                    if (curNode.FinishingTime == 0)
                    {
                        finishingTime++;
                        curNode.FinishingTime = finishingTime;
                    }
                }
            }
        }
    }

    public static class StronglyConnectedComponents
    {

        public static List<KeyValuePair<int, int>> TopSCCs(Graph graph)
        {
            var countSCCs = new Dictionary<int, int>();
            foreach (var key in graph.NodeCollectionFinish.Keys)
            {
                if (!countSCCs.ContainsKey(graph.NodeCollectionFinish[key].leader))
                    countSCCs[graph.NodeCollectionFinish[key].leader] = 1;
                else
                    countSCCs[graph.NodeCollectionFinish[key].leader]++;
            }

            var myList = countSCCs.ToList();

            myList.Sort((firstPair, nextPair) => firstPair.Value.CompareTo(nextPair.Value));

            return myList;
        }

    }
} 
