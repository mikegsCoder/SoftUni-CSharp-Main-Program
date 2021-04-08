﻿using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node head;
    private Node tail;
    public LinkedList()
    {
        this.head = null;
        this.tail = null;
        this.Count = 0;
    }
    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node newNode = new Node(item);

        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.Next = this.head;
            this.head = newNode;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node newNode = new Node(item);

        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            this.tail = newNode;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.head.Value;

        if (this.Count == 1)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.head = this.head.Next;
        }

        this.Count--;
        return element;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.tail.Value;

        if (this.Count == 1)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            Node parent = this.head;

            while (parent.Next != this.tail)
            {
                parent = parent.Next;
            }

            parent.Next = null;
            this.tail = parent;
        }

        this.Count--;
        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node start = this.head;

        while (start.Next != null)
        {
            yield return start.Value;
            start = start.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public Node Next { get; set; }
    }
}
