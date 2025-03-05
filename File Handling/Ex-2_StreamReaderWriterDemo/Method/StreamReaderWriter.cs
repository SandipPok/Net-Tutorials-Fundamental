using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReaderWriterDemo.Method
{
    internal class StreamReaderWriter
    {
        private readonly string FilePath;

        public StreamReaderWriter(string filePath)
        {
            FilePath = filePath;
        }

        public void Write()
        {
            StreamWriter sw = new StreamWriter(FilePath);
            Console.WriteLine("Enter the text that you want to write: ");
            string? input = Console.ReadLine();

            sw.Write(input);

            sw.Flush();
            sw.Close();

            Console.WriteLine("File Created Successfully");
        }

        public void WriteLine()
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {

                Console.WriteLine("Enter the text that you want to write: ");
                string? input = Console.ReadLine();

                sw.WriteLine(input);
            }

            Console.WriteLine("File Created Successfully");
        }

        public void Open()
        {
            using (StreamReader sr = new StreamReader(FilePath))
            {
                var text = sr.ReadToEnd();
                Console.WriteLine(text);
            }
        }
    }
}
