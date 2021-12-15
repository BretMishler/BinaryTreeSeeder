namespace BinaryTreeSeeder
{
    public class BinaryTree
    {
        public int Value;
        public BinaryTree? Left;
        public BinaryTree? Right;

        public BinaryTree(int val = 0, BinaryTree? left = null, BinaryTree? right = null)
        {
            Value = val;
            Left = left;
            Right = right;
        }
    }
}