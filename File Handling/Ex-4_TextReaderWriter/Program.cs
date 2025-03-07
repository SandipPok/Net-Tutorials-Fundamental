using TextReaderWriterDemo.Method;

namespace TextReaderWriterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\DotNet\Net Tutorials\File Handling\Ex-4_TextReaderWriter\myFile.txt";
        LOOP:
            Console.WriteLine(@"1. IndentedTextWriter
2. TextWriter
3. TextReader
");

            Console.Write("\nEnter the choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine();
                StringMethods fm = new StringMethods(path);
                switch (choice)
                {
                    case 1:
                        fm.IndentedTextWriter();
                        break;
                    case 2:
                        fm.TextWriter();
                        break;
                    case 3:
                        fm.TextReader();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Do you want to continue? (y/n)");
                string? s = Console.ReadLine();

                if (s != null && (s[0] == 'y' || s[0] == 'Y'))
                {
                    goto LOOP;
                }
            }
            else
            {
                Console.WriteLine("Enter the valid choice");
                goto LOOP;
            }
        }
    }
}