using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Stack<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int length;
        /// <summary>
        /// A reference to the front element in the queue
        /// </summary>
        private Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        /// <summary>
        /// A reference to the back element in the queue
        /// </summary>
        private Node<T> Tail
        {
            get { return tail; }
            set { tail = value; }
        }

        /// <summary>
        /// Keeps track of how many elements are currently in the queue
        /// </summary>
        public int Length
        {
            get { return length; }
        }

        /// <summary>
        /// returns the item on top of the stack
        /// </summary>
        /// <returns></returns>
        public T Top()
        {
            return head.Data;
        }



        /// <summary>
        /// Queue constructor
        /// </summary>
        public Stack(T data)
        {
            head = new Node<T>(data);
            tail = head;
            length = 1;
        }
        public Stack()
        {
            head = null;
            tail = null;
            length = 0;
        }

        /// <summary>
        /// Adds an element to the front of the queue
        /// </summary>
        /// <param name="data">The element to be added</param>
        public void enqueue(T data)
        {
            Node<T> temp = new Node<T>(data);
            if (head == null)
            {
                tail = temp;
                head = tail;
            }
            else
            {
                Node<T> test = tail;
                while (test != head && head != tail)
                {
                    test = test.Next;
                }
                head.Next = temp;
                head = head.Next;


            }
            length++;
        }

        /// <summary>
        /// Removes the front element from the queue
        /// </summary>
        /// <returns>The front element</returns>
        public T dequeue()
        {

            Node<T> temp = new Node<T>();
            temp.Next = tail;
            Node<T> top = head;
             while (temp.Next != head)
            {
                temp = temp.Next;
            }
            head = temp;
            head.Next = null;
            length--;
            if (head == null ||size() <= 1)
                head = tail;
            return top.Data;

        }

        /// <summary>
        /// Indicates how many elements are in the queue
        /// </summary>
        /// <returns>The number of elements currently in the queue</returns>
        public int size()
        {
            return length;
        }

        /// <summary>
        /// Indicates whether the queue is empty or not
        /// </summary>
        /// <returns>True if the queue is empty, false otherwise</returns>
        public bool empty()
        {
            return Length == 0;
        }

        /// <summary>
        /// earse every member of the stack
        /// </summary>
        public void earseData()
        {
            head = null;
            tail = null;
            length = 0;
        }

        /// <summary>
        /// Indicates whether the queue is full or not
        /// </summary>
        /// <returns>True if the queue is full, false otherwise</returns>
        public bool full()
        {
            return false;
        }
    }
}
