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
        public void Copy()
        {
            try
            {

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
        public void Move()
        {
            try
            {

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

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
        public void Replace()
        {
            try
            {

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

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
    }
}
