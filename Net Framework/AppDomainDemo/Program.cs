using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace AppDomainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create a custom AssemblyLoadContext to isolate the third-party assembly
            var context = new CustomAssemblyLoadContext();

            try
            {
                // Step 2: Load the third-party assembly in the isolated context
                var thirdPartyAssembly = context.LoadFromAssemblyPath(Path.Combine(Environment.CurrentDirectory, "ThirdPartyLib.dll"));

                // Step 3: Get the type of the ThirdParty class from the isolated assembly
                var thirdPartyType = thirdPartyAssembly.GetType("ThirdPartyLib.ThirdParty");

                // Step 4: Create an instance of the ThirdParty class within the isolated context
                var thirdPartyInstance = Activator.CreateInstance(thirdPartyType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
            finally
            {
                // Step 5: Unload the custom AssemblyLoadContext (which will unload the assemblies)
                context.Unload();
            }

            Console.Read();
        }
    }

    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true) { }

        // Optionally override the Load method to handle assembly resolution
        protected override Assembly Load(AssemblyName assemblyName)
        {
            // Here you can handle missing assembly loading or block access to specific files
            return null;
        }
    }

    //public class ThirdParty
    //{
    //    public ThirdParty()
    //    {
    //        Console.WriteLine("Third Party DLL Loaded");

    //        // Attempt to create a file (which will be restricted or fail)
    //        try
    //        {
    //            File.Create(@"D:\xyz.txt");  // This should fail if permissions are restricted
    //        }
    //        catch (UnauthorizedAccessException)
    //        {
    //            Console.WriteLine("Access to D:\\ is not allowed.");
    //        }
    //    }

    //    ~ThirdParty()
    //    {
    //        Console.WriteLine("Third Party DLL Unloaded");
    //    }
    //}
}
