using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Node<T>
    {
        private T data;
        private Node<T> next;
        private int prioty = 0;
        public Node()
        {

        }

        public Node(T data)
        {
            this.data = data;
        }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public Node(T data, int prioty)
        {
            this.data = data;
            this.prioty = prioty;
        }

        public Node(T data, int prioty, Node<T> next)
        {
            this.data = data;
            this.prioty = prioty;
            this.next = next;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public int importance
        {
            get { return prioty; }
            set { prioty = value; }
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
