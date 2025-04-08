public class Program
{
    static async Task Main(string[] args)
    {
        List<string> countries = new List<string>()
        {
            "NEPAL",
            "INDIA",
            "CHINA",
            "USA",
            "UK",
            "NZ",
            "CANADA",
            "RUSSIA",
            "SRILANKA",
            "INDONESIA"
        };
        Console.WriteLine($"Element at Index Position 1 is {countries[1]}");
        Console.WriteLine($"Element at Index Position 3 is {countries[3]}");

        Console.WriteLine($"\nElement at Last Position is {countries[^1]}");
        Console.WriteLine($"Element at Third Last Position is {countries[^3]}\n");

        // Range Example
        var subCountries = countries[1..4];
        foreach (var country in subCountries)
        {
            Console.WriteLine(country);
        }

        Console.WriteLine("\nAccessing Range of Elements using Range");
        List<string> countryRange = countries.GetRange(1, 3);

        foreach (var item in countryRange)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("");

    }
}