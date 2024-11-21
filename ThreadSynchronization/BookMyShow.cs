using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSynchronization
{
    internal class BookMyShow
    {
        private object lockObject = new object();

        int availableTickets = 3;
        static int I = 1, J = 2, K = 3;

        public void BookTicket(string name, int wantedTickets)
        {
            lock (lockObject)
            {
                if (wantedTickets <= availableTickets)
                {
                    Console.WriteLine(wantedTickets + " booked to " + name);
                    availableTickets -= wantedTickets;
                }
                else
                {
                    Console.WriteLine("No tickets available to book");
                }
            }
        }
        public void TicketBooking()
        {
            string name = Thread.CurrentThread.Name;

            if (name.Equals("Thread 1"))
            {
                BookTicket(name, I);
            }
            else if (name.Equals("Thread 2"))
            {
                BookTicket(name, J);
            }
            else
            {
                BookTicket(name, K);
            }
        }
    }
}
