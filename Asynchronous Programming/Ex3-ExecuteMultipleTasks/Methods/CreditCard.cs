using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3_ExecuteMultipleTasks.Methods
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public static List<CreditCard> GenerateCreditCards(int number)
        {
            List<CreditCard> creditCards = new List<CreditCard>();

            for (int i = 0; i < number; i++)
            {
                creditCards.Add(new CreditCard
                {
                    CardNumber = "10000000" + i,
                    Name = "CreditCard-" + i
                });
            }

            return creditCards;
        }
    }
}
