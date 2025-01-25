using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Hashtable ht = new Hashtable()
        {
            { "EId", 1001 },
            { "Name", "Don Dai" },
            { "Salary", 3500 },
            { "Location", "Nepal" },
            { "EmailID", "don@dai.com" }
        };

        Hashtable ht2 = (Hashtable)ht.Clone();
        Console.WriteLine("Cloned Hashtable Elements:");
        foreach (DictionaryEntry entry in ht2)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }

        Console.ReadKey();

        //Copying the Hashtable to an object array
        DictionaryEntry[] myArray = new DictionaryEntry[ht.Count];
        ht.CopyTo(myArray, 0);

        Console.WriteLine("\nCopied keys and values");
        foreach (DictionaryEntry item in myArray)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        Console.ReadKey();

        Object[] myObjArrayKey = new Object[ht.Count];
        Object[] myObjArrayValue = new Object[ht.Count];
        Console.WriteLine("\nCopyTo Method to Copy Keys:");
        ht.Keys.CopyTo(myObjArrayKey, 0);
        foreach (var key in myObjArrayKey)
        {
            Console.WriteLine($"{key} ");
        }

        Console.WriteLine("\nCopyTo Method to copy Values:");
        ht.Values.CopyTo(myObjArrayValue, 0);
        foreach (var key in myObjArrayValue)
        {
            Console.WriteLine($"{key}");
        }

        Console.ReadKey();
    }
}