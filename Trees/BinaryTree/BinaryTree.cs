using System;
using Trees.BinaryTree.Interfaces;

namespace Trees.BinaryTree
{
    /// <summary>
    /// Бинарное дерево.
    /// </summary>
    public sealed class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Корень дерева.
        /// </summary>
        public IBinaryNode<T> RootNode { get; private set; }


        public BinaryTree(IBinaryNode<T> rootNode)
        {
            RootNode = rootNode;
        }


        /// <summary>
        /// Добавление нового узла в бинарное дерево.
        /// </summary>
        /// <param name="node"> Новый узел. </param>
        public void Add(IBinaryNode<T> node)
        {
            if (node != null)
            {
               Insert(node, RootNode);
            }
        }

        /// <summary>
        /// Вставляет ноду.
        /// </summary>
        private IBinaryNode<T> Insert(IBinaryNode<T> node, IBinaryNode<T> parent)
        {
            if (parent > node)
            {
                if (parent.LeftNode == null)
                {
                    parent.LeftNode = node;
                }
                else
                {
                    Insert(node, parent.LeftNode);
                }
            }
            else
            {
                if (parent.RightNode == null)
                {
                    parent.RightNode = node;
                }
                else
                {
                    Insert(node, parent.RightNode);
                }
            }

            return parent;
        }
    }
}
