using AutoMapperDemo;
using AutoMapperDemo.Models;

class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Employee()
        {
            Name = "John",
            Salary = 20000,
            Address = "London",
            Department = "IT"
        };

        var mapper = MapperConfig.InitializeAutomapper();

        var empDto = mapper.Map<EmployeeDTO>(emp);
        Console.WriteLine("Name: " + empDto.FullName + ", Salary: " + empDto.Salary + ", Address: " + empDto.Address + ", Department: " + empDto.Department);
        Console.ReadLine();
    }
}