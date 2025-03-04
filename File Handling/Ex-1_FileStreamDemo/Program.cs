using Ex_1_FileStreamDemo.Method;
using System.Reflection.Emit;

namespace FileStreamDemo;

class Program
{
    public static void Main(string[] args)
    {
        string path = @"D:\DotNet\Net Tutorials\File Handling\Ex-1_FileStreamDemo\myFile.txt";
        Console.WriteLine("Select the operation to perform");
    TOP:
        Console.WriteLine(@"
1. CreateNew
2. Create
3. Open
4. OpenOrCreate
5. Append
");

        int val = Convert.ToInt16(Console.ReadLine());

        FileSteamsMethods method = new FileSteamsMethods(path);

        switch (val)
        {
            case 1:
                method.CreateNew();
                break;
            case 2:
                method.Create();
                break;
            case 3:
                method.Open();
                break;
            case 4:
                method.OpenOrCreate();
                break;
            case 5:
                method.Append();
                break;
            default:
                Console.WriteLine("Enter the valid number");
                break;
        }
        Console.WriteLine("Do you want to continue (y or press any key) ? \n");

        char ans = Convert.ToChar(Console.ReadLine());

        if (ans == 'y' || ans == 'Y')
            goto TOP;
    }
}