using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace PrimeNumbers.GraphHelpers
{

    public class NodeList : Collection<Node>
    {
        #region Constructors

        public NodeList()
            : base()
        {

        }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(Node));
            }
        }

        #endregion

        #region Public Methods

        public Node FindById(int id)
        {
            foreach (Node node in Items)
            {
                if (node.Id.Equals(id))
                {
                    return node;
                }
            }

            return null;
        }
        #endregion

        #region Internal methods

        internal void Add(Node node)
        {
            base.Add(node);
        }

        #endregion
    }
}
