namespace Ex15_AsynchronousStreams
{
    class MethodImpl
    {
        public static IEnumerable<string> GenerateNames()
        {
            yield return "John";
            yield return "Doe";
            yield return "Jane";
        }

        public static async IAsyncEnumerable<string> GenerateNamesAsync()
        {
            yield return "John";
            yield return "Doe";
            await Task.Delay(TimeSpan.FromSeconds(3));
            yield return "Jane";
        }
    }
}
