using System;
using System.Text;

namespace DataStructures
{
    class SinglyLinkedList<T>
    {
        Node<T> Head = default(Node<T>);
        Node<T> Tail = default(Node<T>);
        int size = 0;
        class Node<T>
        {
            public Node(Node<T> next, T data)
            {
                this.Data = data;
                this.Next = next;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
            public T Data;
            public Node<T> Next;
        }

        public int Size
        {
            get {
                return size;
            }
        }         

        public bool IsEmpty() {return size == 0; }
        
        public void Add(T elem)
        {
            AddLast(elem);
        }
        public void AddLast(T elem)
        {
            if(IsEmpty()) Head = Tail = new Node<T>(default(Node<T>), elem);
            else{   
                Tail.Next = new Node<T>(default(Node<T>), elem);
                Tail = Tail.Next;
            }
            size++;
        }
        public void AddFirst(T elem)
        {
            if(IsEmpty()) Head = Tail = new Node<T>(default(Node<T>), elem);
            else{
                Node<T> newHead = new Node<T>(Head, elem );
                Head = newHead;
            }
            size++;
        }
        public T PeekFirst()
        {
            if (IsEmpty()) throw new Exception("Empty List!");
            return Head.Data;
        }
        public T PeekLast()
        {
            if (IsEmpty()) throw new Exception("Empty List!");
            return Tail.Data;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= size ) throw new Exception("Out of range!");
            
            Node<T> trav = Head;
            T data = default(T);
            
            for (int i = 0; i < size; trav = trav.Next, i++ )
            {
                if(i == index) { data = trav.Data; break;}
            
            }
            
            return data;
        }
        
        public void Set( int index, T elem)
        {
            if (index < 0 || index >= size ) throw new Exception("Out of range!");

            Node<T> trav = Head;
            
            for (int i = 0; i < size; trav = trav.Next, i++ )
            {
                if(i == index) { trav.Data = elem; break;}
            
            }
        }
        /*
            clear
            remove
            removefirst
            removelast
            removeat
            contains
            indexof
            tostring
        */
    }
}