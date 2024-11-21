namespace ThreadSynchronization
{
    class Program
    {
        static object LOCK_OBJECT = new object();
        public static void Main(string[] args)
        {
            #region Thread Without Locking
            //Thread t1 = new Thread(WithoutLockMethod);
            //Thread t2 = new Thread(WithoutLockMethod);
            //Thread t3 = new Thread(WithoutLockMethod);

            //t1.Start();
            //t2.Start();
            //t3.Start();
            #endregion

            #region Thread With Locking
            //Thread tl1 = new Thread(ThreadLockMethod)
            //{
            //    Name = "Thread 1"
            //};

            //Thread tl2 = new Thread(ThreadLockMethod)
            //{
            //    Name = "Thread 2"
            //};

            //Thread tl3 = new Thread(ThreadLockMethod)
            //{
            //    Name = "Thread 3"
            //};

            //tl1.Start();
            //tl2.Start();
            //tl3.Start();
            #endregion

            #region Ticket Booking Example With Thread Synchronous
            BookMyShow bookShow = new BookMyShow();
            Thread bs1 = new Thread(bookShow.TicketBooking)
            {
                Name = "Thread 1"
            };
            Thread bs2 = new Thread(bookShow.TicketBooking)
            {
                Name = "Thread 2"
            };
            Thread bs3 = new Thread(bookShow.TicketBooking)
            {
                Name = "Thread 3"
            };

            bs1.Start();
            bs2.Start();
            bs3.Start();
            #endregion

            Console.Read();
        }
        public static void WithoutLockMethod()
        {
            Console.Write("[Welcome To The ");
            Thread.Sleep(1000);
            Console.WriteLine("World of Dotnet!]");
        }

        public static void ThreadLockMethod()
        {
            // Locking the Shared Resource for Thread Synchronization
            lock (LOCK_OBJECT)
            {
                Console.Write("[Welcome To The ");
                Thread.Sleep(1000);
                Console.WriteLine("World of Dotnet!]");
            }
        }
    }
}