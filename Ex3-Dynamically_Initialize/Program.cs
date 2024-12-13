namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the array with size 3
            int[] arr = new int[3];

            //Accessing array values using loop
            //Here it will display the default values
            //as we are not assigning any values
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            int a = 0;

            //Here we are assigning values to array using for loop
            for (int i = 0; i < arr.Length; i++)
            {
                a += 10;
                arr[i] = a;
            }

            //Console.WriteLine("Please enter the 3 number in an array");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int data = Convert.ToInt32(Console.ReadLine());
            //    arr[i] = data;
            //}


            //accessing array values using foreach loop
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }
}