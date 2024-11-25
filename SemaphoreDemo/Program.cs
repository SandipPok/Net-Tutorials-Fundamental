namespace SemaphoreDemo
{
    class Program
    {
        public static Semaphore Semaphore { get; set; }
        static void Main(string[] args)
        {
            try
            {
                //Try to Open the Semaphore if Exists, if not throw an exception
                Semaphore = Semaphore.OpenExisting("SemaphoreDemo");
            }
            catch
            {
                //If Semaphore not Exists, create a semaphore instance
                //Here Maximum 2 external threads can access the code at the same time
                Semaphore = new Semaphore(2, 2, "SemaphoreDemo");
            }

            Console.WriteLine("External Thread Trying to Acquiring");
            Semaphore.WaitOne();
            //This section can be access by maximum two external threads: Start
            Console.WriteLine("External Thread Acquired");
            Console.ReadKey();
            //This section can be access by maximum two external threads: End

            Semaphore.Release();
        }
    }
}