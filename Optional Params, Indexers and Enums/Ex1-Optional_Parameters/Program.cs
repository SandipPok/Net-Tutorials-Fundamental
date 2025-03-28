using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Using Parameter Array
2. Method Overloading
3. Specify Parameter Defaults
4. Using Optional Attribute");

        Console.Write("Enter the choice: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");
        switch (choice)
        {
            case 1:
                AddNumbers(10, 20);
                AddNumbers(10, 20, 30, 40);
                AddNumbers(10, 20, new int[] { 30, 40, 50 });
                break;
            case 2:
                AddNumbers(10, 20);
                AddNumbers(10, 20, 30, 40);
                break;
            case 3:
                DefaultNullAddNumbers(10, 20);
                DefaultNullAddNumbers(10, 20, new int[] { 30, 40 });
                break;
            case 4:
                OptionalAddNumbers(10, 20);
                OptionalAddNumbers(10, 20, new int[] { 30, 40 });
                break;
            default:
                break;
        }
    }

    static void AddNumbers(int first, int last, params int[] numbers)
    {
        int result = first + last;

        foreach (int i in numbers)
        {
            result += i;
        }

        Console.WriteLine("Total = " + result);
    }
    public static void AddNumbers(int first, int last)
    {
        int result = first + last;
        Console.WriteLine("Total (2 params) = " + result);
    }

    static void DefaultNullAddNumbers(int first, int last, int[] numbers = null)
    {
        int result = first + last;

        if (numbers != null)
            foreach (int i in numbers)
            {
                result += i;
            }

        Console.WriteLine("Total = " + result);
    }

    static void OptionalAddNumbers(int first, int last, [Optional] int[] numbers)
    {
        int result = first + last;

        if (numbers != null)
            foreach (int i in numbers)
            {
                result += i;
            }

        Console.WriteLine("Total = " + result);
    }
}