using PrimeNumbers.GraphHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers.DejkstraSolver
{
    class DejkstraSolver
    {

        public static int FindShortestPath(Graph graph, int startNodeId, int finishNodeId)
        {
            foreach (Node node in graph.Nodes)
            {
                node.IsActive = true;

                node.Path = new NodeList();

                if (node.Id == startNodeId)
                {
                    node.Counter = 0;
                }
                else
                {
                    node.Counter = Int32.MaxValue;
                }
            }

            SolverStep(graph);

            foreach (Node node in graph.Nodes)
            {
                System.IO.File.AppendAllText(@"D:\int.txt", "---" + node.Id + " -> " + node.Counter + "\n");
            }

            foreach (Node node in graph.Nodes)
            {
                if (node.Id == finishNodeId)
                {
                    foreach (Node nodeItem in node.Path)
                    {
                        Console.WriteLine("-- " + nodeItem.Id);
                    }
                    return node.Counter;
                }
            }

            return Int32.MaxValue;
        }

        public static void SolverStep(Graph graph)
        {
            while (true)
            {
                Node minCounterNode = null;

                foreach (Node node in graph.Nodes)
                {
                    if (node.IsActive == false)
                    {
                        continue;
                    }

                    if (minCounterNode == null)
                    {
                        minCounterNode = node;
                    }
                    else
                    {
                        if (node.Counter < minCounterNode.Counter)
                        {
                            minCounterNode = node;
                        }
                    }
                }

                if (minCounterNode == null || minCounterNode.Counter == Int32.MaxValue)
                {
                    return;
                }

                foreach (Node neighborNode in minCounterNode.Neighbors)
                {
                    if (neighborNode.Counter > minCounterNode.Counter + 1)
                    {
                        neighborNode.Counter = minCounterNode.Counter + 1;

                        neighborNode.Path = new NodeList();

                        foreach (Node item in minCounterNode.Path)
                        {
                            neighborNode.Path.Add(item);
                        }

                        neighborNode.Path.Add(neighborNode);
                    }
                }

                minCounterNode.IsActive = false;
            }
        }

    }
}
