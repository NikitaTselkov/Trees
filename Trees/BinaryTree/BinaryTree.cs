using System;
using Trees.BinaryTree.Interfaces;

namespace Trees.BinaryTree
{
    /// <summary>
    /// Двоичное дерево.
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

        #region Add

        /// <summary>
        /// Добавление нового узла в двоичное дерево.
        /// </summary>
        /// <param name="node"> Новый узел. </param>
        public void Add(IBinaryNode<T> node)
        {
            if (node != null)
            {
                FindNodeAndPerformsAction(node.Data, RootNode, (data, currentNode) =>
                {
                    if (currentNode > data)
                    {
                        currentNode.LeftNode = new BinaryNode<T>(data);
                    }
                    else
                    {
                        currentNode.RightNode = new BinaryNode<T>(data);
                    }
                });
            }
        }

        /// <summary>
        /// Добавление нового узла в двоичное дерево.
        /// </summary>
        /// <param name="data"> Значение нового узла. </param>
        public void Add(T data)
        {
            if (data != null)
            {
                FindNodeAndPerformsAction(data, RootNode, (data, currentNode) =>
                {
                    if (currentNode > data)
                    {
                        currentNode.LeftNode = new BinaryNode<T>(data);
                    }
                    else
                    {
                        currentNode.RightNode = new BinaryNode<T>(data);
                    }
                });
            }
        }

        #endregion

        #region Find

