using System;
using System.Collections.Generic;
using BinaryTreeSeeder;

internal class TreePlanter
{

    public List<BinaryTree?> Trees = new List<BinaryTree?>();
    private Random random = new Random(Int32.MaxValue);
    private HashSet<int> randNums = new HashSet<int>();

    /// <summary>
    /// Generates a number of separate trees containing minNumNodes <= NODES < maxNumNodes
    /// </summary>
    /// <param name="numTrees"></param>
    /// <param name="maxNumNodes"></param>
    /// <param name="minNumNodes"></param>
    public TreePlanter(int numTrees, int maxNumNodes = Int32.MaxValue, int minNumNodes = 1)
    {

        for (int i = 0; i < numTrees; i++)
        {
            Trees.Add(PlantTree(maxNumNodes));
            randNums.Clear();
        }
    }

    public BinaryTree? PlantTree(int totalNodeCount)
    {
        if (totalNodeCount <= 0)
        {
            return null;
        }

        int nodeVal;
        do
        {
            nodeVal = random.Next(100);
        } while (!randNums.Add(nodeVal));

        var nodesOnLeftCount = random.Next(--totalNodeCount);

        return new BinaryTree(nodeVal, PlantTree(nodesOnLeftCount), PlantTree(totalNodeCount - nodesOnLeftCount));
    }
}