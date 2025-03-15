namespace Ex7_RetryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Retry Pattern
2. Generic Retry Pattern
3. Problem With Generic Retry Pattern
4. Generic Async Retry Pattern");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    var task = Task.Run(() => Pattern.RetryMethod());
                    task.Wait();
                    break;
                case 2:
                    Pattern.RetryMethod();
                    break;
                case 3:
                    Pattern.RetryMethod();
                    break;
                case 4:
                    Pattern.RetryMethod();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.Write("Do you want to continue? (y/n): ");
            char c = Convert.ToChar(Console.ReadLine());
            if (c == 'y')
            {
                goto LOOP;
            }
        }
    }
}