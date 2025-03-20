namespace ValueTaskDemo
{
    class Program
    {
        public static Dictionary<int, string> CardDictionary = new Dictionary<int, string>(){
            {1001, "1001 Card Info"},
            {1002, "1002 Card Info"},
            {1003, "1003 Card Info"},
            {1004, "1004 Card Info"},
        };
        static void Main(string[] args)
        {
            var card1001Result = GetCreditCard(1001);
            Console.WriteLine(card1001Result);

            var card1002Result = GetCreditCard(1002);
            Console.WriteLine(card1002Result);

            var card1003Result = GetCreditCard(1003);
            Console.WriteLine(card1003Result);

            var card1006 = GetCreditCard(1006);
            Console.WriteLine(card1006);
            Console.ReadKey();
        }

        public static async ValueTask<string> GetCreditCard(int id)
        {
            if (CardDictionary.ContainsKey(id))
            {
                return CardDictionary[id];
            }

            var card = $"Card Info - {id} from Database";
            CardDictionary[id] = card;
            return await Task.FromResult(card);
        }
    }
}