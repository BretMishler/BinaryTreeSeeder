
class Program
{
    static void Main(string[] args)
    {

        // See https://aka.ms/new-console-template for more information

        var plantedTrees = new TreePlanter(1, 8);

        var traverser = new TreeClimber();

        // make an in-order traversal algo
        var inorderResult = traverser.InorderRecursive(plantedTrees.Trees.First());

        // make a post-order traversal algo
        var postorderResult = traverser.PostorderRecursive(plantedTrees.Trees.First());
        Console.WriteLine("Hello, World!");
    }
}