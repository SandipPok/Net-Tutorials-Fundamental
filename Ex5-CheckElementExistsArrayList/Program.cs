using System.Collections;

namespace CheckIfElementExists
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList()
            {
                "Don Dai",
                8848,
                true,
                "Nepal",
                'S',
                "India",
                "UK",
                "Nepal",
                101
            };

            Console.WriteLine("Array List Elements");
            foreach (var item in al)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\n\nIs ArrayList Contains India: {al.Contains("India")}");
            Console.WriteLine($"Is ArrayList Contains USA: {al.Contains("USA")}");
            Console.WriteLine($"Is ArrayList Contains 101: {al.Contains(101)}");
            Console.WriteLine($"Is ArrayList Contains 10.5: {al.Contains(10.5)}");
            Console.ReadKey();
        }
    }
}