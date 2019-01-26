using System;
using System.Text;

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
    
        /// <summary>
        /// Returns node with given value, Returns null if not found
        /// </summary>
        /// <param name="value">Value to search for</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Value to search for cannot be null</exception>
        public Node<T> Search(T value)
        {
            if(value == null) throw new ArgumentException("Value to search for cannot be null");
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Returns true is value is found and successfully deleted
        /// Otherwise false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool DeleteValue(T value)
        {
            if(value == null) throw new ArgumentException("Value to delete cannot be null");
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// In order traversal algorithm
        /// Values are appended to stringBuilder and outputted when done
        /// </summary>
        /// <param name="node"></param>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string InOrderTraversal(Node<T> node, StringBuilder stringBuilder)
        {
            if(stringBuilder == null) throw new ArgumentException("stringBuilder cannot be null");
            
            if (node.Left != null)
            {
                InOrderTraversal(node.Left,stringBuilder);
            }
            
            stringBuilder.Append(node.Value.ToString());

            if (node.Right != null)
            {
                InOrderTraversal(node.Right,stringBuilder);
            }

            return stringBuilder.ToString();
        }
        
        /// <summary>
        /// Pre order traversal algorithm
        /// Values are appended to stringBuilder and outputted when done
        /// </summary>
        /// <param name="node"></param>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string PreOrderTraversal(Node<T> node, StringBuilder stringBuilder)
        {
            if(stringBuilder == null) throw new ArgumentException("stringBuilder cannot be null");
            
            stringBuilder.Append(node.Value.ToString());
            if (node.Left != null)
            {
                PreOrderTraversal(node.Left,stringBuilder);
            }

            if (node.Right != null)
            {
                PreOrderTraversal(node.Right,stringBuilder);
            }

            return stringBuilder.ToString();
        }
        
        /// <summary>
        /// Post order traversal algorithm
        /// Values are appended to stringBuilder and outputted when done
        /// </summary>
        /// <param name="node"></param>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string PostOrderTraversal(Node<T> node, StringBuilder stringBuilder)
        {
            if(stringBuilder == null) throw new ArgumentException("stringBuilder cannot be null");
            
            if (node.Left != null)
            {
                PostOrderTraversal(node.Left,stringBuilder);
            }

            if (node.Right != null)
            {
                PostOrderTraversal(node.Right,stringBuilder);
            }
            
            stringBuilder.Append(node.Value.ToString());

            return stringBuilder.ToString();
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