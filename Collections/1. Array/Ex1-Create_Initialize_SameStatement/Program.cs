namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating and Initializing an Array
            //Here, the size will be decided based on the number of elements
            //In this case size will be 3
            int[] numbers = { 10, 20, 30 };

            //Accessing the Array Elements separately
            Console.WriteLine("Accessing the Array Elements seperately");
            Console.WriteLine($"Number[0] = {numbers[0]}");
            Console.WriteLine($"Number[1] = {numbers[1]}");
            Console.WriteLine($"Number[2] = {numbers[2]}");

            //Accessing the Array Elements using for loop
            Console.WriteLine("\nAccessing the Array Elements using For Loop");
            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                Console.WriteLine($"Number[{i}] = {numbers[i]}");
            }

            //Accessing the Array Elements using foreach loop
            Console.WriteLine("\nAccessing the Array Elements using ForEach Loop");
            foreach (int number in numbers)
            {
                Console.WriteLine($"{number}");
            }
            Console.ReadKey();
        }
    }
}