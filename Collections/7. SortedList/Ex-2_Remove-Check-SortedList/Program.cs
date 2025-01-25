using System.Collections;

namespace NonGenericCollections
{
    public class SortedListDemo
    {
        public static void Main(string[] args)
        {
            // Creating sortedList object
            SortedList sortedList = new SortedList();

            //Adding Elements to SortedList using Add
            sortedList.Add("Ind", "India");
            sortedList.Add("USA", "United State of America");
            sortedList.Add("SA", "South Africa");
            sortedList.Add("PAK", "Pakistan");

            //Checking the key using the Contains methid
            Console.WriteLine("Is Ind Key Exists : " + sortedList.Contains("Ind"));
            Console.WriteLine("Is NZ Key Exists : " + sortedList.Contains("NZ"));
            
            //Checking the key using the ContainsKey methid
            Console.WriteLine("Is Ind Key Exists : " + sortedList.ContainsKey("Ind"));
            Console.WriteLine("Is NZ Key Exists : " + sortedList.ContainsKey("NZ"));
            
            //Checking the value using the ContainsValue method
            Console.WriteLine("Is India value Exists : " + sortedList.ContainsValue("India"));
            Console.WriteLine("Is Bangladesh value Exists : " + sortedList.ContainsValue("Bangladesh"));
            
            Console.ReadKey();

            Console.WriteLine("SortedList Elements");
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            //Removing Element from SortedList using Remove() method
            sortedList.Remove("USA");

            // After Remove() method
            Console.WriteLine("\nSortedList Elements After Remove Method");
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // Remove element at index 1 Using RemoveAt() method
            sortedList.RemoveAt(1);
            Console.WriteLine("\nSortedList Elements After RemoveAT Method");
            foreach (DictionaryEntry item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            sortedList.Clear();
            Console.WriteLine($"After Clear Method Total Key-Value Pair Present is : {sortedList.Count} ");
            Console.ReadKey();
        }
    }
}