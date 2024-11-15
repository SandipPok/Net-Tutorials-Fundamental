using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomNamespaceHandling
{
    public class OddNumberException : Exception
    {
        //public override string Message
        //{
        //    get
        //    {
        //        return "Divisor Cannot be Odd Number";
        //    }
        //}

        //public override string? HelpLink
        //{
        //    get
        //    {
        //        return "https://www.google.com";
        //    }
        //}

        public OddNumberException()
        {

        }

        public OddNumberException(string message) : base(message)
        {

        }

        public OddNumberException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }

    public class StringException : Exception
    {
        public override string Message
        {
            get
            {
                return "Failed to parse as it requires number";
            }
        }
    }
}
