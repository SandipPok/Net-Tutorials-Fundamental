using System.Collections;

namespace InsertIntoSpecific
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList()
            {
                101,
                "James Madison",
                true,
                10.20
            };

            arrayList.Insert(1, "Don Dai");

            // Insert "Third Element" at Third Position i.e.Index 2
            arrayList.Insert(2, "Third Element");

            ArrayList arrayList2 = new ArrayList()
            {
                "Tottenham",
                true,
                50.05
            };

            arrayList.InsertRange(2, arrayList2);

            //Iterating through foreach loop
            foreach (var item in arrayList)
            {
                Console.WriteLine($"{item}");
            }
            Console.ReadKey();
        }
    }
}