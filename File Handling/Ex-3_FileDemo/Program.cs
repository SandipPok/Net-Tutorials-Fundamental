using Ex_3_FileDemo.Method;

namespace FileDemo;

class Program
{
    static void Main(string[] args)
    {
        string path = @"D:\DotNet\Net Tutorials\File Handling\Ex-3_FileDemo\myFile.txt";
    LOOP:
        Console.WriteLine(@"1. Copy
2. Create
3. Decrypt
4. Delete
5. Encrypt
6. Open
7. Move
8. Exists
9. OpenRead
10. OpenText
11. OpenWrite
12. ReadAllBytes
13. ReadAllLines
14. ReadAllText
15. ReadLines
16. Replace
17. WriteAllBytes
18. WriteAllLines
19. WriteAllText");

        Console.Write("\nEnter the choice: ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine();
            FileMethods fm = new FileMethods(path);
            switch (choice)
            {
                case 1:
                    fm.Copy(@"D:\DotNet\Net Tutorials\File Handling\Ex-3_FileDemo\myFile-Copy.txt");
                    break;
                case 2:
                    fm.Create();
                    break;
                case 3:
                    fm.Decrypt();
                    break;
                case 4:
                    fm.Delete();
                    break;
                case 5:
                    fm.Encrypt();
                    break;
                case 6:
                    fm.Open();
                    break;
                case 7:
                    fm.Move(@"D:\DotNet\Net Tutorials\File Handling\Ex-3_FileDemo\Method\myFile.txt");
                    break;
                case 8:
                    fm.Exists();
                    break;
                case 9:
                    fm.OpenRead();
                    break;
                case 10:
                    fm.OpenText();
                    break;
                case 11:
                    fm.OpenWrite();
                    break;
                case 12:
                    fm.ReadAllBytes();
                    break;
                case 13:
                    fm.ReadAllLines();
                    break;
                case 14:
                    fm.ReadAllText();
                    break;
                case 15:
                    fm.ReadLines();
                    break;
                case 16:
                    fm.Replace(@"D:\DotNet\Net Tutorials\File Handling\Ex-3_FileDemo\myFile-Copy.txt");
                    break;
                case 17:
                    fm.WriteAllBytes();
                    break;
                case 18:
                    fm.WriteAllLines();
                    break;
                case 19:
                    fm.WriteAllText();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Do you want to continue? (y/n)");
            string? s = Console.ReadLine();

            if (s != null && (s[0] == 'y' || s[0] == 'Y'))
            {
                goto LOOP;
            }
        }
        else
        {
            Console.WriteLine("Enter the valid choice");
            goto LOOP;
        }
    }
}