namespace wait_pulse_table
{
    class Program
    {
        static readonly object LOCKOBJECT = new object();
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintTable)
            {
                Name = "Manual Thread"
            };
            thread.Start();

            lock (LOCKOBJECT)
            {
                Monitor.Wait(LOCKOBJECT);

                Thread th = Thread.CurrentThread;
                th.Name = "Main Thread";
                Console.WriteLine($"{th.Name} Running and Printing the Table of 5");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("5 x {0} = {1}", i, i * 5);
                }
            }

            Console.ReadKey();
        }

        static void PrintTable()
        {
            lock (LOCKOBJECT)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Running and Printing the Table of 4");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("4 x {0} = {1}", i, i * 4);
                }

                Monitor.Pulse(LOCKOBJECT);
            }
        }
    }
}