using Ex4_Reverse_Mapping;
using Ex4_Reverse_Mapping.Model;

class Program
{
    static void Main(string[] args)
    {
        var mapper = MapperConfig.InitializeMapper();

        Order orderRequest = CreateorderRequest();

        var orderDtoData = mapper.Map<Order, OrderDTO>(orderRequest);

        Console.WriteLine("After Mapping - OrderDTO Data");
        Console.WriteLine("OrderId : " + orderDtoData.OrderId);
        Console.WriteLine("NumberOfItems : " + orderDtoData.NumberOfItems);
        Console.WriteLine("TotalAmount : " + orderDtoData.TotalAmount);
        Console.WriteLine("CustomerId : " + orderDtoData.CustomerId);
        Console.WriteLine("Name : " + orderDtoData.Name);
        Console.WriteLine("Postcode : " + orderDtoData.Postcode);
        Console.WriteLine("MobileNo : " + orderDtoData.MobileNo);
        Console.WriteLine();

        orderDtoData.OrderId = 10;
        orderDtoData.NumberOfItems = 20;
        orderDtoData.TotalAmount = 2000;
        orderDtoData.CustomerId = 5;
        orderDtoData.Name = "Smith";
        orderDtoData.Postcode = "12345";

        mapper.Map(orderDtoData, orderRequest);

        Console.WriteLine("After Reverse Mapping - Order Data");
        Console.WriteLine("OrderNo : " + orderRequest.OrderNo);
        Console.WriteLine("NumberOfItems : " + orderRequest.NumberOfItems);
        Console.WriteLine("TotalAmount : " + orderRequest.TotalAmount);
        Console.WriteLine("CustomerId : " + orderRequest.Customer.CustomerID);
        Console.WriteLine("FullName : " + orderRequest.Customer.FullName);
        Console.WriteLine("Postcode : " + orderRequest.Customer.Postcode);
        Console.WriteLine("ContactNo : " + orderRequest.Customer.ContactNo);
        Console.ReadLine();
    }
    private static Order CreateorderRequest()
    {
        return new Order
        {
            OrderNo = 101,
            NumberOfItems = 3,
            TotalAmount = 1000,
            Customer = new Customer()
            {
                CustomerID = 777,
                FullName = "James Smith",
                Postcode = "755019",
                ContactNo = "1234567890"
            },
        };
    }
}