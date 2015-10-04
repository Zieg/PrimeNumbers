using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeNumbers.GraphHelpers;
using PrimeNumbers.PrimeOperations;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialization stage
            Graph graph = new Graph();

            Dictionary<int, Node> nodeDictionary = new Dictionary<int, Node>();

            bool[] primeNumArray = PrimeNumberOperations.GetAllPrimes(10000);

            //First iteration. Initialize graph nodes
            for (int i = 1000; i <= 9999; i++)
            {
                if (primeNumArray[i])
                {
                    //Create node
                    Node node = new Node(i);

                    //Add Node to graph
                    graph.AddNode(node);

                    //Add node to dictionary
                    nodeDictionary.Add(i, node);

                }
            }

            //Second iteration. Check potential links between nodes
            for (int i = 1000; i <= 9999; i++)
            {
                if (primeNumArray[i])
                {
                    //foreach potential link - 4321
                    int digit1, digit2, digit3, digit4;

                    digit1 = i % 10;
                    digit2 = (i % 100) / 10;
                    digit3 = (i % 1000) / 100;
                    digit4 = i / 1000;

                    //if link - is prime
                    int[] potentialLinks = new int[36];
                    int counter = 0;

                    for (int j = 1; j <= 9; j++)
                    {
                        if (j != digit4)
                        {
                            potentialLinks[counter] = 1000 * j + 100 * digit3 + 10 * digit2 + digit1;
                            counter++;
                        }
                    }

                    for (int j = 0; j <= 9; j++)
                    {
                        if (j != digit3)
                        {
                            potentialLinks[counter] = 1000 * digit4 + 100 * j + 10 * digit2 + digit1;
                            counter++;
                        }
                    }

                    for (int j = 0; j <= 9; j++)
                    {
                        if (j != digit2)
                        {
                            potentialLinks[counter] = 1000 * digit4 + 100 * digit3 + 10 * j + digit1;
                            counter++;
                        }
                    }

                    for (int j = 0; j <= 9; j++)
                    {
                        if (j != digit1)
                        {
                            potentialLinks[counter] = 1000 * digit4 + 100 * digit3 + 10 * digit2 + j;
                            counter++;
                        }
                    }

                    Node nodeFrom = nodeDictionary[i];

                    //Create edge
                    for (int k = 0; k < counter; k++)
                    {
                        Node nodeTo = null;

                        if (primeNumArray[potentialLinks[k]])
                        {
                            nodeTo = nodeDictionary[potentialLinks[k]];
                            graph.AddUndirectedEdge(nodeFrom, nodeTo);
                        }
                    }
                }
            }


            //Imput and Result output
            Console.WriteLine("Please enter a pair of four digit prime numbers or press 'Ctrl+C' to exit");

            string input;

            while ((input = Console.ReadLine()) != null)
            {

                string[] inputValues = input.Split(new char[] { ' ' }, StringSplitOptions.None);

                try
                {
                    int firstValue = Int32.Parse(inputValues[0]);
                    int secondValue = Int32.Parse(inputValues[1]);

                    Console.WriteLine(DejkstraSolver.DejkstraSolver.FindShortestPath(graph, firstValue, secondValue));
                }
                catch (Exception)
                {
                    Console.WriteLine("Impossible");
                }

            }

        }
    }
}
