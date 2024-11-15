using System;

namespace StringOverride
{
    public class StringOverrideDemo
    {
        public static void Main(string[] args)
        {
            User user = new User();

            user.FirstName = "Don";
            user.LastName = "Dai";

            Console.WriteLine(user.ToString());
        }
    }
}