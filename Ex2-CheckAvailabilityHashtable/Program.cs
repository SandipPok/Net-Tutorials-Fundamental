using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        Hashtable ht = new Hashtable();

        ht.Add("UserId", 1001);
        ht.Add("Name", "Don Sir");
        ht.Add("Job", "No Any Job");
        ht.Add("Salary", "Someone please give me");

        //Checking the key using the Contains methid
        Console.WriteLine("Is User Id Exists : " + ht.Contains("UserId"));
        Console.WriteLine("Is EmailId Key Exists : " + ht.Contains("EmailId"));

        //Checking the key using the ContainsKey method Id
        Console.WriteLine("Is Job Key Exists : " + ht.ContainsKey("Job"));

        //Checking the value using the ContainsValue method
        Console.WriteLine("Is Mumbai value Exists : " + ht.ContainsValue("Don Sir"));

        Console.ReadKey();
    }
}