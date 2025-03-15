namespace Ex7_RetryPattern
{
    class Pattern
    {
        public static async Task RetryMethod(int retryTimes = 3, int waitTime = 500)
        {
            for (int i = 0; i < retryTimes; i++)
            {
                try
                {
                    await RetryOperation();
                    Console.WriteLine("Operation Successful");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Retry {i + 1}: Getting Exception : {ex.Message}");
                    await Task.Delay(waitTime);
                }
            }
        }

        public static async Task GenericRetry(Func<Task> fun, int retryTimes = 3, int waitTime = 500)
        {
            for (int i = 0; i < retryTimes; i++)
            {
                try
                {
                    await fun();
                    Console.WriteLine("Operation Successful");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Retry {i + 1}: Getting Exception : {ex.Message}");
                    await Task.Delay(waitTime);
                }
            }
        }

        public static async Task GenericRetryProblemFix(Func<Task> fun, int RetryTimes = 3, int WaitTime = 500)
        {
            //Reducing the for loop Execution for 1 time
            for (int i = 0; i < RetryTimes - 1; i++)
            {
                try
                {
                    //Do the Operation
                    //We are going to invoke whatever function the generic func delegate points to
                    await fun();
                    Console.WriteLine("Operation Successful");
                    break;
                }
                catch (Exception Ex)
                {
                    //If the operations throws an error
                    //Log the Exception if you want
                    Console.WriteLine($"Retry {i + 1}: Getting Exception : {Ex.Message}");
                    //Wait for 500 milliseconds
                    await Task.Delay(WaitTime);
                }
            }

            //Final try to execute the operation
            await fun();
        }

        public static async Task<T> GenericRetryWithParams<T>(Func<Task<T>> fun, int RetryTimes = 3, int WaitTime = 500)
        {
            //Reducing the for loop Execution for 1 time
            for (int i = 0; i < RetryTimes - 1; i++)
            {
                try
                {
                    //Do the Operation
                    //We are going to invoke whatever function the generic func delegate points to
                    //We will return from here if the operation was successful
                    return await fun();

                }
                catch (Exception Ex)
                {
                    //If the operations throws an error
                    //Log the Exception if you want
                    Console.WriteLine($"Retry {i + 1}: Getting Exception : {Ex.Message}");
                    //Wait for 500 milliseconds
                    await Task.Delay(WaitTime);
                }
            }
            //Final try to execute the operation
            return await fun();
        }

        public static async Task RetryOperation()
        {
            await Task.Delay(500);
            throw new Exception("Exception Occurred in while Processing...");
        }

        public static async Task<string> RetryOperationValueReturning()
        {
            //Doing Some Processing and return the value
            await Task.Delay(500);
            //Uncomment the below code to successfully return a string
            //return "Operation Successful";
            //Throwing Exception so that retry will work
            throw new Exception("Exception Occurred in RetryOperation1");
        }
    }
}
