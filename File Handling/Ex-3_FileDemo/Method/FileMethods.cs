using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        }
        public void Delete()
        {

        }
        public void Encrypt()
        {

        }
        public void Open()
        {

        }
        public void Move()
        {

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

        }
        public void OpenText()
        {

        }
        public void OpenWrite()
        {

        }
        public void ReadAllBytes()
        {

        }
        public void ReadAllLines()
        {

        }
        public void ReadAllText()
        {

        }
        public void ReadLines()
        {

        }
        public void Replace()
        {

        }
        public void WriteAllBytes()
        {

        }
        public void WriteAllLines()
        {

        }
        public void WriteAllText()
        {

        }
    }
}
