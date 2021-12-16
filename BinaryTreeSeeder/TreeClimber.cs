using BinaryTreeSeeder;

internal class TreeClimber
{
    private List<int> InorderRecursiveNodes = new List<int>();

    private List<int> PostorderRecursiveNodes = new List<int>();

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
}
