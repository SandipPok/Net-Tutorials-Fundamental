using System.Collections;

namespace AccessArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList()
            {
                1101, "James", true, 4.5
            };

            int first = (int)arrayList[0];
            string second = (string)arrayList[1];

            Console.WriteLine($"First Element: {first}, Second Element: {second}");

            arrayList[0] = "Smith";
            arrayList[1] = 1010;

            foreach (var item in arrayList)
            {
                Console.Write($"{item} ");
            }
            Console.ReadKey();
        }
    }
}