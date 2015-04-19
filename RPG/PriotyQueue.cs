using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class PriotyQueue<T>
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

        public T peek()
        {
            return head.Data;
        }

        /// <summary>
        /// Queue constructor
        /// </summary>
        public PriotyQueue(T data, int prioty)
        {
            head = new Node<T>(data, prioty);
            tail = head;
            length = 1;
        }
        public PriotyQueue()
        {
            head = null;
            tail = null;
            length = 0;
        }

        public int getTopPrioty()
        {
            return head.importance;
        }

        /// <summary>
        /// Adds an element to the back of the queue
        /// </summary>
        /// <param name="data">The element to be added</param>
        public void enqueue(T data, int prioty)
        {
            if (head == null)
            {
                Node<T> temp = new Node<T>(data, prioty);
                head = temp;
                tail = head;
            }
            else
            {
                Node<T> check = head;
                if (check.importance < prioty)
                {
                    head.Next = new Node<T>(head.Data, head.importance, head.Next);
                    head = new Node<T>(data, prioty, head.Next);
                    head.importance = prioty;
                }
                else
                {
                    bool added = false;
                    while (check.Next != null && !added)
                    {

                        if (check.Next.importance < prioty)
                        {
                            Node<T> save = check.Next;
                            check.Next = new Node<T>(data, prioty, save);
                            added = true;
                        }
                        check = check.Next;
                    }
                    if (!added)
                    {
                        tail.Next = new Node<T>(data, prioty);
                    }
                }
            }
            while (tail.Next != null)
                tail = tail.Next;
            length++;
        }

        /// <summary>
        /// Removes the front element from the queue
        /// </summary>
        /// <returns>The front element</returns>
        public T dequeue()
        {
            Node<T> temp = head;
            head = head.Next;
            length--;
            return temp.Data;
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
        /// returns true if there is nothing in the queue
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return (head == null);
        }

        public void Empty()
        {
            head = null;
            tail = head;
        }
    }
}
