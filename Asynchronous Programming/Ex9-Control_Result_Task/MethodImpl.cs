using System.Threading.Tasks;

namespace Ex9_Control_Result_Task
{
    class MethodImpl
    {
        public static async void ControlResultTask(string value)
        {
            var task = EvaluateValue(value);
            Console.WriteLine("Method Started");
            try
            {
                Console.WriteLine($"Is Completed: {task.IsCompleted}");
                Console.WriteLine($"Is IsCanceled: {task.IsCanceled}");
                Console.WriteLine($"Is IsFaulted: {task.IsFaulted}");
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Method Completed");
        }

        public static async void ControlResultTaskWithReturnValue(string value)
        {
            var task = EvaluateValue(value, "2nd method");
            Console.WriteLine("Method Started");
            try
            {
                Console.WriteLine($"Is Completed: {task.IsCompleted}");
                Console.WriteLine($"Is IsCanceled: {task.IsCanceled}");
                Console.WriteLine($"Is IsFaulted: {task.IsFaulted}");
                var result = await task;
                Console.WriteLine($"Result: {result}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            Console.WriteLine("Method Completed");
        }

        private static Task EvaluateValue(string value)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            if (value == "1")
            {
                tcs.SetResult(null);
            }
            else if (value == "2")
            {
                tcs.SetCanceled();
            }
            else
            {
                tcs.SetException(new ApplicationException($"Invalid Value: {value}"));
            }

            return tcs.Task;
        }
        private static Task<string> EvaluateValue(string value, string methodName)
        {
            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

            if (value == "1")
            {
                tcs.SetResult("Task Completed");
            }
            else if (value == "2")
            {
                tcs.SetCanceled();
            }
            else
            {
                tcs.SetException(new ApplicationException($"Invalid Value: {value}"));
            }

            return tcs.Task;
        }
    }
}
