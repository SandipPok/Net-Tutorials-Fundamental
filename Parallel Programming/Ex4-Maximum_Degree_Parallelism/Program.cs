namespace Ex4_Maximum_Degree_Parallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            int processorCount = Environment.ProcessorCount;
            Console.WriteLine($"Processor Count on this Machine: {processorCount}\n");

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = processorCount - 1
            };

            Parallel.For(1, 11, options, i =>
            {
                Thread.Sleep(1500);
                Console.WriteLine($"Value of i = {i}, Thread = {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}