using Ex3_MapComplex_Type_To_Primitive_Type;
using Ex3_MapComplex_Type_To_Primitive_Type.Model;

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
            //Address = empAddres

            City = "Hongkong Pokhara",
            State = "Bagmati",
            Country = "Nepal"
        };

        var mapper = MapperConfig.InitializeAutoMapper();
        EmployeeDto empDto = mapper.Map<EmployeeDto>(emp);

        Console.WriteLine("Name:" + empDto.Name + ", Salary:" + empDto.Salary + ", Department:" + empDto.Department);
        //Console.WriteLine("City:" + empDto.City + ", State:" + empDto.State + ", Country:" + empDto.Country);
        Console.WriteLine("City:" + empDto.Address.City + ", State:" + empDto.Address.State + ", Country:" + empDto.Address.Country);
        Console.ReadLine();
    }
}