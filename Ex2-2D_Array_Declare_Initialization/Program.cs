namespace TwoDimensionalArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assigning the Array Elements at the time of declaration
            //Rows Size: 3
            //Column Size: 4
            int[,] numbersArray = {
                {11, 12, 13, 14},
                {21, 22, 23, 24 },
                {31, 32, 33, 34 }
            };

            //Printing Array Elements using for each loop
            Console.WriteLine("Printing Array Elements using ForEach loop");
            foreach (int i in numbersArray)
            {
                Console.Write(i + " ");
            }

            //Printing Array Elements using nested for each
            Console.WriteLine("\n\nPrinting Array Elements using Nested For Loop");
            for (int i = 0; i < numbersArray.GetLength(0); i++)
            {
                for (int j = 0; j < numbersArray.GetLength(1); j++)
                {
                    Console.Write(numbersArray[i, j] + " ");
                }
            }

            Console.ReadKey();
        }
    }
}