using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Hashtable ht = new Hashtable();
        ht.Add("UserId", 2002);
        ht.Add("Name", "Don Dai");
        ht.Add("Location", "USA");

        Console.WriteLine("Printing Hashtable using Foreach Loop");
        foreach (object o in ht.Keys)
        {
            Console.WriteLine(o + " : " + ht[o]);
        }
        //Or
        //foreach (DictionaryEntry de in hashtable)
        //{
        //    Console.WriteLine($"Key: {de.Key}, Value: {de.Value}");
        //}

        Console.WriteLine("\nPrinting Hashtable using keys");
        Console.WriteLine("Name : " + ht["Name"]);
        Console.WriteLine("Location : " + ht["Location"]);

        Console.ReadKey();

        Hashtable citesHt = new Hashtable()
        {
            {"Nepal", "Kathmandu, Dolakha, Mustang" },
            {"UK", "London, Manchester, Birmingham"}, //Key:UK, Value:London, Manchester, Birmingham
            {"USA", "Chicago, New York, Washington"}, //Key:USA, Value:Chicago, New York, Washington
            {"India", "Mumbai, New Delhi, Pune"}
        };

        Console.WriteLine("\nCreating a Hashtable Using Collection-Initializer\n");
        foreach (DictionaryEntry city in citesHt)
        {
            Console.WriteLine($"Key: {city.Key}, Value: {city.Value}");
        }

        Console.ReadKey();
    }
}