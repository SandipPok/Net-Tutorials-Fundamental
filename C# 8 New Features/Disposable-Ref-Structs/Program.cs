class Program
{
    static void Main(string[] args)
    {
        using var rect = new Rectangle(10, 20);
        Console.WriteLine($"Area of Rectangle: {rect.GetArea()}");
        Console.WriteLine("Exiting Main method");
    }
}
ref struct Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }
    public double GetArea() => Height * Width;
    public void Dispose() => Console.WriteLine("Dispose method called");
}