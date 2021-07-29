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
                FindNodeAndPerformsAction(node.Data, RootNode, (data, parent) =>
                {
                    if (parent > data)
                    {
                        parent.LeftNode = new BinaryNode<T>(data);
                    }
                    else
                    {
                        parent.RightNode = new BinaryNode<T>(data);
                    }
                });
            }
        }

        /// <summary>
        /// Поиск узла в бинарном дереве.
        /// </summary>
        /// <param name="data"> Искомое значение. </param>
        public IBinaryNode<T> FindNode(T data)
        {
            IBinaryNode<T> result = default;

            if (data != null)
            {
                FindNodeAndPerformsAction(data, RootNode, (data, parent) =>
                {
                    if (parent.Equals(data))
                    {
                       result = parent;
                    }
                    else
                    {
                        result = null;
                    }
                });
            }

            return result;
        }

        /// <summary>
        /// Находит нужный узел и выполняет действие.
        /// </summary>
        /// <param name="data"> Значение искомого узла. </param>
        /// <param name="parent"> Родительский узел. </param>
        /// <param name="action"> Действие. </param>
        /// <returns> Узел. </returns>
        private IBinaryNode<T> FindNodeAndPerformsAction(T data, IBinaryNode<T> parent, Action<T, IBinaryNode<T>> action)
        {
            if (parent > data)
            {
                if (parent.LeftNode == null || parent.Data.Equals(data))
                {
                    action(data, parent);
                }
                else
                {
                    FindNodeAndPerformsAction(data, parent.LeftNode, action);
                }
            }
            else
            {
                if (parent.RightNode == null || parent.Data.Equals(data))
                {
                    action(data, parent);
                }
                else
                {
                    FindNodeAndPerformsAction(data, parent.RightNode, action);
                }
            }

            return parent;
        }
    }
}
