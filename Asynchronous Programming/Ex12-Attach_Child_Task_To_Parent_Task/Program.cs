namespace Ex12_Attach_Child_Task_To_Parent_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Example to Understand Detached Child Tasks
2. Example to Understand Detached Child Tasks With Return Type
3. Example to Understand Attached Child Tasks");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    MethodImpl.DetachChildTask();
                    break;
                case 2:
                    MethodImpl.DetachChildTaskWithReturnType().Wait();
                    break;
                case 3:
                    MethodImpl.AttachChildTask().Wait();
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