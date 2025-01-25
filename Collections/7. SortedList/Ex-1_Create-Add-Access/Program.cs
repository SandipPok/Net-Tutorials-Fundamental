using System.Collections;

namespace NonGenericSortedList
{
    public class SortedListDemo
    {
        public static void Main(string[] args)
        {
            SortedList sortedList = new SortedList();

            sortedList.Add(1, "One");
            sortedList.Add(5, "Five");
            sortedList.Add(4, "Four");
            sortedList.Add(2, "Two");
            sortedList.Add(3, "Three");

            // Accessing the elements of the sorted list
            Console.WriteLine("Accessing sortedList using for loop");
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine($"Key: {sortedList.GetKey(i)}, Value: {sortedList.GetByIndex(i)}");
            }

            Console.WriteLine("\nAccessing sorted list using forEach loop");
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            Console.WriteLine("\nAccessing SortedList using Keys");
            Console.WriteLine($"Key: 1, Value: {sortedList[1]}");
            Console.WriteLine($"Key: 2, Value: {sortedList[2]}");
            Console.WriteLine($"Key: 3, Value: {sortedList[3]}");
            Console.WriteLine("\nAccessing SortedList using Index");
            Console.WriteLine($"Key: 1, Index: 0, Value: {sortedList.GetByIndex(0)}");
            Console.WriteLine($"Key: 2, Index: 1, Value: {sortedList.GetByIndex(1)}");
            Console.WriteLine($"Key: 3, Index: 2, Value: {sortedList.GetByIndex(2)}");
            Console.ReadKey();

            // Creating sortedList using object Initializer
            SortedList sortedList1 = new SortedList()
            {
                { "Ind", "India" },
                { "USA", "United State of America" },
                { "SA", "South Africa" },
                { "PAK", "Pakistan" }
            };

            Console.WriteLine("SortedList Elements");
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
            Console.ReadKey();
        }
    }
}