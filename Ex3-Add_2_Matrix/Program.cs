namespace TwoDimensionArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rows and columns of the Matrices: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            int columns = Convert.ToInt32(Console.ReadLine());

            //Create 3 2D Arrays with the above size
            int[,] matrix1 = new int[rows, columns];
            int[,] matrix2 = new int[rows, columns];
            int[,] resultMatrix = new int[rows, columns];

            //Enter Matrix 1 Elements
            Console.WriteLine("\nEnter Elements of 1st Matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            //Enter Matrix 2 Elements
            Console.WriteLine("\nEnter Elements of 2st Matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            //Adding Both Matrix Elements and Store the Result in ResultMatrix
            Console.WriteLine("\nSum of Both the Matrics:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

                    Console.Write($"{resultMatrix[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}