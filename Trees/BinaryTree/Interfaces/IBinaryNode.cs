using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Trees.BinaryTree.Interfaces
{
    public interface IBinaryNode<T> : IEquatable<T> where T : IComparable<T>
    {
        public T Data { get; }

        public IBinaryNode<T> LeftNode { get; set; }

        public IBinaryNode<T> RightNode { get; set; }


        public int CompareTo(T data)
        {
            return Data.CompareTo(data);
        }


        #region Operators

        public static bool operator >(IBinaryNode<T> binaryNode1, IBinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                -1 => false,
                0 => false,
                1 => true,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator <(IBinaryNode<T> binaryNode1, IBinaryNode<T> binaryNode2)
        {
            return binaryNode1.Data.CompareTo(binaryNode2.Data) switch
            {
                -1 => true,
                0 => false,
                1 => false,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator >(IBinaryNode<T> binaryNode1, T data)
        {
            return binaryNode1.Data.CompareTo(data) switch
            {
                -1 => false,
                0 => false,
                1 => true,

                _ => throw new NotImplementedException()
            };
        }

        public static bool operator <(IBinaryNode<T> binaryNode1, T data)
        {
            return binaryNode1.Data.CompareTo(data) switch
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
