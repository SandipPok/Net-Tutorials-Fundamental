using System.Diagnostics.Metrics;
using System;
using System.Drawing;

public class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Pattern Matching in switch case
2. Real-time Example to Understand Switch Expression
3. Property Patterns
4. Real-Time Example of Property Pattern
5. Tuple Patterns
6. Realtime Example to Understand Tuple Pattern
7. Example to Understand Positional Patterns
8. Realtime Example to Understand Positional Patterns");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");
        switch (choice)
        {
            case 1:
                Console.Write("Enter days: ");
                string day = Console.ReadLine() ?? "";
                var message = day.ToUpper() switch
                {
                    "SUNDAY" => "Weekend",
                    "MONDAY" => "Start of the weekday",
                    "FRIDAY" => "End of weekday",
                    _ => "Invalid day"
                };
                Console.WriteLine($"{day} is {message}");
                break;
            case 2:
                var direction = Direction.Up;
                Console.WriteLine($"Map view direction is {direction}");

                Orientation? orientation = direction switch
                {
                    Direction.Up => Orientation.North,
                    Direction.Down => Orientation.South,
                    Direction.Right => Orientation.East,
                    Direction.Left => Orientation.West,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}")
                };

                Console.WriteLine($"Cardinal Orientation is {orientation}");
                break;
            case 3:
                Rectangle rect = new Rectangle { Length = 5, Height = 10 };

                if (rect is Rectangle { Length: 5, Height: 10 } specificRectangle)
                {
                    Console.WriteLine($"Rectangle Length: {specificRectangle.Length} and Height: {specificRectangle.Height}");
                }
                else
                {
                    Console.WriteLine($"Rectangle doesn't has specific height and width as mention");
                }
                break;
            case 4:
                double salePrice = 100;
                Address address = new Address { State = "Bagmati" };
                var salesTax = address switch
                {
                    { State: "Bagmati" } => salePrice * 0.05,
                    { State: "Madhesh" } => salePrice * 0.10,
                    { State: "Koshi" } => salePrice * 0.15,
                    _ => 0
                };
                Console.WriteLine($"State: {address.State}, salePrice: {salePrice}, and salesTax: {salesTax}");
                break;
            case 5:
                string game1 = "Cricket", game2 = "Football", game3 = "Hockey";

                var result = (game1, game2, game3) switch
                {
                    ("Cricket", "Football", "Hockey") => "I like Cricket, Football and Hockey.",
                    ("Cricket", "Football", "Swimming") => "I like Cricket, Football and Swimming.",
                    ("Cricket", "Football", "Baseball") => "I like Cricket, Football and Baseball.",
                    ("Table Tennis", "Football", "Swimming") => "I like Table Tennis, Football and Swimming.",
                    (_, _, _) => "No games are played"
                };
                Console.WriteLine(result);
                break;
            case 6:
                CustomerOrder order1 = new CustomerOrder()
                {
                    PaymentMethod = PaymentMethods.CreditCard,
                    Country = "USA",
                    Amount = 1000
                };
                CustomerOrder order2 = new CustomerOrder()
                {
                    PaymentMethod = PaymentMethods.WireTransfer,
                    Country = "UK",
                    Amount = 3000
                };
                Console.WriteLine($"Country: {order1.Country}, Payment Method : {order1.PaymentMethod}, Order Discount : {GetOrderDiscount(order1)}");
                Console.WriteLine($"Country: {order2.Country}, Payment Method : {order2.PaymentMethod}, Order Discount : {GetOrderDiscount(order2)}");
                break;
            case 7:
                Rectangle rect1 = new Rectangle { Length = 20, Height = 40 };
                var (length, height) = rect1;
                Console.WriteLine($"The rectangle Length: {length} and Height: {height}");
                if (rect1 is (20, _))
                {
                    Console.WriteLine("The rectangle has a length of 20");
                }
                break;
            case 8:
                Customer customer = new Customer()
                {
                    FirstName = "Sam",
                    LastName = "Taylor",
                    Email = "info@test.com",
                    CustomerAddress = new AddressPositional() { PostalCode = 755019, Street = "Newyork", Country = "USA" }
                };
                Console.WriteLine($"Is Free Shipping Eligible: {IsFreeShippingEligible(customer)}");
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
        Console.WriteLine("\nDo you want to continue? (y/n)");
        char.TryParse(Console.ReadLine(), out char res);

        if (res == 'y')
        {
            goto LOOP;
        }
    }
    /// <summary>

    /// We need to write a program that should determine 
    /// discounts based on the following conditions

    /// If the order is paid by Credit Card and the country
    /// is UK then return 20 to apply 20 percent discounts.
    /// If the order is paid by Wire Transfer and the country is the USA 
    /// then return 15 to apply 15 percent of discount

    /// if the order amount is greater than 5000 return 10 to apply a 10 percent discount
    /// otherwise return 0 for 0 percentage

    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    static int GetOrderDiscount(CustomerOrder order)
    {
        return (order.PaymentMethod, order.Country) switch
        {
            (PaymentMethods.CreditCard, "USA") => 15,
            (PaymentMethods.CreditCard, "UK") => 20,
            (_, _) when order.Amount > 5000 => 10,
            _ => 0
        };
    }

    static bool IsFreeShippingEligible(Customer customer)
    {
        return customer is Customer(_, _, _, (_, _, "USA"));
    }
}

public enum Direction
{
    Up,
    Down,
    Right,
    Left
}
public enum Orientation
{
    North,
    South,
    East,
    West
}
public class Rectangle
{
    public double Length { get; set; }
    public double Height { get; set; }
    public void Deconstruct(out double length, out double height)
    {
        length = Length;
        height = Height;
    }
}
public class Address
{
    public string State { get; set; }
}
public class CustomerOrder
{
    public PaymentMethods PaymentMethod { get; set; }
    public string Country { get; set; }
    public double Amount { get; set; }
}
public enum PaymentMethods
{
    CreditCard,
    WireTransfer
}
public class  AddressPositional
{
    public int PostalCode { get; set; }
    public string Street { get; set; }
    public string Country { get; set; } 
    public void Deconstruct(out int postalCode, out string street, out string country)
    {
        postalCode = PostalCode;
        street = Street;
        country = Country;
    }
}
public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public AddressPositional CustomerAddress { get; set; }
    //Deconstruct for Customer  
    public void Deconstruct(out string firstname, out string lastname, out string email, out AddressPositional address)
    {
        firstname = FirstName;
        lastname = LastName;
        email = Email;
        address = CustomerAddress;
    }
}