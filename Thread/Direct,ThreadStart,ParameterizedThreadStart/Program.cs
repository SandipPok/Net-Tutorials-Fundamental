namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args) 
        {
            #region ThreadStart Demo

            //Creating the ThreadStart Delegate instance by passing
            //the method name as a parameter to its constructor
            ThreadStart obj = new ThreadStart(DisplayNumbers);

            //Passing the ThreadStart Delegate instance as a parameter
            //to its constructor
            Thread t1 = new Thread(obj);
            t1.Start();
            Console.Read();

            #endregion

            #region Anonymous Function in Thread

            //Creating Thread Class Instance using Anonymous Function
            Thread t2 = new Thread(delegate ()
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Method2 :" + i);
                }
            });
            t2.Start();
            Console.Read();

            #endregion

            #region Anonymous Function in Thread

            //Creating Thread Class Instance using Lambda Expression
            Thread t3 = new Thread(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Method3 :" + i);
                }
            });
            t3.Start();
            Console.Read();

            #endregion

            #region Thread Function with Parameter

            //DisplayNumbers is now a non-static method, so we need to
            //refer it by using the instance

            Program newObj = new Program();
            Thread t4 = new Thread(newObj.DisplayNumbers);
            t4.Start(5);
            Console.Read();

            #endregion

            #region Creating the ParameterizedThreadStart Instance Manually
            ParameterizedThreadStart pts = new ParameterizedThreadStart(newObj.DisplayNumbers);
            Thread t5 = new Thread(pts);
            t5.Start(9);

            Console.Read();
            #endregion
        }

        static void DisplayNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
        }

        public void DisplayNumbers(object Max)
        {
            int Number = Convert.ToInt32(Max);
            for (int i=1; i <= Number; i++)
            {
                Console.WriteLine("Method4 :" + i);
            }
        }
    }
}