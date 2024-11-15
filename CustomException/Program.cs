namespace CustomNamespaceHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int Number1, Number2, Result;

            try
            {
                bool isNum;

                Console.WriteLine("Enter First Number:");
                var input1 = Console.ReadLine();

                isNum = int.TryParse(input1, out int res);

                if (input1 != null && isNum)
                {
                    Number1 = int.Parse(input1);
                }
                else
                {
                    throw new StringException();
                }

                Console.WriteLine("Enter Second Number:");
                var input2 = Console.ReadLine();

                isNum = int.TryParse(input2, out int second);

                if (input2 != null && isNum)
                {
                    Number2 = int.Parse(input2);

                    if (Number2 % 2 > 0)
                    {
                        throw new OddNumberException("Cannot divide number by odd number");
                    }
                }
                else
                {
                    throw new StringException();
                }


                Result = Number1 / Number2;
                Console.WriteLine("The output is " + Result);
            }
            catch (OddNumberException ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"HelpLink: {ex.HelpLink}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            catch (StringException ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"HelpLink: {ex.HelpLink}");
                Console.WriteLine($"Source: {ex.Source}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

            Console.WriteLine("End of the Program");
            Console.ReadKey();
        }
    }
}