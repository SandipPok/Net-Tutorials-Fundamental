namespace TwoDimensionalArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a jagged array with four rows
            int[][] arr = new int[4][];

            //Initializing each row with different column size
            //Using one dimensional array
            arr[0] = new int[5];
            arr[1] = new int[6];
            arr[2] = new int[4];
            arr[3] = new int[5];

            //Printing the values of Jagged array using nested for loop
            //It will print the default values as we are not assigning any
            //values to the array
            //GetLength(0): Returns the Size of the Rows (4)
            Console.WriteLine("Printing the Default values of Jagged Array:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                //arr[i].Length: Returns the Length of Each Row
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
            }

            //Assigning values to the Jagged array by using nested for loop
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int num = 10;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    num++;
                    arr[i][j] = num;
                }
            }

            //Printing the values of Jagged array by using foreach loop within for loop
            Console.WriteLine("\n\nPrinting the Values of Jagged Array:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                foreach(int x in arr[i])
                {
                    Console.Write(x + " ");
                }
            }

            //You cannot simply use a foreach loop to Print the Values of a foreach loop
            //foreach (var item in arr)
            //{
            //    Console.Write(item);
            //}
            Console.ReadKey();
        }
    }
}