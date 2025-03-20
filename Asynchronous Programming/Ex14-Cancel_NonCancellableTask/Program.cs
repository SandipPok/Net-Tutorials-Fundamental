using System.Threading;

namespace Ex14_Cancel_NonCancellableTask
{
    class Program
    {
        static CancellationTokenSource Cts;
        static void Main(string[] args)
        {
            SomeMethod();
            CancelToken();
            Console.ReadKey();
        }

        public static async void SomeMethod()
        {
            Cts = new CancellationTokenSource();

            try
            {
                var result = await Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    Console.WriteLine("Operation was Successful");
                    return 7;
                }).WithCancellation(Cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Cts.Dispose();
                Cts = null;
            }
        }
        public static void CancelToken()
        {
            Cts?.Cancel();
        }
    }

    public static class TaskExtensionMethods
    {
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            using (cancellationToken.Register(state =>
            {
                ((TaskCompletionSource<object>)state).TrySetResult(null);
            }, tcs))
            {
                var resultTask = await Task.WhenAny(task, tcs.Task);

                if (resultTask == tcs.Task)
                {
                    throw new OperationCanceledException(cancellationToken);
                }
                return await task;
            }
        }
    }
}