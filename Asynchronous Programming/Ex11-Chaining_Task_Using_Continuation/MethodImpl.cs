namespace Ex11_Chaining_Task_Using_Continuation
{
    class MethodImpl
    {
        public static void CreatingContinuationSingleAntecedent()
        {
            Task<string> task1 = Task.Run(() =>
            {
                return 12;
            }).ContinueWith((antecedent) =>
            {
                return $"This Square of {antecedent.Result} is: {antecedent.Result * antecedent.Result}";
            });

            Console.WriteLine(task1.Result);
            Console.ReadKey();
        }

        public static void SchedulingDifferentContinuationTasks()
        {
            Task<int> task = Task.Run(() =>
            {
                return 10;
            });

            task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();

            Console.ReadKey();
        }
    }
}
