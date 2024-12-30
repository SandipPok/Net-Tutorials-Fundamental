using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Hashtable ht = new Hashtable();

        ht[1] = "One";
        ht[2] = 213;
        ht[20] = false;

        foreach (DictionaryEntry entry in ht)
        {
            Console.WriteLine($"Key: {entry.Key} and Value: {entry.Value}");
        }

        Console.ReadKey();
    }
}