class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Using Statement (Old Way)
2. Using Declarations in C# 8
3. Example to Understand Disposing of Multiple Resources using Statement (Old Way)
4. Dispose Multiple Resources using Statement (New Way)
5. How to Dispose of a Resource Before the Method Ends in C#");
        Console.Write("Select an option: ");
        int.TryParse(Console.ReadLine(), out int choice);

        switch (choice)
        {
            case 1:
                using (Resource resource = new Resource())
                {
                    resource.ResourceUsing();
                }
                Console.WriteLine("Resource disposed using 'using' statement.");
                break;
            case 2:
                DisposeC8();
                break;
            case 3:
                DisposeMultipleResourcesOld();
                break;
            case 4:
                DisposeMultipleResourcesC8();
                break;
            case 5:
                DisposeBeforeMethodEnds();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                goto LOOP;
        }

        Console.WriteLine("Do you want to continue? (y/n)");
        char.TryParse(Console.ReadLine(), out char continueChoice);
        if (continueChoice == 'y' || continueChoice == 'Y')
        {
            goto LOOP;
        }
    }
    static void DisposeC8()
    {
        using var resource = new Resource();
        resource.ResourceUsing();
        Console.WriteLine("Resource disposed using 'using' declaration.");
    }
    static void DisposeMultipleResourcesOld()
    {
        using (var resource1 = new Resource())
        {
            using (var resource2 = new Resource())
            {
                resource1.ResourceUsing();
                resource2.ResourceUsing();
            }
        }
        Console.WriteLine("Resources disposed using nested 'using' statements.");
    }
    static void DisposeMultipleResourcesC8()
    {
        using var resource1 = new Resource();
        using var resource2 = new Resource();
        resource1.ResourceUsing();
        resource2.ResourceUsing();
        Console.WriteLine("Resources disposed using 'using' declarations.");
    }
    static void DisposeBeforeMethodEnds()
    {
        using var resource = new Resource();
        resource.ResourceUsing();
        {
            using var resource2 = new Resource();
            resource2.ResourceUsing();
        }
        Console.WriteLine("Resource disposed before method ends.");
    }
}

class Resource : IDisposable
{
    public Resource()
    {
        Console.WriteLine("Resource acquired.");
    }
    public void ResourceUsing()
    {
        Console.WriteLine("Resource Using...");
    }
    public void Dispose()
    {
        Console.WriteLine("Resource disposed.");
    }
}