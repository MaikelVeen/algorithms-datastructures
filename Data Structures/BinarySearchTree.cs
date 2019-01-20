using System;

namespace Data_Structures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        /// <summary>
        /// Creates an empty Binary Search Tree
        /// </summary>
        public BinarySearchTree()
        {
        }

        /// <summary>
        /// Creates an Binary Search with a root
        /// </summary>
        /// <param name="value">A value T</param>
        public BinarySearchTree(T value)
        {
            Insert(value);
        }

        public BinarySearchTree(T[] values)
        {
            foreach (T value in values)
            {
                Insert(value);
            }
        }

        public Node<T> Root { get; private set; }
        public int Size { get; private set; }

        /// <summary>
        /// Inserts node with T value.
        /// If root is empty, new node becomes root
        /// Otherwise node is recursively inserted starting from root
        /// </summary>
        /// <param name="value">Value to insert</param>
        public void Insert(T value)
        {
            if (Root == null)
            {
                Size++;
                Root = new Node<T>(value);
            }
            else
            {
                Size++;
                InsertNode(value, Root);
            }
        }

        /// <summary>
        /// Private helper function to recursively insert a new value
        /// into the tree
        /// </summary>
        /// <param name="value">Value to insert</param>
        /// <param name="node">Current node</param>
        private void InsertNode(T value, Node<T> node)
        {
            if (value.CompareTo(node.Value) <= 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value, node);
                }
                else
                {
                    InsertNode(value, node.Left);
                }
            }
            else if (value.CompareTo(node.Value) >= 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value, node);
                }
                else
                {
                    InsertNode(value, node.Right);
                }
            }
        }
    }

    public class Node<T> where T : IComparable
    {
        public Node(T value, Node<T> parent = null)
        {
            Parent = parent;
            Value = value;
            Right = null;
            Left = null;
        }

        public Node<T> Parent { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }
        public T Value { get; set; }
    }
}