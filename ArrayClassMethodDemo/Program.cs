namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] arr)
        {
            //Creating and initializing an Array of Integers
            //Size of the Array is 10
            int[] numbers = { 17, 23, 4, 59, 27, 36, 96, 9, 1, 3 };

            //Printing the Array Elements using for loop
            Console.WriteLine("Orginal Array Elements :");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            //Sorting the Array Elements by using the Sort method of Array Class
            Array.Sort(numbers);
            //Printing the Array Elements After Sorting using a foreach loop
            Console.WriteLine("\nArray Elements After Sorting :");
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //Reversing the array elements by using the Reverse method of Array Class
            Array.Reverse(numbers);
            //Printing the Array Elements in Reverse Order
            Console.WriteLine("\nArray Elements in the Reverse Order :");
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //Creating a New array
            int[] newNumbers = new int[10];
            //Copying Some of the Elements from Old array to new array
            //We declare the array with size 10 and we copy only 5 elements. 
            //So the rest 5 elements will take the default value. In this array, it will take 0
            Array.Copy(numbers, newNumbers, 5);

            //Printing the Array Elements using for Each Loop
            Console.WriteLine("\nNew Array Elements :");
            foreach (int i in newNumbers)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"\nNew Array Length using Length Property :{newNumbers.Length}");
            Console.WriteLine($"New Array Length using GetLength Method :{newNumbers.GetLength(0)}");
            Console.ReadKey();
        }
    }
}