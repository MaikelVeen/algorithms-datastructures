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
            if (value == null) throw new ArgumentException("Value to search for cannot be null");
            Node<T> currentNode = Root;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return currentNode;
                }

                currentNode = currentNode.Value.CompareTo(value) > 0 ? currentNode.Left : currentNode.Right;
            }

            return currentNode;
        }

        public bool Contains(T value)
        {
            Node<T> node = Search(value);
            return node != null;
        }


        /// <summary>
        /// Returns true when value is found and deleted otherwise returns false
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool DeleteValue(T value, Node<T> start)
        {
            if (value == null) throw new ArgumentException("Value to delete cannot be null");

            // The node that needs to be delete
            Node<T> node = start;

            // Find the node
            while (node != null)
            {
                if (node.Value.CompareTo(value) == 0)
                {
                    break;
                }

                node = node.Value.CompareTo(value) > 0 ? node.Left : node.Right;
            }

            if (node == null) return false;

            // Delete a leaf
            if (node.Left == null && node.Right == null)
            {
                DeleteLeaf(node);
            }
            
            // Delete node with one child
            if ((node.Left != null && node.Right == null) || (node.Right != null && node.Left == null))
            {
                DeleteNodeOneChild(node);
            }
            
            // Delete a node with two children
            if (node.Left != null && node.Right != null)
            {
                DeleteNodeWithTwoChildren(node);
            }

            return true;
        }

        // Helper function for leaf deletion
        private static void DeleteLeaf(Node<T> node)
        {
            if (node.Parent.Left != null && node.Parent.Left.Equals(node))
            {
                node.Parent.Left = null;
            }

            if (node.Parent.Right != null && node.Parent.Right.Equals(node))
            {
                node.Parent.Right = null;
            }
        }

        // Helper function that deletes a node with one child
        private static void DeleteNodeOneChild(Node<T> node)
        {
            Node<T> replacementNode = null;
            if (node.Left != null && node.Right == null)
            {
                replacementNode = node.Left;
            }

            else if (node.Right != null && node.Left == null)
            {
                replacementNode = node.Right;
            }

            if (replacementNode == null)
            {
                throw new InvalidOperationException();
            }

            if (IsLeftChild(node))
            {
                node.Parent.Left = replacementNode;
            }
            else
            {
                node.Parent.Right = replacementNode;
            }
        }

        // Checks whether or node is the left child relative to its parent
        private static bool IsLeftChild(Node<T> node)
        {
            return node.Parent.Left != null && node.Parent.Left.Value.Equals(node.Value);
        }

        // Helper function for deletion of node with two children
        private void DeleteNodeWithTwoChildren(Node<T> node)
        {
            Node<T> replacement = FindInOrderSuccesor(node);
            node.Value = replacement.Value;

            DeleteValue(replacement.Value, node.Left);
            DeleteValue(replacement.Value, node.Right);
        }

        /// <summary>
        /// Finds the in order successor of a node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<T> FindInOrderSuccesor(Node<T> node)
        {
            if (node.Right != null)
            {
                return MinValue(node.Right);
            }

            Node<T> parent = node.Parent;
            while (parent != null && node == parent.Right)
            {
                node = parent;
                parent = parent.Parent;
            }

            return parent;
        }


        private static Node<T> MinValue(Node<T> node)
        {
            Node<T> current = node;

            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
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
            if (stringBuilder == null) throw new ArgumentException("stringBuilder cannot be null");

            if (node.Left != null)
            {
                InOrderTraversal(node.Left, stringBuilder);
            }

            stringBuilder.Append(node.Value.ToString());

            if (node.Right != null)
            {
                InOrderTraversal(node.Right, stringBuilder);
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
            if (stringBuilder == null) throw new ArgumentException("stringBuilder cannot be null");

            stringBuilder.Append(node.Value.ToString());
            if (node.Left != null)
            {
                PreOrderTraversal(node.Left, stringBuilder);
            }

            if (node.Right != null)
            {
                PreOrderTraversal(node.Right, stringBuilder);
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
            if (stringBuilder == null) throw new ArgumentException("stringBuilder cannot be null");

            if (node.Left != null)
            {
                PostOrderTraversal(node.Left, stringBuilder);
            }

            if (node.Right != null)
            {
                PostOrderTraversal(node.Right, stringBuilder);
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