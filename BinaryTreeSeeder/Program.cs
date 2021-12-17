
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        // See https://aka.ms/new-console-template for more information

        var plantedTrees = new TreePlanter(1, 8);

        var traverser = new TreeClimber();

        var inorderResult = traverser.InorderRecursive(plantedTrees.Trees.First());

        var postorderResult = traverser.PostorderRecursive(plantedTrees.Trees.First());

        // make function to travere array with inorder and postorder and make tree
        var x = traverser.BuildTreeFromInorderPostorder(inorderResult.ToArray(), postorderResult.ToArray());
        
    }
}