using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeNumbers.GraphHelpers;

namespace PrimeNumbers.GraphHelpers
{
    class Graph : IEnumerable<Node>
    {
        private NodeList nodeSet;

        #region Constructors

        public Graph() :this(null)
        {

        }

        public Graph(NodeList nodeSet)
        {
            if (nodeSet == null)
            {
               this.nodeSet = new NodeList();
            }
            else
            {
                this.nodeSet = nodeSet;
            }
        }

        #endregion

        #region Public methods

        public void AddNode(Node node)
        {
            nodeSet.Add(node);
        }

        public void AddNode(int value)
        {
            nodeSet.Add(new Node(value));
        }

        public void AddDirectedEdge(Node from, Node to)
        {
            from.Neighbors.Add(to);
        }

        public void AddUndirectedEdge(Node from, Node to)
        {
            from.Neighbors.Add(to);

            to.Neighbors.Add(from);
        }

        public bool Contains(int id)
        {
            return nodeSet.FindById(id) != null;
        }

        public bool Remove(int id)
        {
            //Remove the node from nodeSet
            Node nodeToRemove = (Node)nodeSet.FindById(id);

            //Check if node was found
            if (nodeToRemove == null)
            {
                return false;
            }

            //Otherwise the node was found - remove node
            nodeSet.Remove(nodeToRemove);

            //Enumerate through each node
            foreach (Node gNode in nodeSet)
            {
                int index = gNode.Neighbors.IndexOf(nodeToRemove);

                if (index != -1)
                {
                    gNode.Neighbors.RemoveAt(index);
                }
            }

            return true;
        }
 
        #endregion

        #region Fields

        public NodeList Nodes
        {
            get { return nodeSet; }
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }

        #endregion

        public IEnumerator<Node> GetEnumerator()
        {
            return this.GetEnumerator(); 
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        
    }
}
