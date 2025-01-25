using System.Collections;

namespace RemoveElementArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList()
            {
                    "India",
                    "USA",
                    "UK",
                    "Nepal",
                    "HongKong",
                    "Srilanka",
                    "Japan",
                    "Britain",
                    "HongKong",
            };

            arrayList.Remove("India");

            arrayList.RemoveAt(7);

            arrayList.RemoveRange(3, 2);

            arrayList.Clear();

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}