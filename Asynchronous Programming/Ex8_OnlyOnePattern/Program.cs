namespace Ex8_OnlyOnePattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Creating Only One Pattern
2. Generic Only One Pattern
3. OnlyOne Pattern with Different Methods");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    MethodImpl.CreatingOnlyOnePattern().Wait();
                    break;
                case 2:
                    MethodImpl.CallGenericOnlyOnePattern().Wait();
                    break;
                case 3:
                    MethodImpl.CallGenericOnlyOnePatternWithDiffMethod().Wait();
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