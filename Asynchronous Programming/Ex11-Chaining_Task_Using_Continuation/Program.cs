namespace Ex11_Chaining_Task_Using_Continuation
{
    public class Program
    {
        public static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Control the Result of a Task
2. TaskCompletionSource With Return Value");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.Write("Do you want to continue? (y/n): ");
            char.TryParse(Console.ReadLine(), out char c);
            if (c == 'y')
            {
                goto LOOP;
            }
        }
    }
}