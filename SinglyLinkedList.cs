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
        public T RemoveFirst()
        {
            if (IsEmpty()) throw new Exception("Empty List!");

            T data = Head.Data;
            Head = Head.Next;

            size--;
            if(IsEmpty()) Tail = default(Node<T>);

            return data;              
        } 
        public T RemoveLast()
        {
            if (IsEmpty()) throw new Exception("Empty List!");
            if(size == 1 ) return RemoveFirst();
            else{
                T data = Tail.Data;
                Node<T> trav = Head;
                
                for(int i=0; i < size; i++, trav = trav.Next)
                {
                    if(trav.Next.Equals(Tail))
                    {
                        Tail = trav;
                        Tail.Next = default(Node<T>);
                        break;
                    }
                }
                size--;
                return data;              
            }
        }
        private T Remove(Node<T> node) 
        {
            if (node.Next == default(Node<T>)) return RemoveLast();
            if (node == Head) return RemoveFirst();

            T data = node.Data;
            Node<T> trav = Head;
                
            for(int i=0; i < size; i++, trav = trav.Next)
            {
                if(trav.Next.Equals(node))
                {
                    trav.Next = node.Next;
                    
                    break;
                }
            }
            --size;

            //clean up
            node = node.Next = default(Node<T>); 
            return data;
        }
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= size) throw new Exception("Out of range!");
            
            int i  = 0;
            Node<T> trav;
            
            for(i = 0, trav = Head; i != index; i++ )
            {
                trav = trav.Next;
            }
            return Remove(trav);
        }
        public void Clear()
        {
            Node<T> trav = Head;

            while (trav != default(Node<T>))
            {
                Node<T> next = trav.Next;
                trav.Next = default(Node<T>);
                trav = next;
            }
            Head = Tail = default(Node<T>);
            size = 0;
        }
        public bool Contains(Object obj)
        {
            return IndexOf(obj) != -1;
        }
        public int IndexOf(Object obj)
        {
            int i;
            Node<T> trav;
            if(obj ==  default(Node<T>))
            {
                for(i=0,trav = Head; trav != default(Node<T>); i++, trav = trav.Next)
                {
                    if(trav.Data.Equals(default(T)))
                    {
                        Remove(trav);
                        return i;
                    }
                }
            }else
            {
                for(i=0,trav = Head; trav != default(Node<T>); i++, trav = trav.Next)
                {
                    if(trav.Data.Equals(obj))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            Node<T> trav = Head;
            while(trav != default(Node<T>))
            {
                sb.Append(trav.Data + ",");      
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}