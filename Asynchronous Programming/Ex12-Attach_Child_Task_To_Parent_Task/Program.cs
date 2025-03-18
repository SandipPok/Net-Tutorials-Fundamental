namespace Ex12_Attach_Child_Task_To_Parent_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Example to Understand Detached Child Tasks
2. Example to Understand Detached Child Tasks With Return Type
3. Example to Understand Attached Child Tasks
4. Prevent Parent tasks from attached Child Tasks
5. Prevent Parent tasks from attached Child Tasks Using Task.Run(Auto Support)
6. Exceptions in Detached Child Task
7. Exceptions in Attached Child Task");

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
                case 4:
                    MethodImpl.PreventParentAttachFromChildTask().Wait();
                    break;
                case 5:
                    MethodImpl.PreventTaskUsingTaskRun().Wait();
                    break;
                case 6:
                    MethodImpl.ExceptionDetachedChildTask().Wait();
                    break;
                case 7:
                    MethodImpl.ExceptionAttachedChildTask().Wait();
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