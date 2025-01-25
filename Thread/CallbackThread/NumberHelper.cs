namespace CallbackThread
{
    //First creat the callback delegate with the same signature of the callback method
    public delegate void ResultCallbackDelegate(int results);
    
    //Creating the helper class
    public class NumberHelper
    {
        // Creating two private variables to hold the Number and ResultCallback instance
        private int _number;
        private ResultCallbackDelegate _resultCallbackDelegate;

        //Initializing the private variables through constructor
        //So while creating the instance you need to pass the value for Number and callback delegate
        public NumberHelper(int number, ResultCallbackDelegate resultCallbackDelegate)
        {
            _number = number;
            _resultCallbackDelegate = resultCallbackDelegate;
        }

        // This is the Thread function which will calculate the sum of the numbers
        public void CalculateSum()
        {
            int result = 0;
            for (int i = 1; i < _number; i++)
            {
                result += i;
            }
            Thread.Sleep(5000);
            // Before the end of the thread function call the callback method
            if (_resultCallbackDelegate != null)
            {
                _resultCallbackDelegate(result);
            }
        }
    }
}
