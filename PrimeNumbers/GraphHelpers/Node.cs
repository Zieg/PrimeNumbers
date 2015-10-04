using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers.GraphHelpers
{
    /// <summary>
    /// A class that represents a node
    /// </summary>
    public class Node
    {
        #region Private members

        private int id;
        private int counter;
        private NodeList neighbors = new NodeList();
        private NodeList path;
        private bool isActive;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new node
        /// </summary>
        /// <param name="value">Integer value of the node</param>
        public Node(int value)
        {
            this.id = value;
        }

        /// <summary>
        /// Creates a new node
        /// </summary>
        /// <param name="value">Integer value of the node</param>
        /// <param name="neighbors">A list of neighbor nodes</param>
        public Node(int value, NodeList neighbors)
        {
            this.id = value;
            this.neighbors = neighbors;
        }

        #endregion

        #region Fields

        /// <summary>
        /// Id of the node
        /// </summary>
        public int Id
        {
            get { return id; }

            set { id = value; }
        }

        /// <summary>
        /// A list of neighbor nodes
        /// </summary>
        internal NodeList Neighbors
        {
            get { return neighbors; }

            set { neighbors = value; }
        }

        #endregion

        /// <summary>
        /// A counter to mark node and check if it was already visited
        /// </summary>
        public void IncreaseCounter()
        {
            counter++;
        }

        /// <summary>
        /// A field that represents the counter
        /// </summary>
        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public NodeList Path
        {
            get { return path; }

            set { path = value; }
        }
    }
}
