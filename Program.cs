using System;
using System.Text;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class DynamicArray<T>
    {
        private T[] Arr;
        private int length = 0; //user thinks length
        private int capacity = 0; //actual capacity

        //public DynamicArray() { this(16); }
        public DynamicArray(int capacity=16)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException($"Illegal Capacity: {capacity}", "capacity");

            this.capacity = capacity;
            Arr = new T[capacity];
        }

        public int Size() { return length; }
        public bool IsEmpty() { return Size() == 0; }
        public T Get(int index) { return Arr[index]; }
        public void Set (int index, T elem) { Arr[index] = elem; }
        public void Clear()
        {
            for (int i = 0; i < capacity; i++)
                Arr[i] = default(T);

            length = 0;
        }
        public void Add(T elem)
        {
            //Resize
            if(length+1 >= capacity)
            {
                if (capacity == 0) capacity = 1;
                else capacity *= 2; // double the size. 

                T[] new_arr = new T[capacity];
                for (int i = 0; i < length; i++)
                    new_arr[i] = Arr[i];
                Arr = new_arr; // Has extra nulls padded.
            }
            Arr[length++] = elem;
        }
        public T RemoveAt (int rm_index)
        {
            if (rm_index >= length || rm_index < 0) throw new IndexOutOfRangeException();
            T data = Arr[rm_index];
            T[] new_arr = new T[length - 1];
            for (int i = 0, j = 0; i < length; i++, j++)
                if (i == rm_index) j--; // Skip over the index by fixing j temporarily
                else new_arr[j] = Arr[i];
            Arr = new_arr;
            capacity = --length;
            return data;
        }

        public bool Remove (T elem)
        {
            for (int i = 0; i < length; i++)
            {
                if (Arr[i].Equals(elem))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T elem)
        {
            for (int i = 0; i < length; i++)
                if (Arr[i].Equals(elem)) return i;
            
            return -1;
        }
        public bool Contains(T elem)
        {
            return IndexOf(elem) != -1;
        }
        public override string ToString()
        {
            if (length == 0) return "[]";
            else
            {
                StringBuilder sb = new StringBuilder(length).Append("[");
                for (int i = 0; i < length - 1; i++)
                    sb.Append($"{Arr[i]}, ");
                return sb.Append(Arr[length-1] + "]").ToString();
            }
        } 
    }
    public class DoublyLinkedList<T>
    {
        private int size = 0;
        private Node<T> Head = default(Node<T>);
        private Node<T> Tail = default(Node<T>);
        private class Node<T>
        {
            public T Data;
            public Node<T> Next;
            public Node<T> Prev;
            public override string ToString()
            {
                return Data.ToString();
            }
            public Node(T data, Node<T> prev, Node<T> next)
            {
                this.Data = data;
                this.Prev = prev;
                this.Next = next;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
        }
        public bool IsEmpty() { return Size == 0; }

        public void Clear()
        {
            Node<T> trav = Head;
            while(trav != default(Node<T>))
            {
                Node<T> next = trav.Next;
                trav.Next = trav.Prev = default(Node<T>);
                trav.Data = default(T);
                trav = next;
            }
            Head = Tail = default(Node<T>);
            size = 0;
        }
        public void Add(T elem)
        {
            AddLast(elem);
        }
        public void AddFirst(T elem)
        {
            if (size == 0) Head = Tail = new Node<T>(elem, default(Node<T>), default(Node<T>));
            else
            {
                Head.Prev = new Node<T>(elem, default(Node<T>), Head);
                Head = Head.Prev;
            }
            size++;
        }
        public void AddLast(T elem)
        {
            if (size == 0) Head = Tail = new Node<T>(elem, default(Node<T>), default(Node<T>));
            else
            {
                Tail.Next = new Node<T>(elem, Tail, default(Node<T>));
                Tail = Tail.Next;
            }
            size++;
        }
        public T PeekFirst()
        {
            if (size == 0) throw new Exception("Empty List");
            else return Head.Data;
        }
        public T PeekLast()
        {
            if (size == 0) throw new Exception("Empty List");
            else return Tail.Data;
        }
        public T RemoveFirst()
        {
            if (size == 0) throw new Exception("Empty List");
             
            T Data = Head.Data;
            Head = Head.Next;
            --size;

            if(IsEmpty()) Tail = default(Node<T>); 
            
            else Head.Prev = default(Node<T>); 
            
            return Data;
        }
        public T RemoveLast()
        {
            if (size == 0) throw new Exception("Empty List");

            T Data = Tail.Data;
            Tail = Tail.Prev;
            --size;

            if(IsEmpty()) Head= default(Node<T>);

            else Tail.Next = default(Node<T>);

            return Data;
        }
        //    get
        public T Get (int index)
        {
            if (index < 0 || index >= size) throw new Exception("Out of range!");
            int i = 0;
     
            T data = default(T);
            Node<T> trav = Head;
     
            for (; i< size; i++, trav = trav.Next)
                if(i == index) data = trav.Data; 

            return data;
        }
        //    set
        public void Set (int index, T data)
        {
            if (index < 0 || index >= size) throw new Exception("Out of range!");
     
            int i = 0;
            Node<T> trav = Head;
     
            for (; i< size; i++, trav = trav.Next)
                if(i == index)
                {
                    trav.Data = data;
                    break;
                }  
        }
        //    remove
        private T Remove (Node<T> node)
        {
            if (node.Prev == default(Node<T>)) return RemoveFirst();
            if (node.Next == default(Node<T>)) return RemoveLast();
            
            T data = node.Data;
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            --size;

            node = node.Prev = node.Next = default(Node<T>);
            node.Data= default(T);

            return data;
        }
        //removeAT
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= size) throw new Exception("Out of range!");
     
            int i= 0;
            Node<T> trav;
            if(i < size/2)
            {
                for (i =0, trav = Head;  i != index; i++ )
                    trav = trav.Next;
            }
            else{
                for (i = size-1, trav= Tail;  i != index; i--)
                    trav = trav.Prev;
            }
            return Remove(trav);
        }
        //    remove
        public bool Remove(Object obj)
        {
            Node<T> trav;
            if(obj == default(Object))
            {
                for (trav = Head;  trav != default(Node<T>); trav=trav.Next )
                    if(trav.Data.Equals(default(T))) 
                    {
                        Remove(trav);
                        return true;
                    }
            }
            else{
                for (trav = Head;  trav != default(Node<T>); trav=trav.Next )
                    if(trav.Data.Equals(obj)) 
                    {
                        Remove(trav);
                        return true;
                    }
            }
            return false;
        }
        //    indexof
        public int IndexOf(Object obj)
        {
            int i;
            Node<T> trav;
            if(obj == default(Node<T>))
            {
                for (i = 0, trav = Head;  trav != default(Node<T>); i++, trav=trav.Next )
                    if(trav.Data.Equals(default(T))) 
                    {
                        Remove(trav);
                        return i;
                    }
            }
            else{
                for (i=0, trav = Head;  trav != default(Node<T>); i++, trav=trav.Next )
                    if(trav.Data.Equals(obj)) 
                    {
                        return i;
                    }
            }
            return -1;
        }
        //    contains
        public bool Contains(Object obj)
        {
            return IndexOf(obj) != -1;
        }

        public override string ToString()
        {
            StringBuilder sb =new StringBuilder();
            sb.Append("[");
            Node<T> trav = Head;
            while(trav != default(Node<T>) ){
                sb.Append(trav.Data + ", ");
        }
            sb.Append("]");
        
            return sb.ToString();
        }
        
    }
}
