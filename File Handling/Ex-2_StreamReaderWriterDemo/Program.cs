using StreamReaderWriterDemo.Method;

namespace StreamReaderWriterDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"D:\DotNet\Net Tutorials\File Handling\Ex-2_StreamReaderWriterDemo\myFile.txt";
            Console.WriteLine(@"
1. Write
2. WriteLine
3. Open
4. Append");
            Console.WriteLine("Enter the option to perform task");

            int option = Convert.ToInt16(Console.ReadLine());

            StreamReaderWriter srw = new StreamReaderWriter(path);

            switch (option)
            {
                case 1:
                    srw.Write();
                    break;
                case 2:
                    srw.WriteLine();
                    break;
                case 3:
                    srw.Open();
                    break;
                case 4:
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}