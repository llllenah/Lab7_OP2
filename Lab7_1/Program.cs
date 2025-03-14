using System;

namespace ShortLinkedListApp
{
    class Program
    {
        static void Main()
        {
            ShortLinkedList list = new ShortLinkedList();
            Random random = new Random();

            Console.WriteLine("\n===== Creating the List =====");
            Console.WriteLine("Adding predefined elements: 9, 15, 20, 27, 1, 4, 12, 7");

            // Adding predefined elements
            list.AddToStart(9);
            list.AddToStart(15);
            list.AddToStart(20);
            list.AddToStart(27);
            list.AddToStart(1);
            list.AddToStart(4);
            list.AddToStart(12);
            list.AddToStart(7);

            Console.WriteLine("Adding 5 random elements...");
            // Adding random elements
            for (int i = 0; i < 5; i++)
            {
                short randomValue = (short)random.Next(1, 50);
                list.AddToStart(randomValue);
                Console.Write(randomValue + " ");
            }
            Console.WriteLine("\n\n====================");
            Console.WriteLine(" Initial List Elements ");
            Console.WriteLine("====================");
            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine();

            // Test: FindFirstMultipleOf
            Console.WriteLine("\n===== Finding First Multiple of 3 =====");
            short multiple = 3;
            var firstMultiple = list.FindFirstMultipleOf(multiple);
            Console.WriteLine($"First number that is a multiple of {multiple}: {firstMultiple}");

            // Test: ProductOfElementsLessThanAverage
            Console.WriteLine("\n===== Calculating Product of Elements Less Than Average =====");
            var values = list.ToList();
            double average = values.Average(v => (double)v);
            int product = list.ProductOfElementsLessThanAverage();
            Console.WriteLine($"Average: {average:F2}");
            Console.WriteLine($"Product: {product}");

            // Test: GetMultiplesOf
            Console.WriteLine("\n===== Extracting Multiples of 3 =====");
            ShortLinkedList multiplesList = list.GetMultiplesOf(multiple);
            Console.WriteLine("Multiples of " + multiple + ":");
            Console.WriteLine(string.Join(" ", multiplesList));
            Console.WriteLine();

            // Test: RemoveElementsGreaterThanAverage
            Console.WriteLine("\n===== Removing Elements Greater Than Average =====");
            list.RemoveElementsGreaterThanAverage();
            Console.WriteLine("Updated list:");
            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine();

            // Additional Tests
            Console.WriteLine("\n===== Testing with an Empty List =====");
            ShortLinkedList emptyList = new ShortLinkedList();
            Console.WriteLine("Product of elements in empty list: " + emptyList.ProductOfElementsLessThanAverage());
            Console.WriteLine("First multiple of 5 in empty list: " + emptyList.FindFirstMultipleOf(5));

            // Edge case: Single element list
            Console.WriteLine("\n===== Testing with a Single Element List =====");
            ShortLinkedList singleElementList = new ShortLinkedList();
            singleElementList.AddToStart(10);
            Console.WriteLine("List before modification:");
            Console.WriteLine(string.Join(" ", singleElementList));
            singleElementList.RemoveElementsGreaterThanAverage();
            Console.WriteLine("List after removing elements greater than average:");
            Console.WriteLine(string.Join(" ", singleElementList));
            Console.WriteLine();
        }
    }
}