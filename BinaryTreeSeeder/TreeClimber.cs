using System;
using System.Collections.Generic;
using BinaryTreeSeeder;

internal class TreeClimber
{
    private List<int> InorderRecursiveNodes = new List<int>();

    private List<int> PostorderRecursiveNodes = new List<int>();

    private Dictionary<int, int> InorderDict = new Dictionary<int, int>();
    private int[] PostOrderArr;
    private int PostOrderIndex;

    /// <summary>
    /// Recursively traverses the tree in-order.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> InorderRecursive(BinaryTree? root)
    {
        if (root == null)
        {
            return new List<int>();
        }

        if (root.Left != null)
        {
            InorderRecursive(root.Left);
        }

        InorderRecursiveNodes.Add(root.Value);

        if (root.Right != null)
        {
            InorderRecursive(root.Right);
        }

        return InorderRecursiveNodes;
    }

    /// <summary>
    /// Recurisely traverses the tree post-order.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> PostorderRecursive(BinaryTree? root)
    {
        if (root == null)
        {
            return new List<int>();
        }

        if (root.Left != null)
        {
            PostorderRecursive(root.Left);
        }

        if (root.Right != null)
        {
            PostorderRecursive(root.Right);
        }

        PostorderRecursiveNodes.Add(root.Value);

        return PostorderRecursiveNodes;
    }

    public BinaryTree? BuildTreeFromInorderPostorder(int[] inorder, int[] postorder)
    {
        if (inorder == null || postorder == null || inorder.Length == 0)
        {
            return null;
        }

        if (inorder.Length != postorder.Length)
        {
            throw new ArgumentException("Inorder and Postorder arrays must have the same length");
        }

        if (inorder.Length == 1)
        {
            return new BinaryTree(inorder[0]);
        }

        InorderDict.Clear();

        for (int i = 0; i < inorder.Length; i++)
        {
            if(!InorderDict.TryAdd(inorder[i], i))
            {
                throw new Exception("Repeated node values found in tree");
            }
        }

        PostOrderArr = new int[postorder.Length];
        PostOrderIndex = postorder.Length - 1;

        Array.Copy(postorder, PostOrderArr, PostOrderArr.Length);

        return BuildTreeFromPostOrder(0, postorder.Length - 1);
    }

    private BinaryTree? BuildTreeFromPostOrder(int start, int stop)
    {
        if (start > stop)
        {
            return null;
        }
        var node = new BinaryTree(PostOrderArr[PostOrderIndex]);
        var nodeInOrderIndex = InorderDict[PostOrderArr[PostOrderIndex]];

        PostOrderIndex--;

        node.Right = BuildTreeFromPostOrder(nodeInOrderIndex + 1, stop);
        node.Left = BuildTreeFromPostOrder(start, nodeInOrderIndex - 1);

        return node;
    }
}
