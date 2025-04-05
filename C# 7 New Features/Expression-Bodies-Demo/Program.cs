
class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Method Expression Bodied Members
2. Constructors Expression Bodied Members
3. Destructors Expression Bodied Member");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);

        switch (choice)
        {
            case 1:
                Employee employee = new Employee("John", "Doe");
                employee.DisplayName();
                Console.WriteLine(employee);
                break;
            case 2:
                Location lo = new Location("New York");
                Console.WriteLine(lo.City);
                break;
            case 3:
                Destructor de = new Destructor();
                de = null;
                GC.Collect();
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
        Console.WriteLine("Do you want to continue? (y/n)");
        char.TryParse(Console.ReadLine(), out char res);

        if (res == 'y')
        {
            goto LOOP;
        }
    }
}

class Employee
{
    private string FirstName { get; set; }
    private string LastName { get; set; }
    public Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Expression-bodied member
    public string GetFullName() => $"{FirstName} {LastName}";

    public override string ToString() => $"{FirstName} {LastName}";

    public void DisplayName() => Console.WriteLine(GetFullName());
}

class Location
{
    public string City { get; set; }

    public Location(string city) => City = city;
}

public class Destructor
{
    ~Destructor() => Console.WriteLine("Destructor called");
}