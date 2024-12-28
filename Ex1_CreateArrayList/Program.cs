using System.Collections;

namespace CreateArrayList
{
    class Program
    {
        public static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(1);
            arrayList.Add("Hello");
            arrayList.Add(3.33);
            arrayList.Add(false);
            arrayList.Add('c');
            arrayList.Add(null);

            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.Write($"{arrayList[i]} ");
            }

            Console.ReadKey();

            ArrayList arrayList2 = new ArrayList()
            {
                102, "World", true, 12.3, null
            };

            foreach (var data in arrayList2)
            {
                Console.WriteLine(data);
            }
            Console.ReadKey();
        }
    }
}