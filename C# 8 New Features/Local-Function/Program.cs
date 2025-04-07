class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Local Functions without static method
2. Local Functions with static method in C# 8.0");
        Console.Write("Select an option: ");
        int.TryParse(Console.ReadLine(), out int choice);

        switch (choice)
        {
            case 1:
                Calculate();
                break;
            case 2:
                CalculateNew();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                goto LOOP;
        }

        Console.WriteLine("Do you want to continue? (y/n)");
        char.TryParse(Console.ReadLine(), out char continueChoice);
        if (continueChoice == 'y' || continueChoice == 'Y')
        {
            goto LOOP;
        }
    }

    public static void Calculate()
    {
        int x = 20, y = 30, result;
        CalculateSum(x, y);

        void CalculateSum(int x, int y)
        {
            result = x + y;
            Console.WriteLine($"Sum: {result}");
        }

        CalculateSum(30, 100);
        CalculateSum(50, 200);
    }
    public static void CalculateNew()
    {
        int x = 20, y = 30;
        CalculateSum(x, y);

        // int result;

        static void CalculateSum(int x, int y)
        {
            /// This is not allowed from C# 8 to use the local variable
            /// from static method

            // result = x + y;
            int result = x + y;
            Console.WriteLine($"Sum: {result}");
        }
        CalculateSum(30, 10);
        CalculateSum(80, 60);
    }
}