public class Program
{
    static async Task Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Implementing Asynchronous Disposable in C# 8
2. Creating Virtual DisposeAsyncCore Method
3. Overriding the DisposeAsyncCore Method in Child Class
4. Implementing both Dispose and Async Dispose Patterns in C#");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");
        switch (choice)
        {
            case 1:
                await using (var disposable = new Sample())
                {
                    Console.WriteLine("This is async disposable example.");
                }
                break;
            case 2:
                await using(var disposable = new Sample2())
                {
                    Console.WriteLine("This is async disposable example.");
                }
                break;
            case 3:
                await using (var disposable = new SampleInherited())
                {
                    Console.WriteLine("This is async disposable example.");
                }
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
        Console.WriteLine("Do you want to continue? (y/n)");
        char.TryParse(Console.ReadLine(), out char res);

        if (res == 'y')
        {
            goto LOOP;
        }
    }
}

public class Sample : IAsyncDisposable
{
    private TextWriter? textWriter = File.CreateText(Path.Join(Directory.GetCurrentDirectory(), "sample.txt"));
    public async ValueTask DisposeAsync()
    {
        if (textWriter != null)
        {
            textWriter = null;
        }
        await Task.Delay(1000);
        Console.WriteLine("DisposeAsync Clean-up the Memory!");
    }
}

public class Sample2 : IAsyncDisposable
{
    private TextWriter? textWriter = File.CreateText(Path.Join(Directory.GetCurrentDirectory(), "sample.txt"));
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);
        Console.WriteLine("DisposeAsync Clean-up the Memory!");
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (textWriter != null)
        {
            await textWriter.DisposeAsync().ConfigureAwait(false);
            textWriter = null;
            Console.WriteLine("Virtual DisposeAsyncCore Clean-up the Memory");
        }
    }
}

public class SampleInherited : Sample2
{
    protected override async ValueTask DisposeAsyncCore()
    {
        await base.DisposeAsyncCore();
        Console.WriteLine("DisposeAsyncCore Subclass Delaying!");
        await Task.Delay(1000);
        Console.WriteLine("DisposeAsyncCore Subclass Disposed!");
    }
}

public class SampleSyncAsync : IDisposable, IAsyncDisposable
{
    private Stream? disposableResource = new MemoryStream();
    private Stream? asyncDisposableResource = new MemoryStream();
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Console.WriteLine("Dispose Sync");
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);
        Console.WriteLine("Dispose Async");
        GC.SuppressFinalize(this);
        Console.WriteLine("DisposeAsync Clean-up the Memory!");
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (asyncDisposableResource != null)
        {
            await asyncDisposableResource.DisposeAsync().ConfigureAwait(false);
        }
        if (disposableResource is IAsyncDisposable disposable)
        {
            await disposable.DisposeAsync().ConfigureAwait(false);
        }
        else
        {
            disposableResource?.Dispose();
        }
        asyncDisposableResource = null;
        disposableResource = null;
        Console.WriteLine("Virtual DisposeAsyncCore Clean-up the Memory");
    }
}