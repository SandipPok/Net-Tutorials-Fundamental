public class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Example to Understand Structure
2. Readonly Member of a Structure");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");
        switch (choice)
        {
            case 1:
                Rectangle rectangle = new Rectangle(10, 20);

                Console.WriteLine("Height: " + rectangle.Height);
                Console.WriteLine("Width: " + rectangle.Width);
                Console.WriteLine("Rectangle Area: " + rectangle.Area);
                Console.WriteLine("Rectangle: " + rectangle);
                break;
            case 2:
                RectangleReadOnly rro = new RectangleReadOnly(10, 20);

                Console.WriteLine("Height: " + rro.Height);
                Console.WriteLine("Width: " + rro.Width);
                Console.WriteLine("Rectangle Area: " + rro.Area);
                Console.WriteLine("Rectangle: " + rro);
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

public struct Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Area => (Height * Width);

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public override string ToString()
    {
        return $"Total area for height {Height} and width {Width} is {Area}";
    }
}

public readonly struct RectangleReadOnly
{
    public readonly double Height { get; }
    public readonly double Width { get; }
    public double Area => (Height * Width);

    public RectangleReadOnly(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public override string ToString()
    {
        return $"Total area for height {Height} and width {Width} is {Area}";
    }
}