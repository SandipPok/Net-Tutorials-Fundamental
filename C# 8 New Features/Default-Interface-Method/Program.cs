public class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Example to Understand Default Interface Methods
2. Difference between Interface and Abstract Method
3. Modifiers with Default Interface Methods
4. Real-Time Example of Interface with Default Method Implementation");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");
        switch (choice)
        {
            case 1:
                IDefaultInterfaceMethod ii = new InterfaceImplementation();
                ii.DefaultMethod();
                break;
            case 2:
                InterfaceImplementation interfaceAbstract = new InterfaceImplementation();
                interfaceAbstract.DefaultMethod();
                break;
            case 3:
                IDefaultInterfaceMethod2 iDefaultInterfaceMethod2 = new InterfaceImplementation2();
                iDefaultInterfaceMethod2.DefaultMethod();

                IOverrideDefaultInterfaceMethod overrideDefault = new InterfaceImplementation2();
                overrideDefault.DefaultMethod();
                break;
            case 4:
                ILogger consoleLogger = new ConsoleLogger();
                consoleLogger.WriteWarning("This is a warning message.");
                consoleLogger.WriteInfo("This is an info message.");
                consoleLogger.WriteError("This is an error message.");
                Console.WriteLine("");

                ILogger traceLogger = new TraceLogger();
                traceLogger.WriteWarning("Trace Logger Warning Message.");
                traceLogger.WriteInfo("Trace Logger Information Message");
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

interface IDefaultInterfaceMethod
{
    // Default interface method
    public void DefaultMethod()
    {
        Console.WriteLine("Default Interface Method");
    }
}

public abstract class DefaultAbstractClassMethod
{
    public void DefaultMethod()
    {
        Console.WriteLine("I am a default method in the Abstract Class!");
    }
}

class InterfaceImplementation : DefaultAbstractClassMethod, IDefaultInterfaceMethod
{
}

interface IDefaultInterfaceMethod2
{
    // Default interface method
    virtual void DefaultMethod()
    {
        Console.WriteLine("Default Interface Method");
    }
    public abstract void Sum();
}

interface IOverrideDefaultInterfaceMethod : IDefaultInterfaceMethod2
{
    void IDefaultInterfaceMethod2.DefaultMethod()
    {
        Console.WriteLine("Overridden default method");
    }
}

class InterfaceImplementation2 : IOverrideDefaultInterfaceMethod, IDefaultInterfaceMethod2
{
    public void Sum()
    {

    }
}

enum LogLevel
{
    Info,
    Warning,
    Error
}

interface ILogger
{
    void WriteMessage(LogLevel level, string message);

    void WriteInfo(string message)
    {
        WriteMessage(LogLevel.Info, message);
    }
    void WriteWarning(string message)
    {
        WriteMessage(LogLevel.Warning, message);
    }
    void WriteError(string message)
    {
        WriteMessage(LogLevel.Error, message);
    }
}

class ConsoleLogger : ILogger
{
    public void WriteMessage(LogLevel level, string message)
    {
        Console.WriteLine($"{level}: {message}");
    }
}
class TraceLogger : ILogger
{
    public void WriteMessage(LogLevel level, string message)
    {
        // Implementation for tracing messages
        Console.WriteLine($"Trace - {level}: {message}");
    }
}