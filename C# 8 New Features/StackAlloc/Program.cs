class Program
{
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Example to Understand stackalloc Before C# 7.2
2. Example to Understand stackalloc Before C# 7.2 without unsafe
3. Example to Understand stackalloc in C# 7.3
4. Example to Understand stackalloc in C# 7.3 without unsafe
5. Example to Understand stackalloc in C# 8");

        Console.Write("\nEnter the choices: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");

        switch (choice)
        {
            case 1:
                unsafe
                {
                    int* ptr = stackalloc int[10];

                    for (int i = 0; i < 10; i++)
                    {
                        ptr[i] = i + 1;
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write($"{ptr[i]} ");
                    }
                    Console.WriteLine("");
                }
                break;
            case 2:
                Span<int> ptr1 = stackalloc int[10];

                for (int i = 0; i < 10; i++)
                {
                    ptr1[i] = i + 1;
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"{ptr1[i]} ");
                }
                Console.WriteLine();
                break;
            case 3:
                unsafe
                {
                    int* ptr2 = stackalloc int[5] { 1, 4, 9, 16, 25 };

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write($"{ptr2[i]} ");
                    }
                    Console.WriteLine();
                    int* ptr3 = stackalloc int[] { 1, 2, 4, 8 };

                    for (int i = 0; i < 4; i++)
                    {
                        Console.Write($"{ptr3[i]} ");
                    }
                    Console.WriteLine();
                }
                break;
            case 4:
                Span<int> ptr4 = stackalloc int[5] { 1, 4, 9, 16, 25 };
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{ptr4[i]} ");
                }
                Console.WriteLine();
                Span<int> ptr5 = stackalloc int[] { 1, 2, 4, 8 };
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"{ptr5[i]} ");
                }
                Console.WriteLine();
                break;
            case 5:
                Span<int> numbers = stackalloc int[] { 10, 20, 30, 40, 50, 60, 70, 80, 80, 100 };

                var index = numbers.IndexOfAny(stackalloc[] { 11, 40, 60, 100 });
                Console.WriteLine(index);

                Span<int> set = stackalloc int[6] { 1, 2, 3, 4, 5, 6 };

                Span<int> subSet = set.Slice(3, 2);
                foreach (var n in subSet)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        Console.Write("\nDo you want to run again? ");

        char.TryParse(Console.ReadLine(), out char c);

        if (c == 'y')
        {
            goto LOOP;
        }
    }
}