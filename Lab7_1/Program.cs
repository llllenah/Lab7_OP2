using System;

namespace ShortLinkedListApp
{
    class Program
    {
        static void Main()
        {
            ShortLinkedList list = new ShortLinkedList();

            list.AddToStart(9);
            list.AddToStart(15);
            list.AddToStart(20);
            list.AddToStart(27);
            list.AddToStart(1);

            Console.WriteLine("List elements:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            short multiple = 3;
            var firstMultiple = list.FindFirstMultipleOf(multiple);
            Console.WriteLine($"First multiple of {multiple}: {firstMultiple}");

            int product = list.ProductOfElementsLessThanAverage();
            Console.WriteLine($"Product of elements less than average: {product}");

            ShortLinkedList multiplesList = list.GetMultiplesOf(multiple);
            Console.WriteLine("List of multiples:");
            foreach (var item in multiplesList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            list.RemoveElementsGreaterThanAverage();
            Console.WriteLine("List after removing elements greater than average:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}