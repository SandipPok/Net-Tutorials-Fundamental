using System.CodeDom.Compiler;
using System.Text;

namespace TextReaderWriterDemo.Method
{
    internal class StringMethods
    {
        private readonly string Path;
        public StringMethods(string path)
        {
            Path = path;
        }

        public void IndentedTextWriter()
        {
            try
            {
                using (TextWriter sw = File.CreateText(Path))
                {
                    using (IndentedTextWriter writer = new IndentedTextWriter(sw, "    "))
                    {
                        writer.WriteLine("Hello, World!");
                        writer.Indent++;
                        writer.WriteLine("Indented Line 1");
                        writer.WriteLine("Indented Line 2");
                        writer.Indent--;
                        writer.WriteLine("Back to original indentation");
                    }
                }
                Console.WriteLine("Indented File created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }

        public void TextWriter()
        {
            try
            {
                using (TextWriter writer = File.CreateText(Path))
                {
                    writer.WriteLine("Hello TextWriter Abstract Class!");
                    writer.WriteLine("File Handling Tutorial in C#");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }

        public void TextReader()
        {
            try
            {
                using (TextReader textReader = File.OpenText(Path))
                {
                    Console.WriteLine(textReader.ReadLine());
                }
                //Read 4 Characters
                using (TextReader textReader = File.OpenText(Path))
                {
                    char[] ch = new char[4];
                    textReader.ReadBlock(ch, 0, 4);
                    Console.WriteLine(ch);
                }
                //Read full file
                using (TextReader textReader = File.OpenText(Path))
                {
                    Console.WriteLine(textReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed with error: {ex}");
            }
        }
    }
}
