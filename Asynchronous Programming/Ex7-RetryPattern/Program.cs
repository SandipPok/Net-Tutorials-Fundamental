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
4. Generic Async Retry Pattern With Returning Value");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    var task = Task.Run(() => Pattern.RetryMethod());
                    task.Wait();
                    break;
                case 2:
                    Task.Run(() => Pattern.GenericRetry(Pattern.RetryOperation)).Wait();
                    break;
                case 3:
                    Task.Run(() => Pattern.GenericRetryProblemFix(Pattern.RetryOperation)).Wait();
                    break;
                case 4:
                    Task.Run(() => Pattern.GenericRetryWithParams<string>(Pattern.RetryOperationValueReturning)).Wait();
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