using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        //regular variables
        private Node root;
        private int numberElements;

        //extra variables
        private Node insertedNode;
        private Node nodeBeingDeleted;
        private bool siblingToRight;
        private bool parentToRight;
        private bool nodeToDeleteRed;

        private class Node
        {
            private T item;
            private Node left;
            private Node right;
            private Node parent;
            private bool red = true;

            public Node(T item, Node parent)
            {
                this.item = item;
                this.parent = parent;
                left = right = null;
            }

            public Node Left
            {
                get => left;
                set => left = value;
            }

            public Node Right
            {
                get => right;
                set => right = value;
            }

            public Node Parent
            {
                get => parent;
                set => parent = value;
            }

            public T Item
            {
                get => item;
                set => item = value;
            }

            public bool Red
            {
                get => red;
                set => red = value;
            }
        }

        //inserts item, calls FixTreeAfterInsertion
        public void Add(T item)
        {
            root = InsertNode(root, item, null);
            numberElements++;
            if (numberElements > 2)
            {
                Node parent;
                Node grandParent;
                Node greatGrandParent;

                GetNodesAbove(insertedNode, out parent, out grandParent, out greatGrandParent);
                FixTreeAfterInsertion(insertedNode, parent, grandParent, greatGrandParent);
            }
        }

        //deletes node, increases childs black level if needed (but only right child??), checks if FixTree is required
        public void Remove(T item)
        {
            if (numberElements > 0)
            {
                root = DeleteNode(root, item, null);
                numberElements--;
                if (numberElements == 0)
                {
                    root = null;
                    return;
                }
                Node curNode = null; //Right child of node being deleted (will stay null if there is no right child)
                //why only right?
                if (nodeBeingDeleted.Right != null)
                {
                    curNode = nodeBeingDeleted.Right;
                }
                Node parent;
                Node sibling;
                Node grandParent;
                if (curNode == null)
                {
                    parent = nodeBeingDeleted.Parent;
                }
                else
                {
                    parent = curNode.Parent;
                }
                GetParentGrandParentSibling(curNode, parent, out sibling, out grandParent);

                if (curNode != null && curNode.Red)
                {
                    curNode.Red = false; //increasing childs blackness level
                }
                else if (!nodeToDeleteRed && !nodeBeingDeleted.Red) //if the node being deleted is black (are both of these variables necessary?)
                {
                    FixTreeAfterDeletion(curNode, parent, sibling, grandParent);
                }
                root.Red = false;

            }
        }

        //recursive bst insert
        private Node InsertNode(Node node, T item, Node parent)
        {
            if (node == null)
            {
                Node newNode = new Node(item, parent);

                //newNode.Red = numberElements > 0;
                if (numberElements > 0)
                {
                    newNode.Red = true;
                }
                else
                {
                    newNode.Red = false;
                }
                insertedNode = newNode;
                return newNode;
            }
            else if (item.CompareTo(node.Item) < 0)
            {
                node.Left = InsertNode(node.Left, item, node);
                return node;
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                node.Right = InsertNode(node.Right, item, node);
                return node;
            }
            else
            {
                //not required
                throw new InvalidOperationException("Cannot add duplicate object");
            }
        }

        //Brings child up
        private void RightRotate(ref Node node)
        {
            Node nodeParent = node.Parent;
            Node left = node.Left;
            Node temp = left.Right;

            left.Right = node;
            node.Parent = left;
            node.Left = temp;

            if (temp != null)
            {
                temp.Parent = node;
            }
            if (left != null)
            {
                left.Parent = nodeParent;
            }
            node = left;
        }

        //Brings child up
        private void LeftRotate(ref Node node)
        {
            Node nodeParent = node.Parent;
            Node right = node.Right;
            Node temp = right.Left;

            right.Left = node;
            node.Parent = right;
            node.Right = temp;

            if (temp != null)
            {
                temp.Parent = node;
            }
            if (right != null)
            {
                right.Parent = nodeParent;
            }
            node = right;
        }

        //gets parent, grandparent, and ggrandparent
        private void GetNodesAbove(Node curNode, out Node parent,
                                    out Node grandParent,
                                    out Node greatGrandParent)
        {
            parent = null;
            grandParent = null;
            greatGrandParent = null;
            if (curNode != null)
            {
                parent = curNode.Parent;
            }
            if (parent != null)
            {
                grandParent = parent.Parent;
            }
            if (grandParent != null)
            {
                greatGrandParent = grandParent.Parent;
            }
        }

        //also sets extra variables
        private void GetParentGrandParentSibling(Node curNode,
                          Node parent,
                          out Node sibling, out Node grandParent)
        {
            sibling = null;
            grandParent = null;
            if (parent != null)
            {
                if (parent.Right == curNode)
                {
                    siblingToRight = false;
                    sibling = parent.Left;
                }
                if (parent.Left == curNode)
                {
                    siblingToRight = true;
                    sibling = parent.Right;
                }
            }
            if (parent != null)
            {
                grandParent = parent.Parent;
            }
            if (grandParent != null)
            {
                if (grandParent.Right == parent)
                {
                    parentToRight = true;
                }
                if (grandParent.Left == parent)
                {
                    parentToRight = false;
                }
            }
        }

        //standard rb fixup, only recursive for the non-rotation case
        private void FixTreeAfterInsertion(Node child, Node parent,
            Node grandParent,
            Node greatGrandParent)
        {
            if (grandParent != null)
            {
                Node uncle = (grandParent.Right == parent) ? grandParent.Left : grandParent.Right;

                //uncle and parent are red
                if (uncle != null && parent.Red && uncle.Red)
                {
                    //push black level down
                    uncle.Red = false;
                    parent.Red = false;
                    grandParent.Red = true;

                    //recurse to check above
                    Node higher = null;
                    Node stillHigher = null;
                    if (greatGrandParent != null)
                    {
                        higher = greatGrandParent.Parent;
                    }
                    if (higher != null)
                    {
                        stillHigher = higher.Parent;
                    }
                    FixTreeAfterInsertion(grandParent, greatGrandParent, higher, stillHigher);
                }
                //uncle is black, parent red
                else if (uncle == null || parent.Red && !uncle.Red)
                {
                    //right-right case
                    if (grandParent.Right == parent && parent.Right == child)
                    {
                        parent.Red = false;
                        grandParent.Red = true;
                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            LeftRotate(ref root);
                        }
                    }
                    //left-left case
                    else if (grandParent.Left == parent && parent.Left == child)
                    {
                        parent.Red = false;
                        grandParent.Red = true;
                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            RightRotate(ref root);
                        }
                    }
                    //right-left case
                    else if (grandParent.Right == parent && parent.Left == child)
                    {
                        //initial rotate
                        child.Red = false;
                        grandParent.Red = true;
                        RightRotate(ref parent);
                        grandParent.Right = parent;

                        //right-right
                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                LeftRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            LeftRotate(ref root);
                        }
                    }
                    //left-right case
                    else if (grandParent.Left == parent && parent.Right == child)
                    {
                        child.Red = false;
                        grandParent.Red = true;
                        LeftRotate(ref parent);
                        grandParent.Left = parent;

                        //left-left
                        if (greatGrandParent != null)
                        {
                            if (greatGrandParent.Right == grandParent)
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Right = grandParent;
                            }
                            else
                            {
                                RightRotate(ref grandParent);
                                greatGrandParent.Left = grandParent;
                            }
                        }
                        else
                        {
                            RightRotate(ref root);
                        }
                    }
                }
                if (root.Red)
                {
                    root.Red = false;
                }
            }
        }

        //bst delete with recursion
        private Node DeleteNode(Node node, T item, Node parent)
        {
            if (node == null)
            {
                throw new InvalidOperationException("item not in search tree.");
            }

            //finding the item
            if (item.CompareTo(node.Item) < 0)
            {
                node.Left = DeleteNode(node.Left, item, node);
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                node.Right = DeleteNode(node.Right, item, node);
            }
            //Item found
            else if (item.CompareTo(node.Item) == 0)
            {
                nodeToDeleteRed = node.Red;
                nodeBeingDeleted = node;
                if (node.Left == null)
                {
                    //no children or only right child
                    node = node.Right;
                    if (node != null)
                    {
                        node.Parent = parent;
                    }
                }
                else if (node.Right == null)
                {
                    //only a left child
                    node = node.Left;
                    node.Parent = parent;
                }
                else
                {
                    //two children
                    //Deletes using the leftmost node of the right subtree (Not a Ryan choice, just following along)
                    T replaceWithValue = LeftMost(node.Right);
                    node.Right = DeleteLeftMost(node.Right, node);
                    node.Item = replaceWithValue;
                }
            }
            return node;
        }

        //recursive
        private Node DeleteLeftMost(Node node, Node parent)
        {
            if (node.Left == null)
            {
                nodeBeingDeleted = node;
                if (node.Right != null)
                {
                    //shouldn't this be node.Right.Parent = parent ?
                    node.Parent = parent;
                }
                return node.Right;
            }
            else
            {
                node.Left = DeleteLeftMost(node.Left, node);
                return node;
            }
        }

        //recursive
        private T LeftMost(Node node)
        {
            if (node.Left == null)
            {
                return node.Item;
            }
            else
            {
                return LeftMost(node.Left);
            }
        }

        private void FixTreeAfterDeletion(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {

            //getting siblings children info
            Node siblingLeftChild = null;
            Node siblingRightChild = null;
            if (sibling != null && sibling.Left != null)
            {
                siblingLeftChild = sibling.Left;
            }
            if (sibling != null && sibling.Right != null)
            {
                siblingRightChild = sibling.Right;
            }
            bool siblingRed = (sibling != null && sibling.Red);
            bool siblingLeftRed = (siblingLeftChild != null && siblingLeftChild.Red);
            bool siblingRightRed = (siblingRightChild != null && siblingRightChild.Red);

            //calling the different cases

            //sibling is red
            if (parent != null && !parent.Red && siblingRed && !siblingLeftRed && !siblingRightRed)
            {
                Case1(curNode, parent, sibling, grandParent);
            }
            //sibling black and both children black
            else if (parent != null && !parent.Red && !siblingRed && !siblingLeftRed && !siblingRightRed)
            {
                Case2A(curNode, parent, sibling, grandParent);
            }
            //parent red and sibling black with black children
            else if (parent != null && parent.Red && !siblingRed && !siblingLeftRed && !siblingRightRed)
            {
                Case2B(curNode, parent, sibling, grandParent);
            }
            //right left case
            else if (siblingToRight && !siblingRed && siblingLeftRed && !siblingRightRed)
            {
                Case3(curNode, parent, sibling, grandParent);
            }
            //left right case
            else if (!siblingToRight && !siblingRed && !siblingLeftRed & siblingRightRed)
            {
                Case3P(curNode, parent, sibling, grandParent);
            }
            //right right case
            else if (siblingToRight && !siblingRed && siblingRightRed)
            {
                Case4(curNode, parent, sibling, grandParent);
            }
            //left left case
            else if (!siblingToRight && !siblingRed && siblingLeftRed)
            {
                Case4P(curNode, parent, sibling, grandParent);
            }
        }

        private void Case1(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {
            if (siblingToRight)
            {
                parent.Red = !parent.Red;
                sibling.Red = !sibling.Red;

                if (grandParent != null)
                {
                    if (parentToRight)
                    {
                        LeftRotate(ref parent);
                        grandParent.Right = parent;
                    }
                    else if (!parentToRight)
                    {
                        LeftRotate(ref parent);
                        grandParent.Left = parent;
                    }
                }
                else
                {
                    LeftRotate(ref parent);
                    root = parent;
                }
                grandParent = sibling;
                parent = parent.Left;
                parentToRight = false;
            }
            else if (!siblingToRight)
            {
                parent.Red = !parent.Red;
                sibling.Red = !sibling.Red;

                if (grandParent != null)
                {
                    if (parentToRight)
                    {
                        RightRotate(ref parent);
                        grandParent.Right = parent;
                    }
                    else if (!parentToRight)
                    {
                        RightRotate(ref parent);
                        grandParent.Left = parent;
                    }
                }
                else
                {
                    RightRotate(ref parent);
                    root = parent;
                }
                grandParent = sibling;
                parent = parent.Right;
                parentToRight = true;
            }

            if (parent.Right == curNode)
            {
                sibling = parent.Left;
                siblingToRight = false;
            }
            else if (parent.Left == curNode)
            {
                sibling = parent.Right;
                siblingToRight = true;
            }

            //check other cases
            Node siblingLeftChild = null;
            Node siblingRightChild = null;
            if (sibling != null && sibling.Left != null)
            {
                siblingLeftChild = sibling.Left;
            }
            if (sibling != null && sibling.Right != null)
            {
                siblingRightChild = sibling.Right;
            }

            bool siblingRed = (sibling != null && sibling.Red);
            bool siblingLeftRed = (siblingLeftChild != null && siblingLeftChild.Red);
            bool siblingRightRed = (siblingRightChild != null && siblingRightChild.Red);

            if (parent.Red && !siblingRed && !siblingLeftRed && !siblingRightRed)
            {
                Case2B(curNode, parent, sibling, grandParent);
            }
            else if (siblingToRight && !siblingRed && siblingLeftRed && !siblingRightRed)
            {
                Case3(curNode, parent, sibling, grandParent);
            }
            else if (siblingToRight && !siblingRed && siblingRightRed)
            {
                Case4(curNode, parent, sibling, grandParent);
            }
            else if (!siblingToRight && !siblingRed && siblingLeftRed)
            {
                Case4P(curNode, parent, sibling, grandParent);
            }

        }

        private void Case2A(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {
            if (sibling != null)
            {
                sibling.Red = !sibling.Red;
            }
            curNode = parent;
            if (curNode != root)
            {
                parent = curNode.Parent;
                GetParentGrandParentSibling(curNode, parent, out sibling, out grandParent);

                //check other cases
                Node siblingLeftChild = null;
                Node siblingRightChild = null;
                if (sibling != null && sibling.Left != null)
                {
                    siblingLeftChild = sibling.Left;
                }
                if (sibling != null && sibling.Right != null)
                {
                    siblingRightChild = sibling.Right;
                }

                bool siblingRed = (sibling != null && sibling.Red);
                bool siblingLeftRed = (siblingLeftChild != null && siblingLeftChild.Red);
                bool siblingRightRed = (siblingRightChild != null && siblingRightChild.Red);

                if (parent != null && !parent.Red && !siblingRed && !siblingLeftRed && !siblingRightRed)
                {
                    Case2A(curNode, parent, sibling, grandParent);
                }
                else if (parent != null && parent.Red && !siblingRed && !siblingLeftRed && !siblingRightRed)
                {
                    Case2B(curNode, parent, sibling, grandParent);
                }
                else if (siblingToRight && !siblingRed && siblingLeftRed && !siblingRightRed)
                {
                    Case3(curNode, parent, sibling, grandParent);
                }
                else if (siblingToRight && !siblingRed && siblingRightRed)
                {
                    Case4(curNode, parent, sibling, grandParent);
                }
                else if (!siblingToRight && !siblingRed && siblingLeftRed)
                {
                    Case4P(curNode, parent, sibling, grandParent);
                }

            }
        }

        private void Case2B(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {
            if (sibling != null)
            {
                sibling.Red = !sibling.Red;
            }
            curNode = parent;
            curNode.Red = !curNode.Red;
        }

        private void Case3(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {
            if (parent.Left == curNode)
            {
                sibling.Red = true;
                sibling.Left.Red = false;
                RightRotate(ref sibling);
                parent.Right = sibling;
            }

            Case4(curNode, parent, sibling, grandParent);
        }

        private void Case3P(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {
            if (parent.Right == curNode)
            {
                sibling.Red = true;
                sibling.Right.Red = false;
                LeftRotate(ref sibling);
                parent.Left = sibling;
            }

            Case4P(curNode, parent, sibling, grandParent);
        }

        private void Case4(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {
            sibling.Red = parent.Red;
            sibling.Right.Red = false;
            parent.Red = false;
            if (grandParent != null)
            {
                if (parentToRight)
                {
                    LeftRotate(ref parent);
                    grandParent.Right = parent;
                }
                else
                {
                    LeftRotate(ref parent);
                    grandParent.Left = parent;
                }
            }
            else
            {
                LeftRotate(ref parent);
                root = parent;
            }
        }

        private void Case4P(Node curNode, Node parent,
            Node sibling, Node grandParent)
        {
            sibling.Red = parent.Red;
            sibling.Left.Red = false;
            parent.Red = false;
            if (grandParent != null)
            {
                if (parentToRight)
                {
                    RightRotate(ref parent);
                    grandParent.Right = parent;
                }
                else
                {
                    RightRotate(ref parent);
                    grandParent.Left = parent;
                }
            }
            else
            {
                RightRotate(ref parent);
                root = parent;
            }
        }
    }
}