        /// <summary>
        /// Поиск узла в двоичном дереве.
        /// </summary>
        /// <param name="node"> Искомое значение. </param>
        public IBinaryNode<T> FindNode(IBinaryNode<T> node)
        {
            IBinaryNode<T> result = default;

            if (node != null)
            {
                FindNodeAndPerformsAction(node.Data, RootNode, (data, currentNode) =>
                {
                    if (currentNode.Equals(data))
                    {
                        result = currentNode;
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
        /// Поиск узла в двоичном дереве.
        /// </summary>
        /// <param name="data"> Искомое значение. </param>
        public IBinaryNode<T> FindNode(T data)
        {
            IBinaryNode<T> result = default;

            if (data != null)
            {
                FindNodeAndPerformsAction(data, RootNode, (data, currentNode) =>
                {
                    if (currentNode.Equals(data))
                    {
                       result = currentNode;
                    }
                    else
                    {
                        result = null;
                    }
                });
            }

            return result;
        }

        #endregion

        #region Remove

        /// <summary>
        /// Удаление узла.
        /// </summary>
        /// <param name="node">Удаляемое значение.</param>
        public void Remove(IBinaryNode<T> node)
        {
            var data = node.Data;

            if (data != null)
            {
                IBinaryNode<T> parent = default;

                FindNodeAndPerformsAction(data, RootNode, parent, (data, currentNode, parent) =>
                {
                    // если узел существует.
                    if (currentNode.Equals(data))
                    {
                        // если у узла нет подузлов, можно его удалить.
                        if (currentNode.LeftNode == null && currentNode.RightNode == null)
                        {
                            if (parent > currentNode)
                            {
                                parent.LeftNode = null;
                            }
                            else
                            {
                                parent.RightNode = null;
                            }
                        }
                        // если нет левого, то правый ставим на место удаляемого.
                        else if (currentNode.LeftNode == null)
                        {
                            if (parent > currentNode)
                            {
                                parent.LeftNode = currentNode.RightNode;
                            }
                            else
                            {
                                parent.RightNode = currentNode.RightNode;
                            }
                        }
                        // если нет правого, то левый ставим на место удаляемого.
                        else if (currentNode.RightNode == null)
                        {
                            if (parent > currentNode)
                            {
                                parent.LeftNode = currentNode.LeftNode;
                            }
                            else
                            {
                                parent.RightNode = currentNode.LeftNode;
                            }
                        }
                        // если оба дочерних присутствуют, 
                        // то правый становится на место удаляемого,
                        // а левый вставляется в правый.
                        else
                        {
                            IBinaryNode<T> tempNode = currentNode.LeftNode;

                            if (parent > currentNode)
                            {
                                parent.LeftNode = currentNode.RightNode;
                                parent.LeftNode.LeftNode = tempNode;
                            }
                            else
                            {
                                parent.RightNode = currentNode.RightNode;
                                parent.RightNode.LeftNode = tempNode;
                            }
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Удаление узла.
        /// </summary>
        /// <param name="data">Удаляемое значение.</param>
        public void Remove(T data)
        {
            if (data != null)
            {
                IBinaryNode<T> parent = default;

                FindNodeAndPerformsAction(data, RootNode, parent, (data, currentNode, parent) =>
                {
                    // если узел существует.
                    if (currentNode.Equals(data))
                    {
                        // если у узла нет подузлов, можно его удалить.
                        if (currentNode.LeftNode == null && currentNode.RightNode == null)
                        {
                            if (parent > currentNode)
                            {
                                parent.LeftNode = null;
                            }
                            else
                            {
                                parent.RightNode = null;
                            }
                        }
                        // если нет левого, то правый ставим на место удаляемого.
                        else if (currentNode.LeftNode == null)
                        {
                            if (parent > currentNode)
                            {
                                parent.LeftNode = currentNode.RightNode;
                            }
                            else
                            {
                                parent.RightNode = currentNode.RightNode;
                            }
                        }
                        // если нет правого, то левый ставим на место удаляемого.
                        else if (currentNode.RightNode == null)
                        {
                            if (parent > currentNode)
                            {
                                parent.LeftNode = currentNode.LeftNode;
                            }
                            else
                            {
                                parent.RightNode = currentNode.LeftNode;
                            }
                        }
                        // если оба дочерних присутствуют, 
                        // то правый становится на место удаляемого,
                        // а левый вставляется в правый.
                        else
                        {
                            IBinaryNode<T> tempNode = currentNode.LeftNode;

                            if (parent > currentNode)
                            {
                                parent.LeftNode = currentNode.RightNode;
                                parent.LeftNode.LeftNode = tempNode;
                            }
                            else
                            {
                                parent.RightNode = currentNode.RightNode;
                                parent.RightNode.LeftNode = tempNode;
                            }
                        }
                    }
                });
            }
        }

        #endregion

        #region FindNodeAndPerformsAction

        /// <summary>
        /// Находит нужный узел и выполняет действие.
        /// </summary>
        /// <param name="data"> Значение искомого узла. </param>
        /// <param name="currentNode"> Текущий узел. </param>
        /// <param name="action"> Действие. </param>
        /// <returns> Узел. </returns>
        private IBinaryNode<T> FindNodeAndPerformsAction(T data, IBinaryNode<T> currentNode, Action<T, IBinaryNode<T>> action)
        {
            if (currentNode > data)
            {
                if (currentNode.LeftNode == null || currentNode.Data.Equals(data))
                {
                    action(data, currentNode);
                }
                else
                {
                    FindNodeAndPerformsAction(data, currentNode.LeftNode, action);
                }
            }
            else
            {
                if (currentNode.RightNode == null || currentNode.Data.Equals(data))
                {
                    action(data, currentNode);
                }
                else
                {
                    FindNodeAndPerformsAction(data, currentNode.RightNode, action);
                }
            }

            return currentNode;
        }

        /// <summary>
        /// Находит нужный узел и выполняет действие.
        /// </summary>
        /// <param name="data"> Значение искомого узла. </param>
        /// <param name="currentNode"> Текущий узел. </param>
        /// <param name="parentNode"> Родительский узел. </param>
        /// <param name="side"> Положение currentNode относительно parentNode. </param>
        /// <param name="action"> Действие. </param>
        /// <returns> Узел. </returns>
        private IBinaryNode<T> FindNodeAndPerformsAction(T data, IBinaryNode<T> currentNode, IBinaryNode<T> parentNode, Action<T, IBinaryNode<T>, IBinaryNode<T>> action)
        {
            if (currentNode > data)
            {
                if (currentNode.LeftNode == null || currentNode.Data.Equals(data))
                {
                    action(data, currentNode, parentNode);
                }
                else
                {
                    FindNodeAndPerformsAction(data, currentNode.LeftNode, currentNode, action);
                }
            }
            else
            {
                if (currentNode.RightNode == null || currentNode.Data.Equals(data))
                {
                    action(data, currentNode, parentNode);
                }
                else
                {
                    FindNodeAndPerformsAction(data, currentNode.RightNode, currentNode, action);
                }
            }

            return currentNode;
        }

        #endregion
    }
}
