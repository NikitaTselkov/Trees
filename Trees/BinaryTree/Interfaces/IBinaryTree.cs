using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.BinaryTree.Interfaces
{
    public interface IBinaryTree<T> where T : IComparable<T>
    {
        public IBinaryNode<T> RootNode { get; }
    }
}
