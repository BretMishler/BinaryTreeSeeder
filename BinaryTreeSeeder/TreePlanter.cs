using System;
using System.Collections.Generic;
using BinaryTreeSeeder;

internal class TreePlanter
{

    public BinaryTree? Tree;
    private Random random = new Random(Int32.MaxValue);
    private HashSet<int> randNums = new HashSet<int>();

    public TreePlanter(int numTrees)
    {
        Tree = PlantTrees(numTrees);
    }

    public BinaryTree? PlantTrees(int totalTreeCount)
    {
        if (totalTreeCount <= 0)
        {
            return null;
        }

        int nodeVal;
        do
        {
            nodeVal = random.Next();
        } while (!randNums.Add(nodeVal));

        var nodesOnLeftCount = random.Next(--totalTreeCount);

        return new BinaryTree(nodeVal, PlantTrees(nodesOnLeftCount), PlantTrees(totalTreeCount - nodesOnLeftCount));
    }
}