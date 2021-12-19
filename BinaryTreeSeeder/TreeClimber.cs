using System;
using System.Collections.Generic;
using BinaryTreeSeeder;

internal class TreeClimber
{
    private List<int> InorderRecursiveNodes = new List<int>();

    private List<int> PostorderRecursiveNodes = new List<int>();

    private Dictionary<int, int> InorderDict = new Dictionary<int, int>();
    private int[] PostOrderArr = new int[] { };
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

    public BinaryTree? BuildTreeFromInorderPostorder_WithSharedDictionary(int[] inorder, int[] postorder)
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

    public BinaryTree? BuildTreeFromInorderPostorder_NoDictionary(int[] inorder, int[] postorder)
    {
        if (inorder == null || postorder == null)
        {
            return null;
        }

        if (inorder.Length == 1)
        {
            return new BinaryTree(inorder[0]);
        }

        int rootIndex = 0;
        int rootVal = postorder[postorder.Length - 1];

        for (int i = 0; i < inorder.Length; i++)
        {
            if (inorder[i] == rootVal)
            {
                rootIndex = i;
                break;
            }
        }

        int[]? inOrderLeft = null;
        int[]? inOrderRight = null;
        int[]? postOrderLeft = null;
        int[]? postOrderRight = null;
        if (inorder[0] != rootVal)
        {
            inOrderLeft = new int[rootIndex];
            Array.Copy(inorder, inOrderLeft, inOrderLeft.Length);
            postOrderLeft = new int[inOrderLeft.Length];
            Array.Copy(postorder, postOrderLeft, postOrderLeft.Length);
        }


        if (inorder[inorder.Length - 1] != rootVal)
        {
            inOrderRight = new int[inorder.Length - 1 - rootIndex];
            Array.Copy(inorder, rootIndex + 1, inOrderRight, 0, inOrderRight.Length);
            postOrderRight = new int[inOrderRight.Length];
            Array.Copy(postorder, postorder.Length - inOrderRight.Length - 1, postOrderRight, 0, postOrderRight.Length);
        }


        return new BinaryTree(rootVal,
            BuildTreeFromInorderPostorder_NoDictionary(inOrderLeft, postOrderLeft),
            BuildTreeFromInorderPostorder_NoDictionary(inOrderRight, postOrderRight));
    }
}
