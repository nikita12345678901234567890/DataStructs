using System;
using System.Collections.Generic;

namespace RedBlackTree
{
    public class Node<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gets or sets the node's value
        /// </summary>
        public T Value;

        /// <summary>
        /// Gets or sets the left Node<T>.
        /// </summary>
        public Node<T> Left;

        /// <summary>
        /// Gets or sets the right Node<T>.
        /// </summary>
        public Node<T> Right;

        /// <summary>
        /// Gets or sets the color of the Node<T>.
        /// </summary>
        public bool IsBlack;

        /// <summary>
        /// Initializes a new instance of the Node<T> class.
        /// </summary>
        /// <remarks>
        /// IsBlack is defaulted to false as new Node<T>s added to a red black tree must be red.
        /// </remarks>
        /// <param name="value">The value of the Node<T>.</param>
        public Node(T value)
        {
            this.Value = value;
            IsBlack = false;
            Left = null;
            Right = null;
        }
    }

    /// <summary>
    /// Implements a left-leaning red-black tree.
    /// </summary>
    /// <remarks>
    /// Based on the research paper "Left-leaning Red-Black Trees"
    /// by Robert Sedgewick. More information available at:
    /// https://www.cs.princeton.edu/~rs/talks/LLRB/LLRB.pdf
    /// https://www.cs.princeton.edu/~rs/talks/LLRB/RedBlack.pdf
    /// </remarks>
    /// <typeparam name="T">Type of values.</typeparam>
    public class LeftLeaningRedBlackTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Stores the root Node<T> of the tree.
        /// </summary>
        internal Node<T> _rootNode;

        /// <summary>
        /// Gets the count of values in the tree.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Represents a node of the tree.
        /// </summary>
        

        /// <summary>
        /// Initializes a new instance of the LeftLeaningRedBlackTree class.
        /// </summary>
        public LeftLeaningRedBlackTree()
        {
            Count = 0;
            _rootNode = null;
        }

        /// <summary>
        /// Adds a value to the tree.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void Add(T value)
        {
            _rootNode = Add(_rootNode, value);
            _rootNode.IsBlack = true;
        }

        /// <summary>
        /// Adds the specified value below the specified root node.
        /// </summary>
        /// <param name="node">Specified node.</param>
        /// <param name="value">Value to add.</param>
        /// <returns>New root node.</returns>
        private Node<T> Add(Node<T> node, T value)
        {
            if (node == null)
            {
                // Insert new node
                Count++;
                return new Node<T>(value);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                // Split (4-node) node with two red children
                FlipColor(node);
            }

            // Find right place for new node
            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Add(node.Left, value);
            }
            else if (value.CompareTo(node.Value) >= 0)
            {
                node.Right = Add(node.Right, value);
            }
            else
            {
                // There are 3 options when dealing with duplicate values
                // 1) Throw an excaption.
                // 2) Allow duplicate values on right (or left, just be consistent).
                // 3) Add a Count variable to the node class and increment it when a duplicate values arrives.
                throw new ArgumentException("An entry with the same value arleady exists");
            }

            if (IsRed(node.Right))
            {
                // Rotate to prevent red node on right
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                // Rotate to prevent consecutive red nodes
                node = RotateRight(node);
            }

            return node;
        }

        /// <summary>
        /// Removes a value from the tree.
        /// </summary>
        /// <param name="value">Value to remove.</param>
        /// <returns>True if value present and removed.</returns>
        public bool Remove(T value)
        {
            int initialCount = Count;
            if (_rootNode != null)
            {
                _rootNode = Remove(_rootNode, value);
                if (_rootNode != null)
                {
                    _rootNode.IsBlack = true;
                }
            }

            return initialCount != Count;
        }

        /// <summary>
        /// Removes the specified value from below the specified node.
        /// </summary>
        /// <remarks>
        /// The end goal of remove is to ensure that the value we want to remove is within a 3-node or a 4-node.
        /// To accomplish such, we carry a red node down the tree with the MoveRedLeft and MoveRedRight functions.
        /// The Fixup function will recover the invariants of the tree as the recursion unwinds.
        /// </remarks>
        /// <param name="node">Specified node.</param>
        /// <param name="value">Value to remove.</param>
        /// <returns>True if value present and removed.</returns>
        private Node<T> Remove(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                // Continue search if left is present
                if (node.Left != null)
                {
                    // As we travel down the left, carry a red node with us if necessary
                    if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                    {
                        // Move a red node over
                        node = MoveRedLeft(node);
                    }

                    // Remove from left recursive call
                    node.Left = Remove(node.Left, value);
                }
            }
            else
            {
                if (IsRed(node.Left))
                {
                    // Flip a node with 1 red child (3-node) or unbalance a node with 2 red children (4-node)
                    node = RotateRight(node);
                }

                if (value.CompareTo(node.Value) == 0 && node.Right == null)
                {
                    // Remove a leaf node
                    Count--;
                    return null;
                }

                // Continue search if right is present
                if (node.Right != null)
                {
                    // As we travel down the right, carry a red node with us if necessary
                    if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                    {
                        node = MoveRedRight(node);
                    }
                    if (value.CompareTo(node.Value) == 0)
                    {
                        // Remove a node with 2 children
                        //Count--;

                        // Find the smallest node on the right sub-tree, swap, and remove it
                        // (binary tree removal when node has 2 children)
                        Node<T> min = GetMinimum(node.Right);
                        node.Value = min.Value;
                        node.Right = Remove(node.Right, min.Value);
                        //node.Right = DeleteMinimum(node.Right);
                    }
                    else
                    {
                        // Remove from right recursive call
                        node.Right = Remove(node.Right, value);
                    }
                }
            }

            // Maintains invariants
            return Fixup(node);
        }

        /// <summary>
        /// Deletes the minimum node under the specified node.
        /// </summary>
        /// <param name="node">Specified node.</param>
        /// <returns>New root node.</returns>
        private Node<T> DeleteMinimum(Node<T> node)
        {
            if (node.Left == null)
            {
                // Nothing to do
                return null;
            }

            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            {
                // Move red node left
                node = MoveRedLeft(node);
            }

            // Recursively delete
            node.Left = DeleteMinimum(node.Left);

            //Maintain invariants
            return Fixup(node);
        }

        /// <summary>
        /// Removes all nodes in the tree.
        /// </summary>
        public void Clear()
        {
            _rootNode = null;
            Count = 0;
        }

        /// <summary>
        /// Rotate the specified node "left" and perform recoloring.
        /// </summary>
        /// <param name="node">Specified node.</param>
        /// <returns>New root node.</returns>
        private Node<T> RotateLeft(Node<T> node)
        {
            // Rotate
            Node<T> temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            // Recolor
            temp.IsBlack = node.IsBlack;
            node.IsBlack = false;

            return temp;
        }

        /// <summary>
        /// Rotate the specified node "right" and perform recoloring.
        /// </summary>
        /// <param name="node">Specified node.</param>
        /// <returns>New root node.</returns>
        private Node<T> RotateRight(Node<T> node)
        {
            // Rotate
            Node<T> temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            // Recolor
            temp.IsBlack = node.IsBlack;
            node.IsBlack = false;

            return temp;
        }

        /// <summary>
        /// Flip the colors of the specified node and its direct children.
        /// </summary>
        /// <param name="node">Specified node.</param>
        private void FlipColor(Node<T> node)
        {
            node.IsBlack = !node.IsBlack;
            node.Left.IsBlack = !node.Left.IsBlack;
            node.Right.IsBlack = !node.Right.IsBlack;
        }

        /// <summary>
        /// Moves a red node from the right child to the left child.
        /// </summary>
        /// <param name="node">Parent node.</param>
        /// <returns>New root node.</returns>
        private Node<T> MoveRedLeft(Node<T> node)
        {
            FlipColor(node);
            if (IsRed(node.Right.Left))
            {
                //double rotate
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);

                FlipColor(node);

                // avoid creating right-leaning nodes
                if (IsRed(node.Right.Right))
                {
                    node.Right = RotateLeft(node.Right);
                }
            }

            return node;
        }

        /// <summary>
        /// Moves a red node form the left child to the right child.
        /// </summary>
        /// <param name="node">Parent node.</param>
        /// <returns>New root node.</returns>
        private Node<T> MoveRedRight(Node<T> node)
        {
            FlipColor(node);
            if (IsRed(node.Left.Left))
            {
                node = RotateRight(node);
                FlipColor(node);
            }

            return node;
        }

        /// <summary>
        /// Gets the minimum value in a tree/sub-tree.
        /// </summary>
        /// <param name="node">Node to start from.</param>
        /// <returns>Minimum node.</returns>
        private Node<T> GetMinimum(Node<T> node)
        {
            Node<T> temp = node;
            while (temp.Left != null)
            {
                temp = temp.Left;
            }
            return temp;
        }

        /// <summary>
        /// Maintains rules/invariants by adjusting the specified nodes children.
        /// </summary>
        /// <param name="node">Specified node.</param>
        /// <returns>New root node.</returns>
        private Node<T> Fixup(Node<T> node)
        {
            if (IsRed(node.Right))
            {
                // Enforce left leaning policy
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                // balance a (4-node) node with 2 reds on the left
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                // Push Red Up (break up 4-node)
                FlipColor(node);
            }

            // Avoid leaving behind right-leaning nodes
            if ((node.Left != null) && IsRed(node.Left.Right) && !IsRed(node.Left.Left))
            {
                node.Left = RotateLeft(node.Left);

                // Avoid red touching red
                if (IsRed(node.Left))
                {
                    //Balance a (4-node) node with 2 red children
                    node = RotateRight(node);
                }
            }

            return node;
        }

        /// <summary>
        /// Returns true if the specified node is red.
        /// </summary>
        /// <remarks>
        /// NIL nodes are black as per Red-Black tree rules. So if the node is null, the color is black.
        /// Useful since it includes a null check here instead of in the other functions.
        /// </remarks>
        /// <param name="node">Specified node.</param>
        /// <returns>True if specified node is red.</returns>
        internal bool IsRed(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            return !node.IsBlack;
        }

        

        public IEnumerable<Node<T>> PreOrderNode()
        {
            Queue<Node<T>> nodes = new Queue<Node<T>>();

            preOrder(_rootNode);

            return nodes;

            void preOrder(Node<T> current)
            {
                nodes.Enqueue(current);

                if (current.Left != null)
                {
                    preOrder(current.Left);
                }

                if (current.Right != null)
                {
                    preOrder(current.Right);
                }
            }
        }
    }
}
