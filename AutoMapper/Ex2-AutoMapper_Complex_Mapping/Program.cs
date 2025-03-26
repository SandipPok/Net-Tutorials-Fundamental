using Ex2_AutoMapper_Complex_Mapping;
using Ex2_AutoMapper_Complex_Mapping.Model;

class Program
{
    static void Main(string[] args)
    {
        Address empAddres = new Address()
        {
            City = "Hongkong Pokhara",
            State = "Bagmati",
            Country = "Nepal"
        };

        Employee emp = new Employee
        {
            Name = "James",
            Salary = 20000,
            Department = "IT",
            Address = empAddres
        };

        var mapper = MapperConfig.InitializeAutoMapper();

        var empDto = mapper.Map<EmployeeDto>(emp);

        Console.WriteLine("Name:" + empDto.Name + ", Salary:" + empDto.Salary + ", Department:" + empDto.Department);
        Console.WriteLine("City:" + empDto.AddressDto.EmpCity + ", State:" + empDto.AddressDto.EmpState + ", Country:" + empDto.AddressDto.Country);
        Console.ReadLine();
    }
}