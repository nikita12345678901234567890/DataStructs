using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBlackTree;
using static RedBlackTree.LeftLeaningRedBlackTree<int>; //Fight me

namespace RedBlackTreeTests
{
    [TestClass]
    public class LeftLeaningRedBlackTreeUnitTest
    {
        /// <summary>
        /// Generates an int tree of specified size containting [0-size] in random order. (no duplicates)
        /// </summary>
        /// <param name="size">The specified size.</param>
        /// <returns>A ValueTuple containing the tree and an array of integers in the tree.</returns>
        private (LeftLeaningRedBlackTree<int> Tree, int[] Pool) RandomTree(int size)
        {
            Random random = new Random(new Guid().GetHashCode());
            LeftLeaningRedBlackTree<int> tree = new LeftLeaningRedBlackTree<int>();

            //pool setup
            List<int> pool = new List<int>();
            for (int i = 0; i < size; i++)
            {
                pool.Add(i);
            }
            int[] returnPool = pool.ToArray();

            //tree building
            while (pool.Count != 0)
            {
                int index = random.Next(0, pool.Count);
                tree.Add(pool[index]);
                AssertInvariants(tree);
                pool.RemoveAt(index);
            }

            return (tree, returnPool);
        }

        /// <summary>
        /// Asserts that tree invariants are not violated.
        /// </summary>
        /// <param name="tree">The tree in question.</param>
        private void AssertInvariants(LeftLeaningRedBlackTree<int> tree)
        {
            // Root is black
            Assert.IsTrue((null == tree._rootNode) || tree._rootNode.IsBlack, "Root is not black");
            // Every path contains the same number of black nodes
            Dictionary<Node, Node> parents = new Dictionary<Node, Node>();
            foreach (Node node in tree.Traverse(tree._rootNode, n => true, n => n))
            {
                if (null != node.Left)
                {
                    parents[node.Left] = node;
                }
                if (null != node.Right)
                {
                    parents[node.Right] = node;
                }
            }
            if (null != tree._rootNode)
            {
                parents[tree._rootNode] = null;
            }
            int treeCount = -1;
            foreach (Node node in tree.Traverse(tree._rootNode, n => (null == n.Left) || (null == n.Right), n => n))
            {
                int pathCount = 0;
                Node current = node;
                while (null != current)
                {
                    if (current.IsBlack)
                    {
                        pathCount++;
                    }
                    current = parents[current];
                }
                Assert.IsTrue((-1 == treeCount) || (pathCount == treeCount), "Not all paths have the same number of black nodes.");
                treeCount = pathCount;
            }
            // Verify node properties...
            foreach (Node node in tree.Traverse(tree._rootNode, n => true, n => n))
            {
                // Left node is less
                if (null != node.Left)
                {
                    Assert.IsTrue(0 < node.Value.CompareTo(node.Left.Value), "Left node is greater than its parent.");
                }
                // Right node is greater
                if (null != node.Right)
                {
                    Assert.IsTrue(0 > node.Value.CompareTo(node.Right.Value), "Right node is less than its parent.");
                }
                // Both children of a red node are black
                Assert.IsTrue(!tree.IsRed(node) || (!tree.IsRed(node.Left) && !tree.IsRed(node.Right)), "Red node has a red child.");
                // Always left-leaning
                Assert.IsTrue(!tree.IsRed(node.Right) || tree.IsRed(node.Left), "Node is not left-leaning.");
            }
        }

        [TestMethod]
        public void InsertionTest()
        {
            //Tree Setup
            Random random = new Random(new Guid().GetHashCode());
            int count = random.Next(1, 1000);
            LeftLeaningRedBlackTree<int> tree = RandomTree(count).Tree;

            //Counts are equal
            Assert.AreEqual(count, tree.Count, "Counts are not equal");
        }

        [TestMethod]
        public void DeletionTest()
        {
            // Setup tree and pool
            Random random = new Random(new Guid().GetHashCode());
            int count = random.Next(1, 1000);
            var tuple = RandomTree(count);
            LeftLeaningRedBlackTree<int> tree = tuple.Tree;
            List<int> pool = new List<int>(tuple.Pool);

            // Remove from tree
            while (pool.Count != 0)
            {
                int index = random.Next(0, pool.Count);
                tree.Remove(pool[index]);
                AssertInvariants(tree);
                pool.RemoveAt(index);
            }

            // Check tree is empty
            Assert.AreEqual(0, tree.Count, "Tree not empty");
        }

    }
}
