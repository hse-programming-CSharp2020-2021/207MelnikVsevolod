using System;
using System.Collections.Generic;

namespace Task_3
{
    namespace A
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
            }
            public override string ToString()
            {
                return $"{Data}";
            }
        }

        class LinkedList
        {
            Node head;
            Node tail;

            public int Count { get; set; }

            public void Add(int data)
            {
                Node node = new Node(data);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
                Count++;
            }
            public void AddFirst(int data)
            {
                Node node = new Node(data);

                node.Next = head;
                head = node;

                if (Count == 0)
                    tail = head;

                Count++;
            }
            public void Clear()
            {
                Count = 0;
                head = null;
                tail = null;
            }
            public bool Contains(int data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public void Print()
            {
                Node current = head;
                int i = 1;
                while (current != null)
                {
                    Console.WriteLine($"{i} - {current}");
                    current = current.Next;
                    i++;
                }
            }

            public Node Max()
            {
                Node current = head;
                Node max = head;
                while (current != null)
                {
                    if (current.Data > max.Data)
                        max = current;
                    current = current.Next;
                }
                return max;
            }

            public Node Min()
            {
                Node current = head;
                Node min = head;
                while (current != null)
                {
                    if (current.Data < min.Data)
                        min = current;
                    current = current.Next;
                }
                return min;
            }

            public Node Middle()
            {
                // 1 2 3 4 5 6 7 -> 4
                // 1 2 3 4 5 6 -> 4
                Node current = head;
                Node mid = head;
                int step = 0;

                while (current != null)
                {
                    ++step;
                    if (step % 2 == 1)
                        mid = mid.Next;
                    current = current.Next;
                }

                return mid;
            }

            public bool Remove(int data)
            {
                // 1 2 3 4 5 6 7 8 5, 5 -> 1 2 3 4 6 7 8 5
                // если список пуст, если список из 1 элемента, если удаляемый элемент стоит в середине, в конце, в начале
                if (head == null)
                    return false;
                if (head.Data == data)
                {
                    head = head.Next;
                    return true;
                }
                Node current = head;
                if (tail.Data == data)
                {
                    current = head;
                    while (current.Next != tail)
                        current = current.Next;
                    tail = current;
                    return true;
                }
                if (head == tail)
                    return false;

                while (current.Next != null)
                {
                    if (current.Next.Data == data)
                    {
                        current.Next = current.Next.Next;
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }

            public void Reverse()
            {
                Node current = head;
                Node next = head.Next;
                Node prev = null;
                while (current != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }
                head = prev;
            }
        }

        class MainClass
        {
            public static void Main()
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.AddFirst(3);
                linkedList.Add(4);
                linkedList.Print();
                linkedList.Reverse();
                linkedList.Print();
            }
        }
    }
}