using System.Diagnostics;

namespace PerformanceTestingMultithreading
{
    class Program
    {
        public static void Main()
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //stopwatch = Stopwatch.StartNew();
            //EvenNumbersSum();
            //OddNumbersSum();
            //stopwatch.Stop();
            //Console.WriteLine($"Total time in milliseconds : {stopwatch.ElapsedMilliseconds}");
            //Console.ReadKey();

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch = Stopwatch.StartNew();
            Thread thread1 = new Thread(EvenNumbersSum);
            Thread thread2 = new Thread(OddNumbersSum);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            stopwatch.Stop();
            Console.WriteLine($"Total time in milliseconds : {stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();
        }

        public static void EvenNumbersSum()
        {
            double Evensum = 0;
            for (int count = 0; count <= 50000000; count++)
            {
                if (count % 2 == 0)
                {
                    Evensum = Evensum + count;
                }
            }
            Console.WriteLine($"Sum of even numbers = {Evensum}");
        }
        public static void OddNumbersSum()
        {
            double Oddsum = 0;
            for (int count = 0; count <= 50000000; count++)
            {
                if (count % 2 == 1)
                {
                    Oddsum = Oddsum + count;
                }
            }
            Console.WriteLine($"Sum of odd numbers = {Oddsum}");
        }
    }
}