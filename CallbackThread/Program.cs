namespace CallbackThread
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the ResultCallbackDelegate instance and to its constructor
            // pass the callback method name
            ResultCallbackDelegate resultCallbackDelegate = new ResultCallbackDelegate(ResultCallbackMethod);

            int number = 20;

            // Creating the instance of NumberHelper class by passing the Number
            // the callback delegate instance
            NumberHelper obj = new NumberHelper(number, resultCallbackDelegate);

            // Creating the Thread using ThreadStart delegate
            Thread t1 = new Thread(new ThreadStart(obj.CalculateSum));

            t1.Start();

            Console.Read();
        }

        // Callback method and the signature should be the same as the callback delegate signature
        public static void ResultCallbackMethod(int Result)
        {
            Console.WriteLine("The Result is " + Result);
        }
    }
}