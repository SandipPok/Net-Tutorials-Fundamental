using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex8_OnlyOnePattern
{
    class MethodImpl
    {
        public static async Task CreatingOnlyOnePattern()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            List<string> names = new List<string> { "John", "Doe", "Jane" };

            var tasks = names.Select(x => ProcessingName(x));
            var task = await Task.WhenAny(tasks);
            var content = await task;

            cts.Cancel();
            Console.WriteLine($"\n{content}");
        }

        public static async Task CallGenericOnlyOnePattern()
        {
            List<string> names = new List<string>() { "Pranaya", "Anurag", "James", "Smith" };
            Console.WriteLine($"All Names");
            foreach (var item in names)
            {
                Console.Write($"{item} ");
            }
            var tasks = names.Select(name =>
            {
                Func<CancellationToken, Task<string>> func = (ct) => ProcessingName(name);
                return func;
            });

            var content = await GenericOnlyOnePattern(tasks);

            Console.WriteLine($"\n{content}");
        }

        public static async Task CallGenericOnlyOnePatternWithDiffMethod()
        {
            var result = await GenericOnlyOnePattern((ct) => HelloMethod("John"),
                                                     (ct) => GoodbyeMethod("Doe"));
            Console.WriteLine(result);
        }

        private static async Task<T> GenericOnlyOnePattern<T>(IEnumerable<Func<CancellationToken, Task<T>>> functions)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var tasks = functions.Select(x => x(cancellationTokenSource.Token));
            var task = await Task.WhenAny(tasks);
            cancellationTokenSource.Cancel();
            return await task;
        }

        private static async Task<string> ProcessingName(string name)
        {
            var waitingTime = new Random().NextDouble() * 10 + 1;
            await Task.Delay(TimeSpan.FromSeconds(waitingTime));

            string message = $"Hello {name}";
            return message;
        }

        private static async Task<T> GenericOnlyOnePattern<T>(params Func<CancellationToken, Task<T>>[] functions)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var tasks = functions.Select(x => x(cancellationTokenSource.Token));
            var task = await Task.WhenAny(tasks);
            cancellationTokenSource.Cancel();
            return await task;
        }

        private static async Task<string> HelloMethod(string name)
        {
            var WaitingTime = new Random().NextDouble() * 10 + 1;
            await Task.Delay(TimeSpan.FromSeconds(WaitingTime));
            string message = $"Hello {name}";
            return message;
        }
        private static async Task<string> GoodbyeMethod(string name)
        {
            var WaitingTime = new Random().NextDouble() * 10 + 1;
            await Task.Delay(TimeSpan.FromSeconds(WaitingTime));
            string message = $"Goodbye {name}";
            return message;
        }
    }
}
