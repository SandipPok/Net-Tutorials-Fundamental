using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Ex_3_FileDemo.Method
{
    internal class FileMethods
    {
        private readonly string Path;
        public FileMethods(string path)
        {
            Path = path;
        }
        public void Copy(string to)
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Copy(Path, to);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Create()
        {
            try
            {
                File.Create(Path);
                Console.WriteLine("File created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Decrypt()
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Decrypt(Path);
                    Console.WriteLine("File decrypted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Delete()
        {
            try
            {
                File.Delete(Path);
                Console.WriteLine("File Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Encrypt()
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Encrypt(Path);
                    Console.WriteLine("File encrypted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Open()
        {
            try
            {
                using (FileStream fs = File.Open(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    using (StreamReader reader = new StreamReader(fs, leaveOpen: true))
                    {
                        string content = reader.ReadToEnd();
                        Console.WriteLine(content);
                    }

                    fs.Seek(0, SeekOrigin.End);
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        Console.WriteLine("Enter the text to insert in file");
                        string? input = Console.ReadLine();
                        writer.WriteLine("\n" + input);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Move(string to)
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Move(Path, to);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Exists()
        {
            if (File.Exists(Path))
            {
                Console.WriteLine("File exists on a current directory");
            }
            else
            {
                Console.WriteLine("No file exists in the directory with the name");
            }
        }
        public void OpenRead()
        {
            try
            {
                using (FileStream fs = File.OpenRead(Path))
                {
                    byte[] data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);

                    Console.WriteLine("File content (in bytes):");
                    foreach (var b in data)
                    {
                        Console.Write(b + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void OpenText()
        {
            try
            {
                using (StreamReader reader = File.OpenText(Path))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("File content:");
                    Console.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void OpenWrite()
        {
            try
            {
                using (FileStream fs = File.OpenWrite(Path))
                {
                    byte[] content = new byte[] { 72, 101, 108, 108, 111 };
                    fs.Write(content, 0, content.Length);
                    Console.WriteLine("Content written to file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void ReadAllBytes()
        {
            try
            {
                if (File.Exists(Path))
                {
                    byte[] fileBytes = File.ReadAllBytes(Path);
                    Console.WriteLine(Encoding.UTF8.GetString(fileBytes));
                }
                else
                {
                    Console.WriteLine("MyFile.txt File Does Not Exist in current Directory");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void ReadAllLines()
        {
            try
            {
                if (File.Exists(Path))
                {
                    string[] lines = File.ReadAllLines(Path);

                    foreach (string line in lines)
                    {
                        Console.Write($"{line} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("MyFile.txt File Does Not Exist in current Directory");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void ReadAllText()
        {
            try
            {
                var data = File.ReadAllText(Path);

                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void ReadLines()
        {
            try
            {
                if (File.Exists(Path))
                {
                    var data = File.ReadLines(Path);

                    foreach (string item in data)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("File doesn't exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Replace(string to)
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Replace(Path, to, "myFile-backup.txt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void WriteAllBytes()
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes("This is written by WriteAllBytes which will override the files inside.");
                File.WriteAllBytes(Path, bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void WriteAllLines()
        {
            try
            {
                string[] strings = ["2002", "Annie", "Marry"];
                File.WriteAllLines(Path, strings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void WriteAllText()
        {
            try
            {
                Console.WriteLine("Enter the text to insert");
                string? input = Console.ReadLine();
                File.WriteAllText(Path, input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
    }
}
