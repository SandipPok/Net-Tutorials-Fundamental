class Program
{
    static void Main(string[] args)
    {
        List<int>? numberList = null;
        int? number = null;

        numberList ??= new List<int>();

        numberList.Add(number ??= 25);

        numberList.Add(number ??= 50);

        foreach (var item in numberList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n" + number);
    }
}