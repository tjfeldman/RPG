using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace RPG
{
    public class List<T> : IEnumerable<T>
    {
        private Node<T> head; 
        private Node<T> tail;

        public List(T data)
        {
            head = new Node<T>(data);
            tail = head;

        }

        public List(List<T> data)
        {
            for (int x = 0; x < data.size(); x++)
                Add(data[x]);
        }

        public List()
        {
            head = null;
            tail = head;
        }

        public T this[int num]
        {
            get { if (num >= size()) { throw new NoTargetException(); } return get(num); }
        }

        public void Add(T data)
        {
            if (size() == 0)
            {
                head = new Node<T>(data);
                tail = head;
            }
            else
            {
                tail.Next = new Node<T>(data);
                tail = tail.Next;
            }
        }
       
        public void Insert(int position, T data)
        {
            Node<T> temp = head;
            if (position != 0)
            {
                for (int x = 1; x < position; x++)
                {
                    temp = temp.Next;
                }
                try
                {
                    Node<T> hold = temp.Next;
                    temp.Next.Data = data;
                    temp.Next.Next = hold;
                }
                catch (Exception)//if object is being inserted at the end of the list, create new object at end of list
                {
                    temp.Next = new Node<T>(data);
                    tail = temp.Next;
                }
            }
            else
            {
                head.Next = new Node<T>(temp.Data, temp.Next);
                head.Data = data;
                
            }

        }

        public bool Remove(T data)
        {
            Node<T> temp = head;
            if (temp != null)
            {
                if (temp.Data.Equals(data))
                {
                    head = head.Next;
                }
                while (temp.Next != null)
                {
                    if (temp.Next.Data.Equals(data))
                    {
                        if (temp.Next.Next == null)
                            tail = temp;
                        temp.Next = temp.Next.Next;
                        return true;
                    }
                    temp = temp.Next;
                }
            }
            return false;
        }

        public int Count
        {
            get { return size(); }
        }

        private int size()
        {
            Node<T> temp = head;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }

        public bool RemoveAt(int position)
        {
            if (position == 0)
            {
                head = head.Next;
                return true;
            }
            else if (position > size())
                return false;
            else
            {
                int count = 1;
                Node<T> temp = head;
                while (count < size())
                {
                    if (count == position)
                    {
                        if (temp.Next.Next == null)
                            tail = temp;
                        temp.Next = temp.Next.Next;
                        return true;
                    }
                    temp = temp.Next;
                    count++;
                }
                return false;
            }
        }

        private T get(int num)
        {
            if (num >= size())
                throw new IndexOutOfRangeException();
            else
            {
                Node<T> temp = head;
                for (int x = 0; x < num; x++)
                    temp = temp.Next;
                return temp.Data;
            }
        }

        public override string ToString()
        {

            string output;
            Node<T> temp = head;
            if (temp != null)
            {
                output = "[" + temp.Data;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                    output = output + "," + temp.Data;

                }
                return output + "]";
            }
            return "[]";
        }
        /// <summary>
        /// Used to allow my ForEach Loops to work with my created list.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = new Node<T>(); 
            temp.Next = head;
            T[] values = new T[size()];
            int count = 0;
            while (temp.Next != null)
            {
                temp = temp.Next;
                values[count] = temp.Data;
                count++;
            }
            for (int x = 0; x < size(); x++)
            {

                yield return values[x];
            }
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
