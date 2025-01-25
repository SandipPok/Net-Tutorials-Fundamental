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

        //Count Property returns the number of elements present in the collection
        Console.WriteLine($"Hashtable Total Elements: {ht.Count}");

        //Remove EID
        ht.Remove("EId");
        Console.WriteLine($"After removing EID Total Elements: {ht.Count}");

        //Following statement throws run-time exception: KeyNotFoundException
        //employee.Remove("City"); 

        //Check key before removing it
        if (ht.ContainsKey("City"))
        {
            ht.Remove("City");
        }
        else
        {
            Console.WriteLine("Hashtable doesn't contain City key");
        }

        //Removes all element
        ht.Clear();
        Console.WriteLine($"After Clearing Hashtable Total Elements: {ht.Count}");

        Console.ReadKey();
    }
}