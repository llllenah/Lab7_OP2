using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Simple implementation of a singly linked list for short integers.
/// </summary>
public class ShortLinkedList : IEnumerable<short>
{
    /// <summary>
    /// Represents a node in the linked list.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// The value stored in the node.
        /// </summary>
        public short Value;

        /// <summary>
        /// Reference to the next node in the list.
        /// </summary>
        public Node? Next;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class with the specified value.
        /// </summary>
        /// <param name="value">The value to store in the node.</param>
        public Node(short value) => Value = value;
    }

    /// <summary>
    /// Reference to the first node of the list.
    /// </summary>
    private Node? head;

    /// <summary>
    /// Adds an element to the beginning of the list.
    /// </summary>
    /// <param name="value">The value to add.</param>
    public void AddToStart(short value)
    {
        head = new Node(value) { Next = head };
    }

    /// <summary>
    /// Finds the first element in the list that is a multiple of the given number.
    /// </summary>
    /// <param name="multiple">The divisor to check for multiples.</param>
    /// <returns>The first multiple found, or null if none exist.</returns>
    public short? FindFirstMultipleOf(short multiple)
    {
        foreach (var value in this)
        {
            if (value % multiple == 0)
                return value;
        }
        return null;
    }

    /// <summary>
    /// Calculates the product of all elements that are less than the average value.
    /// </summary>
    /// <returns>The product of elements less than the average, or 0 if none exist.</returns>
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

    /// <summary>
    /// Returns a new linked list containing only elements that are multiples of the given value.
    /// </summary>
    /// <param name="multiple">The divisor to filter elements.</param>
    /// <returns>A new linked list containing only elements that are multiples of the given value.</returns>
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

    /// <summary>
    /// Removes all elements greater than the average value from the list.
    /// </summary>
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

    /// <summary>
    /// Returns an enumerator that iterates through the linked list.
    /// </summary>
    /// <returns>An enumerator for the list.</returns>
    public IEnumerator<short> GetEnumerator()
    {
        Node? current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Returns a non-generic enumerator that iterates through the linked list.
    /// </summary>
    /// <returns>A non-generic enumerator for the list.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
