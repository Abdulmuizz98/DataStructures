using System;
using System.Text;

namespace DataStructures
{
    class SinglyLinkedList<T>
    {
        Node<T> Head = default(Node<T>);
        Node<T> Tail = default(Node<T>);
        int size = 0;
        public class Node<T>
        {
            public Node(Node<T> next, Node<T> prev, T data)
            {
                this.Data = data;
                this.Next = next;
                this.Prev = prev;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
            T Data;
            Node<T> Next;
            Node<T> Prev;
        }

    }
}