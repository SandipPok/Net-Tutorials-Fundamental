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

        string employeeName = (string)ht["Name"];
        int salary = (int)ht["Salary"];

        Console.WriteLine("Before Updating Name and Salary");
        Console.WriteLine($"Employee Name: {employeeName}");
        Console.WriteLine($"Employee Salary: {salary}");

        //Updating the Name and Salary
        ht["Name"] = "No Don";
        ht["Salary"] = 9999;

        Console.WriteLine("\nAfter Updating Name and Salary");
        employeeName = (string)ht["Name"];
        salary = (int)ht["Salary"];
        Console.WriteLine($"Employee Name: {employeeName}");
        Console.WriteLine($"Employee Salary: {salary}");

        Console.ReadKey();
    }
}