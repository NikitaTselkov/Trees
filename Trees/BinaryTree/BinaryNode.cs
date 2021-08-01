using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Trees.BinaryTree.Interfaces;

namespace Trees.BinaryTree
{
    /// <summary>
    /// Нода бинарного дерева.
    /// </summary>
    [DebuggerDisplay("Data = {Data}")]
    public sealed class BinaryNode<T> : IBinaryNode<T> where T : IComparable<T>
    {
        public T Data { get; private set; }

        public IBinaryNode<T> LeftNode { get; set; }

        public IBinaryNode<T> RightNode { get; set; }


        public BinaryNode(T data)
        {
            Data = data;
        }

        public bool Equals([AllowNull] T data1)
        {
            return EqualityComparer<T>.Default.Equals(Data, data1);
        }

        #region operators

        public static bool operator >(IBinaryNode<T> binaryNode1, BinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                 -1 => false,
                 0 => false,
                 1 => true,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator <(IBinaryNode<T> binaryNode1, BinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                -1 => true,
                0 => false,
                1 => false,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator >(BinaryNode<T> binaryNode1, T data)
        {
            return binaryNode1.Data.CompareTo(data) switch
            {
                -1 => false,
                0 => false,
                1 => true,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator <(BinaryNode<T> binaryNode1, T data)
        {
            return binaryNode1.Data.CompareTo(data) switch
            {
                -1 => true,
                0 => false,
                1 => false,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator >(T data, BinaryNode<T> binaryNode2)
        {
            return data.CompareTo(binaryNode2.Data) switch
            {
                -1 => false,
                0 => false,
                1 => true,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator <(T data, BinaryNode<T> binaryNode2)
        {
            return data.CompareTo(binaryNode2.Data) switch
            {
                -1 => true,
                0 => false,
                1 => false,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator >(BinaryNode<T> binaryNode1, IBinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                -1 => false,
                0 => false,
                1 => true,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator <(BinaryNode<T> binaryNode1, IBinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                -1 => true,
                0 => false,
                1 => false,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator >(BinaryNode<T> binaryNode1, BinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                -1 => false,
                0 => false,
                1 => true,

                _ => throw new NotImplementedException()
            };
        }
        
        public static bool operator <(BinaryNode<T> binaryNode1, BinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                -1 => true,
                0 => false,
                1 => false,

                _ => throw new NotImplementedException()
            };
        }

        #endregion
    }
}
