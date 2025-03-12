using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface ILinkedList<T> : IEnumerable<T>
{
    void AddToStart(T value);
    T? FindFirstMultipleOf(T multiple) where T : struct;
    int ProductOfElementsLessThanAverage();
    ILinkedList<T> GetMultiplesOf(T multiple);
    void RemoveElementsGreaterThanAverage();
}

public abstract class LinkedListBase<T> : ILinkedList<T>
    where T : struct
{
    protected class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value) => Value = value;
    }

    protected Node head;

    public virtual void AddToStart(T value)
    {
        Node newNode = new Node(value) { Next = head };
        head = newNode;
    }

    public virtual T? FindFirstMultipleOf(T multiple) where T : struct
    {
        dynamic m = multiple;
        Node current = head;
        while (current != null)
        {
            if ((dynamic)current.Value % m == 0)
                return current.Value;
            current = current.Next;
        }
        return null;
    }

    public virtual int ProductOfElementsLessThanAverage()
    {
        if (head == null) return 0;
        List<T> values = new List<T>();
        Node current = head;
        while (current != null)
        {
            values.Add(current.Value);
            current = current.Next;
        }

        double average = (double)values.Average(x => Convert.ToDouble(x));
        int product = 1;
        bool found = false;

        foreach (var value in values)
        {
            if (Convert.ToDouble(value) < average)
            {
                product *= Convert.ToInt32(value);
                found = true;
            }
        }
        return found ? product : 0;
    }

    public virtual ILinkedList<T> GetMultiplesOf(T multiple)
    {
        LinkedListBase<T> result = CreateNewList();
        dynamic m = multiple;
        Node current = head;
        while (current != null)
        {
            if ((dynamic)current.Value % m == 0)
                result.AddToStart(current.Value);
            current = current.Next;
        }
        return result;
    }

    public virtual void RemoveElementsGreaterThanAverage()
    {
        if (head == null) return;

        List<T> values = new List<T>();
        Node current = head;
        while (current != null)
        {
            values.Add(current.Value);
            current = current.Next;
        }

        double average = (double)values.Average(x => Convert.ToDouble(x));
        Node dummy = new Node(default) { Next = head };
        Node prev = dummy;
        current = head;

        while (current != null)
        {
            if (Convert.ToDouble(current.Value) > average)
                prev.Next = current.Next;
            else
                prev = current;

            current = current.Next;
        }
        head = dummy.Next;
    }

    protected abstract LinkedListBase<T> CreateNewList();

    public virtual IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class ShortLinkedList : LinkedListBase<short>
{
    protected override LinkedListBase<short> CreateNewList() => new ShortLinkedList();
}
