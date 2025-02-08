namespace Generics
{
    class Program
    {
        public static void Main(string[] args)
        {
            GenericsDemo<int> demo = new GenericsDemo<int>();
            bool IsEqual = demo.AreEqual(8, 9);

            if (IsEqual)
            {
                Console.WriteLine("Both are equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
            Console.ReadKey();

            GenericsDemo<int>.ShowMessage<string>("Hello World");
            Console.ReadKey();
        }
    }

    public class GenericsDemo<T>
    {
        public bool AreEqual<T>(T val1, T val2)
        {
            return val1.Equals(val2);
        }

        public static void ShowMessage<T>(T value)
        {
            Console.WriteLine(value);
        }
    }
}