using System.Runtime.CompilerServices;

namespace Ex16_CancelAsyncStream
{
    class MethodImpl
    {
        public static async IAsyncEnumerable<string> GenerateNameAsync()
        {
            var names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" };
            yield return names[0];
            await Task.Delay(TimeSpan.FromSeconds(3));
            yield return names[1];
            await Task.Delay(TimeSpan.FromSeconds(3));
            yield return names[3];
            await Task.Delay(TimeSpan.FromSeconds(3));
            yield return names[4];
            await Task.Delay(TimeSpan.FromSeconds(3));
            yield return names[5];
        }

        public static async IAsyncEnumerable<string> GenerateNameAsync([EnumeratorCancellation] CancellationToken token = default)
        {
            var names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" };
            yield return names[0];
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            yield return names[1];
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            yield return names[3];
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            yield return names[4];
            await Task.Delay(TimeSpan.FromSeconds(3), token);
            yield return names[5];
        }
    }
}
