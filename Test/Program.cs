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
            binaryTree.Add(new BinaryNode<int>(16));
        }
    }
}
