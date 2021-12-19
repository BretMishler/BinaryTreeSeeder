
using System;
using System.Linq;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        // See https://aka.ms/new-console-template for more information

        var plantedTrees = new TreePlanter(1);

        var traverser = new TreeClimber();

        var inorderResult = traverser.InorderRecursive(plantedTrees.Trees.First());

        var postorderResult = traverser.PostorderRecursive(plantedTrees.Trees.First());

        Stopwatch sw = Stopwatch.StartNew();
        // make function to travere array with inorder and postorder and make tree
        var x = traverser.BuildTreeFromInorderPostorder_WithSharedDictionary(inorderResult.ToArray(), postorderResult.ToArray());

        sw.Stop();
        var xTime = sw.ElapsedMilliseconds;

        sw.Restart();
        var y = traverser.BuildTreeFromInorderPostorder_NoDictionary(inorderResult.ToArray(), postorderResult.ToArray());
        sw.Stop();

        var yTime = sw.ElapsedMilliseconds;
    }
}