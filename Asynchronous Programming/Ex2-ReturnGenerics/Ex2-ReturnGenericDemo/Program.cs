
namespace ReturnGenericDemo;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Main Method Started...");
        Console.WriteLine("Enter the Name: ");
        string name = Console.ReadLine() ?? "Ram";

        SomeMethod(name);

        Console.WriteLine("Main Method End");
        Console.ReadKey();
    }

    public async static void SomeMethod(string name)
    {
        Console.WriteLine("Some Method Started....");

        try
        {
            var greetingMessage = await Greetings(name);
            Console.WriteLine($"\n{greetingMessage}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError Occurred. {ex.Message}");
        }
        Console.WriteLine("Some Method End");
    }

    private static async Task<string> Greetings(string name)
    {
        string message = string.Empty;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5020");

            HttpResponseMessage res = await client.GetAsync($"/greetings?name={name}");
            message = await res.Content.ReadAsStringAsync();
        }
        return message;
    }
}