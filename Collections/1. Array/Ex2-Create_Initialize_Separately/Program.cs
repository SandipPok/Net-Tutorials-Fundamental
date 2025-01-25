namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating an Integer Array with size 3
            int[] numbers = new int[3];

            //Accessing the Array Elements before Initialization
            Console.WriteLine("Accessing the Array Elements Before Initialization");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Numbers[{i}] = {numbers[i]}");
            }

            //Initializing the Array Elements using the Index Position
            numbers[0] = 10;
            numbers[1] = 20;
            numbers[2] = 30;

            //Accessing the Array Elements After Initialization
            Console.WriteLine("\nAccessing the Array Elements After Initialization");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Numbers[{i}] = {numbers[i]}");
            }

            Console.ReadKey();
        }
    }
}
