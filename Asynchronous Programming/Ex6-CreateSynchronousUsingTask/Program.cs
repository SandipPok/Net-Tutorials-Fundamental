namespace Ex6_CreateSynchronousUsingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Started");

            CompleteTask();
            FromResult();
            FromException();
            FromCancellation();

            Console.WriteLine("Main Method Completed");
            Console.ReadKey();
        }

        static Task CompleteTask()
        {
            Console.WriteLine("CompleteTask Method Executing, It does not return anything");
            return Task.CompletedTask;
        }

        static Task<string> FromResult()
        {
            string name = "Don Dai";
            Console.WriteLine("FromResult Method Executing, It return a string");
            return Task.FromResult(name);
        }

        static Task FromException()
        {
            Console.WriteLine("FromException Method Executing, It will throw an Exception");
            return Task.FromException(new InvalidOperationException());
        }

        static Task FromCancellation()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            Console.WriteLine("FromCancellation Method Executing, It will Cancel the Task Exception");
            return Task.FromCanceled(cts.Token);
        }
    }
}