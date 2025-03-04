using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1_FileStreamDemo.Method
{
    internal class FileSteamsMethods
    {
        private readonly string FilePath = "";
        public FileSteamsMethods(string filePath)
        {
            FilePath = filePath;
        }

        public void CreateNew()
        {
            try
            {
                // User to create a new file.
                // If already exists it throws exception.
                FileStream file = new FileStream(FilePath, FileMode.CreateNew, FileAccess.Write);
                file.Close();
                Console.WriteLine("File Created successfully");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Create()
        {
            try
            {
                // User to create a new file.
                // If already exists it replace.
                FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
                file.Close();
                Console.WriteLine("File Created Successfully");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Open()
        {
            try
            {
                // It will open the file
                // if not found throws error
                FileStream file = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

                string data;

                using (StreamReader sr = new StreamReader(file))
                {
                    data = sr.ReadToEnd();
                }

                file.Close();

                Console.WriteLine("The content in the file is:\n" + data);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void OpenOrCreate()
        {
            try
            {
                FileStream file = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read);

                string data;

                using (StreamReader sr = new StreamReader(file))
                {
                    data = sr.ReadToEnd();
                }

                file.Close();

                Console.WriteLine("The content in the file is:\n" + data);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Append()
        {
            try
            {
                FileStream file = new FileStream(FilePath, FileMode.Append, FileAccess.Write);

                byte[] data = Encoding.Default.GetBytes("This is the file created by Sandip Pokharel");

                file.Write(data, 0, data.Length);

                file.Close();
                Console.WriteLine("Successfully saved file with data");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
