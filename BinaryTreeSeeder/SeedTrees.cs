using BinaryTreeSeeder;

internal class SeedTrees
{
    Random random = new Random();
    private HashSet<int> randNums = new HashSet<int>();

    public SeedTrees(int totalNodeCount)
    {
        var nodesOnLeftCount = random.Next(totalNodeCount);
        int nodeVal;
        do
        {
            nodeVal = random.Next();
        } while (!randNums.Add(nodeVal));

        return new BinaryTree(nodeVal, SeedTrees(nodesOnLeftCount), SeedTrees(totalNodeCount - nodesOnLeftCount));
    }
}