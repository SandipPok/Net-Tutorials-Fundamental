using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        Stack stack = new Stack();
        stack.Push(1);
        stack.Push("Hello");
        stack.Push(2f);
        stack.Push('a');
        stack.Push(null);

        Console.WriteLine("Total count: {0}", stack.Count);

        Console.WriteLine($"\nRemoved item is {stack.Pop()} and new count is {stack.Count}");
        Console.WriteLine($"Only return top item: {stack.Peek()} and new count is {stack.Count}");
        Console.WriteLine($"Is \"Hello\" present in stack: {stack.Contains("Hello")}");

        Stack newStack = (Stack)stack.Clone();
        stack.Clear();

        Console.WriteLine("\nOld stack has {0} items and new stack has {1} items", stack.Count, newStack.Count);

        object[] array = new object[newStack.Count];

        newStack.CopyTo(array, 0);

        Console.WriteLine("\nItems in 1D array are: ");
        foreach (object i in array)
        {
            Console.Write(i + "\t");
        }

        Console.ReadKey();
    }
}