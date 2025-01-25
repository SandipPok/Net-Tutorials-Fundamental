using System.Security.Cryptography.X509Certificates;

namespace AnnonymousMethodDemo
{
    public class Program
    {
        public static bool IsEmployeeExist(Employee Emp)
        {
            return Emp.ID == 103;
        }
        public static void Main(string[] args)
        {
            //Predicate<Employee> employeePredicate = new Predicate<Employee>(IsEmployeeExist);

            List<Employee> listEmployees = new List<Employee>
            {
                new Employee{ ID = 101, Name = "Don Dai", Gender= "Male", Salary = 10000242},
                new Employee{ ID = 102, Name = "Dai Don", Gender= "Male", Salary = 100657450},
                new Employee{ ID = 103, Name = "John Doe", Gender= "Male", Salary = 10063700},
                new Employee{ ID = 104, Name = "Emily Willis", Gender= "Female", Salary = 10156000},
                new Employee{ ID = 105, Name = "Dani Daniels", Gender= "Feale", Salary = 100234000},
            };

            //Employee employee = listEmployees.Find(x => employeePredicate(x));

            Employee employee = listEmployees.Find(
                delegate (Employee x)
                {
                    return x.ID == 103;
                }
             );

            Console.WriteLine(@"ID : {0}, Name : {1}, Gender : {2}, Salary : {3}", employee.ID, employee.Name, employee.Gender, employee.Salary);
            Console.ReadKey();
        }
    }
}