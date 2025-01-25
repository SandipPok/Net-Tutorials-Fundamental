using System.Collections;
using System.Collections.Generic;

namespace NonGenericCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creating sortedList using object Initializer
            SortedList sl = new SortedList()
            {
                { "NP", "Nepal" },
                { "Ind", "India" },
                { "USA", "United State of America" },
                { "SA", "South Africa" },
                { "PAK", "Pakistan" }
            };

            Console.WriteLine("Sorted List Element:");
            foreach (DictionaryEntry de in sl)
            {
                Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
            }

            Console.WriteLine("\nCloned Sorted List Elements:");

            // Creating a clone sortedList using Clone() method
            SortedList slCone = (SortedList)sl.Clone();
            foreach (DictionaryEntry de in slCone)
            {
                Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
            }
            Console.ReadLine();

            DictionaryEntry[] slCopyTo = new DictionaryEntry[sl.Count];
            sl.CopyTo(slCopyTo, 0);

            Console.WriteLine("\nCopyTo Method to Copy Keys and values:");
            for (int i = 0; i < slCopyTo.Length; i++)
            {
                Console.WriteLine($"{slCopyTo[i].Key} : {slCopyTo[i].Value}");
            }

            Object[] myObjArrayKey = new Object[5];
            Object[] myObjArrayValue = new Object[5];

            Console.WriteLine("\nCopyTo Method to Copy Keys:");
            sl.Keys.CopyTo(myObjArrayKey, 0);
            foreach (var key in myObjArrayKey)
            {
                Console.WriteLine($"{key} ");
            }

            Console.WriteLine("\nCopyTo Method to Copy Values:");
            sl.Values.CopyTo(myObjArrayValue, 1);
            foreach (var key in myObjArrayValue)
            {
                Console.WriteLine($"{key} ");
            }
            Console.ReadKey();
        }
    }
}