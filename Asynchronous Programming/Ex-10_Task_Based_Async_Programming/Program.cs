namespace Ex_10_Task_Based_Async_Programming
{
    class Program
    {
        public static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Understand Task Class and Start Method
2. Create Task Using Factory Property
3. Create Task Using Run Method
4. Task using Anonymous Method and Lambda Expression");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    MethodImpl.TaskClassAndStartMethod().Wait();
                    break;
                case 2:
                    MethodImpl.TaskUsingFactoryProperty().Wait();
                    break;
                case 3:
                    MethodImpl.TaskUsingRunMethod().Wait();
                    break;
                case 4:
                    MethodImpl.TaskUsingAnonymousAndLambdaExpression().Wait();
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