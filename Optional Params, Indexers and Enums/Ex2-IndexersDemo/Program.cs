using Ex2_IndexersDemo.Model;

class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Int Indexers
2. String Indexers
3. Indexer Overloading
4. Indexers Real-Time Example");

        Console.Write("Enter the choice: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");

        string[] keys = { "id", "name", "job", "salary", "location", "department", "gender" };

        switch (choice)
        {
            case 1:
                EmployeeInt emp = new EmployeeInt(111,
                                                  "DonDai",
                                                  "COO",
                                                  100000,
                                                  "HongKong Pokhara",
                                                  "IT",
                                                  "Male");

                for (int i = 0; i < keys.Length; i++)
                {
                    Console.WriteLine($"{keys[i]} = {emp[i]}");
                }

                emp[1] = "DaiDon";
                emp[2] = "CEO";

                Console.WriteLine("\nAfter updating the values\n");
                for (int i = 0; i < keys.Length; i++)
                {
                    Console.WriteLine($"{keys[i]} = {emp[i]}");
                }

                break;
            case 2:
                EmployeeString empStr = new EmployeeString(111,
                                                           "DonDai",
                                                           "COO",
                                                           100000,
                                                           "HongKong Pokhara",
                                                           "IT",
                                                           "Male");

                foreach (var key in keys)
                {
                    Console.WriteLine($"{key} = {empStr[key]}");
                }

                empStr[keys[1]] = "DaiDon";
                empStr[keys[2]] = "CEO";

                Console.WriteLine("\nAfter updating the values\n");
                foreach (var key in keys)
                {
                    Console.WriteLine($"{key} = {empStr[key]}");
                }

                break;
            case 3:
                EmployeeOverloading empOverload = new EmployeeOverloading(111,
                                                                          "DonDai",
                                                                          "COO",
                                                                          100000,
                                                                          "HongKong Pokhara",
                                                                          "IT",
                                                                          "Male");

                for (int i = 0; i < keys.Length; i++)
                {
                    Console.WriteLine($"{keys[i]} = {empOverload[i]}");
                }
                Console.WriteLine("");

                foreach (var key in keys)
                {
                    Console.WriteLine($"{key} = {empOverload[key]}");
                }

                break;
            case 4:
                RealTimeExampleIndexer();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        Console.WriteLine("");
        Console.Write("Do you want to continue? (y/n): ");
        char.TryParse(Console.ReadLine(), out char c);
        if (c == 'y')
        {
            goto LOOP;
        }
    }

    private static void RealTimeExampleIndexer()
    {
        Company company = new Company();

        Console.WriteLine("Name of Employee with Id = 101: " + company[110]);
        Console.WriteLine("Name of Employee with Id = 105: " + company[111]);
        Console.WriteLine("Name of Employee with Id = 107: " + company[112]);

        Console.WriteLine();

        Console.WriteLine("Changing the names of employees with Id = 101,105,107");

        company[110] = "Employee 101 Name Changed";
        company[111] = "Employee 105 Name Changed";
        company[112] = "Employee 107 Name Changed";
        Console.WriteLine();

        Console.WriteLine("Name of Employee with Id = 101: " + company[110]);
        Console.WriteLine("Name of Employee with Id = 105: " + company[111]);
        Console.WriteLine("Name of Employee with Id = 107: " + company[112]);
    }
}