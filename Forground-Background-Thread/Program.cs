namespace ThreadTypes
{
    public class Program
    {
        static void Main(string[] args)
        {
            ThreadingTest foregroundTest = new ThreadingTest(5);

            //Creating a Foreground Thread
            Thread foregroundThread = new Thread(new ThreadStart(foregroundTest.RunLoop));

            ThreadingTest backgroundTest = new ThreadingTest(50);

            //Creating a Background Thread
            Thread backgroundThread = new Thread(new ThreadStart(backgroundTest.RunLoop))
            {
                IsBackground = true
            };

            foregroundThread.Start();
            backgroundThread.Start();
        }
    }

    class ThreadingTest
    {
        readonly int maxIterations;

        public ThreadingTest(int maxIterations)
        {
            this.maxIterations = maxIterations;
        }

        public void RunLoop()
        {
            for (int i = 0; i < maxIterations; i++)
            {
                Console.WriteLine("{0} count: {1}", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread", i);
                Thread.Sleep(250);
            }
            Console.WriteLine("{0} finished counting.", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread");
        }
    }
}