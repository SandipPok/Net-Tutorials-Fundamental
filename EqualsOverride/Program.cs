using System;
using System.Security.Cryptography.X509Certificates;

namespace OverideEqual
{
    public class EqualOverride
    {
        public static void Main(string[] args)
        {
            Customer c1 = new Customer();
            c1.FirstName = "Don";
            c1.LastName = "Dai";

            Customer c2 = new Customer();
            c2.FirstName = "Don";
            c2.LastName = "Dai";

            var hashCode1 = c1.GetHashCode();
            var hashCode2 = c2.GetHashCode();

            Console.WriteLine($"C1.GetHashCode == C2.GetHashCode: {hashCode1 == hashCode2}");

            Console.WriteLine($"C1 == C2: {c1 == c2}");
            Console.WriteLine($"C1.Equals(c2) == C2: {c1.Equals(c2)}");
        }
    }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (!(obj is Customer)) return false;

            return ((this.FirstName == ((Customer)obj).FirstName) && (this.LastName == ((Customer)obj).LastName));
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }
    }
}