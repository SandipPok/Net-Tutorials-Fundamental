class Program
{
    static void Main(string[] args)
    {
        DisplaySize<Cords<int>>();
        DisplaySize<Cords<double>>();

        Span<Cords<int>> bars = stackalloc[]
        {
            new Cords<int> { _x = 1, _y = 2 },
            new Cords<int> { _x = 3, _y = 4 },
            new Cords<int> { _x = 5, _y = 6 }
        };
        Console.WriteLine("");
        foreach (var bar in bars)
        {
            Console.WriteLine($"x: {bar._x}, y: {bar._y}");
        }
    }

    private unsafe static void DisplaySize<T>() where T : unmanaged
    {
        Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
    }
}

struct Cords<T>
{
    public T _x;
    public T _y;
}