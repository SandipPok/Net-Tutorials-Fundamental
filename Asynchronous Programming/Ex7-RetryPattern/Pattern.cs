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

        public static async Task RetryOperation()
        {
            await Task.Delay(500);
            throw new Exception("Exception Occurred in while Processing...");
        }
    }
}
