namespace TwoDimensionalArrayDemo
{
    class Prgram
    {
        static void Main(string[] args)
        {
            //Creating a 2D Array with 4 rows and 5 columns
            int[,] rectangleArray = new int[4, 5];
            int a = 0;

            //Printing the values of 2D array using foreach loop
            //It will print the default values as we are not assigning
            //any values to the array
            foreach (int i in rectangleArray)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            //Assigning values to the 2D array by using nested for loop
            //arr.GetLength(0): Returns the size of the Row
            //arr.GetLength(1): Returns the size of the Column
            for (int i = 0; i < rectangleArray.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleArray.GetLength(1); j++)
                {
                    a += 5;
                    rectangleArray[i, j] = a;
                }
            }

            //Printing the values of array by using nested for loop
            //arr.GetLength(0): Returns the size of the Row
            //arr.GetLength(1): Returns the size of the Column
            for (int i = 0; i < rectangleArray.GetLength(0); i++)
            {
                for (int j = 0; j < rectangleArray.GetLength(1); j++)
                {
                    Console.Write(rectangleArray[i, j] + " ");
                }
            }
            Console.ReadKey();
        }
    }
}