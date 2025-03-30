namespace ThirdPartyLib
{
    public class ThirdParty
    {
        public ThirdParty()
        {
            Console.WriteLine("Third Party DLL Loaded");

            // Try to create a file (this will be intercepted or blocked)
            try
            {
                // Attempt to create a file (e.g., "D:\xyz.txt")
                File.Create(@"D:\xyz.txt");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access to D:\\ is not allowed.");
            }
        }

        ~ThirdParty()
        {
            Console.WriteLine("Third Party DLL Unloaded");
        }
    }
}
