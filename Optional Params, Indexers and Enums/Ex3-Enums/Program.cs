class Program
{
    static void Main(string[] args)
    {
        List<Employee> empList = new List<Employee>
            {
                new Employee() { Name = "Anurag", Gender = 0 },
                new Employee() { Name = "Pranaya", Gender = 1 },
                new Employee() { Name = "Priyanka", Gender = 2 },
                new Employee() { Name = "Sambit", Gender = 3 }
            };
        foreach (var emp in empList)
        {
            Console.WriteLine($"Name = {emp.Name} && Gender = {GetGender(emp.Gender)}");
        }

        int[] enumValues = (int[])Enum.GetValues(typeof(Gender));
        Console.WriteLine("Gender Enum Values");

        foreach (var value in enumValues)
        {
            Console.WriteLine(value);
        }

        Console.WriteLine();

        string[] enumNames = Enum.GetNames(typeof(Gender));
        Console.WriteLine("Gender Enums Names");

        foreach (var name in enumNames)
        {
            Console.WriteLine(name);
        }

        Console.ReadKey();
    }
    static string GetGender(int gender)
    {
        switch (gender)
        {
            case (int)Gender.Unknown:
                return "Unknown";
            case (int)Gender.Male:
                return "Male";
            case (int)Gender.Female:
                return "Female";
            default:
                return "Invalid data for Gender";
        }
    }
}

class Employee
{
    public string Name { get; set; }
    public int Gender { get; set; }
}

enum Gender : int
{
    Unknown = 1,
    Male,
    Female
}