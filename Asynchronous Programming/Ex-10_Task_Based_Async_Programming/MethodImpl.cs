namespace Ex_10_Task_Based_Async_Programming
{
    class MethodImpl
    {
        public static async Task TaskClassAndStartMethod()
        {
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");
            Action actionDelegate = new Action(PrintCounter);
            Task task1 = new Task(actionDelegate);
            task1.Start();
            await task1;
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
        }

        public static async Task TaskUsingFactoryProperty()
        {
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");
            Task task1 = Task.Factory.StartNew(PrintCounter);
            await task1;
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
        }

        public static async Task TaskUsingRunMethod()
        {
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");
            Task task1 = Task.Run(() => { PrintCounter(); });
            await task1;
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
        }

        public static async Task TaskUsingAnonymousAndLambdaExpression()
        {
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");
            #region Stat Method
            Task task1 = new Task(PrintCounter);
            task1.Start();

            Task task2 = new Task(delegate ()
            {
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            task2.Start();

            Task task3 = new Task(() =>
            {
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
            });
            task3.Start();

            await Task.WhenAll(task1, task2, task3);
            #endregion

            #region StartNew
            Task task4 = Task.Factory.StartNew(PrintCounter);

            Task task5 = Task.Factory.StartNew(delegate ()
            {
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
            });

            Task task6 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
            });

            await Task.WhenAll(task4, task5, task6);
            #endregion

            #region Run
            Task task7 = Task.Run(() => { PrintCounter(); });

            Task task8 = Task.Run(delegate ()
            {
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
            });

            Task task9 = Task.Run(() =>
            {
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Started");
                Task.Delay(200);
                Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
            });

            await Task.WhenAll(task7, task8, task9);
            #endregion
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");
        }

        private static void PrintCounter()
        {
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Started");
            for (int count = 1; count <= 5; count++)
            {
                Console.WriteLine($"count value: {count}");
            }
            Console.WriteLine($"Child Thread : {Thread.CurrentThread.ManagedThreadId} Completed");
        }
    }
}
