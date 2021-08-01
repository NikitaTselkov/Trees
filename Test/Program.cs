using System;
using Trees.BinaryTree;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryNode = new BinaryNode<int>(5);

            BinaryTree<int> binaryTree = new BinaryTree<int>(binaryNode);

            binaryTree.Add(new BinaryNode<int>(15));
            binaryTree.Add(new BinaryNode<int>(-15));
            binaryTree.Add(-14);
            binaryTree.Add(-16);

            var node1 = binaryTree.FindNode(new BinaryNode<int>(16));
            var node2 = binaryTree.FindNode(17);
            binaryTree.Remove(-15);
            binaryTree.Remove(-14);
        }
    }
}
