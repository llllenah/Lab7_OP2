using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// Simple implementation of a singly linked list for short integers.
public class ShortLinkedList : IEnumerable<short>
{
    private class Node
    {
        public short Value;
        public Node? Next;
        public Node(short value) => Value = value;
    }

    private Node? head;

    /// Adds an element to the beginning of the list.
    public void AddToStart(short value)
    {
        head = new Node(value) { Next = head };
    }

    /// Finds the first element that is a multiple of the given number.
    public short? FindFirstMultipleOf(short multiple)
    {
        foreach (var value in this)
        {
            if (value % multiple == 0)
                return value;
        }
        return null;
    }

    /// Calculates the product of elements that are less than the average value.
    public int ProductOfElementsLessThanAverage()
    {
        List<short> values = this.ToList();
        if (values.Count == 0) return 0;

        double avg = values.Average(v => (double)v);
        int product = 1;
        bool found = false;

        foreach (var value in values)
        {
            if (value < avg)
            {
                product *= value;
                found = true;
            }
        }
        return found ? product : 0;
    }

    /// Returns a new linked list containing only elements that are multiples of the given value.
    public ShortLinkedList GetMultiplesOf(short multiple)
    {
        ShortLinkedList result = new ShortLinkedList();
        foreach (var value in this)
        {
            if (value % multiple == 0)
                result.AddToStart(value);
        }
        return result;
    }

    /// Removes all elements greater than the average value.
    public void RemoveElementsGreaterThanAverage()
    {
        List<short> values = this.ToList();
        if (values.Count == 0) return;

        double avg = values.Average(v => (double)v);
        head = null;
        for (int i = values.Count - 1; i >= 0; i--)
        {
            if (values[i] <= avg)
                AddToStart(values[i]);
        }
    }

    /// Allows enumeration over the elements of the list.
    public IEnumerator<short> GetEnumerator()
    {
        Node? current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}