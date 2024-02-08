using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_LinkedList_Singly_DanielMinty
{
    internal class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private int count;

        public int Count { get; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                LinkedListNode<T> current = head;

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current.Value;
            }
        }

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public void Add(T value)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(value);
            }
            else
            {
                LinkedListNode<T> current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new LinkedListNode<T>(value);
            }

            count++;
        }

        public void Display()
        {
            LinkedListNode<T> current = head;

            while (current != null)
            {
                Console.Write($"{current.Value}, ");

                current = current.Next;
            }

            Console.WriteLine($"Count:{count}");
        }

        public bool Remove(T value)
        {
            if (head == null)
            {
                return false;
            }

            if (head.Value.Equals(value))
            {
                head = head.Next;
                count--;
                return true;
            }
            
            LinkedListNode<T> current = head;

            while (current.Next != null)
            {
                if (current.Next.Value.Equals(value))
                {
                    current.Next = current.Next.Next;
                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void InsertAtIndex(int index, T value)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0)
            {
                LinkedListNode<T> oldHead = head;
                head = new LinkedListNode<T>(value);
                head.Next = oldHead;
                count++;
            }
            else
            {
                LinkedListNode<T> current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                LinkedListNode<T> oldNode = current.Next;
                current.Next = new LinkedListNode<T>(value);
                current.Next.Next = oldNode;
                count++;
            }
        }

        public void InsertAtFront(T value)
        {
            LinkedListNode<T> oldHead = head;
            head = new LinkedListNode<T>(value);
            head.Next = oldHead;
            count++;
        }

        public void InsertAtEnd(T value)
        {
            this.Add(value);
        }

        public void RemoveAtFront()
        {
            if (head != null)
            {
                head = head.Next;
                count--;
            }
        }

        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index > count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                head = head.Next;
                count--;
            }
            else
            {
                LinkedListNode<T> current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
                count--;
            }
        }

        public void RemoveAtEnd()
        {
            if (head == null)
            {
                return;
            }

            if (head.Next == null)
            {
                head = null;
                count--;
            }
            else
            {
                LinkedListNode<T> current = head;

                for (int i = 0; i < count - 2; i++)
                {
                    current = current.Next;
                }

                current.Next = null;
                count--;
            }
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        class LinkedListNode<T>
        {
            public T Value { get; set; }
            public LinkedListNode<T> Next { get; set; }

            public LinkedListNode(T value)
            {
                this.Value = value;
                this.Next = null;
            }
        }
    }
}
