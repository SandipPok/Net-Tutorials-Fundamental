namespace Ex2_IndexersDemo.Model
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
    }

    class Company
    {
        private List<Employee> ListEmployees = new List<Employee>();

        public Company()
        {
            ListEmployees.Add(new Employee { EmployeeId = 110, Name = "Amit", Gender = "Male", Salary = 4500 });
            ListEmployees.Add(new Employee { EmployeeId = 111, Name = "Neha", Gender = "Female", Salary = 6800 });
            ListEmployees.Add(new Employee { EmployeeId = 112, Name = "Sita", Gender = "Female", Salary = 7500 });
            ListEmployees.Add(new Employee { EmployeeId = 113, Name = "Aarya", Gender = "Female", Salary = 3200 });
            ListEmployees.Add(new Employee { EmployeeId = 114, Name = "Jasmin", Gender = "Female", Salary = 5500 });
            ListEmployees.Add(new Employee { EmployeeId = 115, Name = "Aman", Gender = "Male", Salary = 8000 });
            ListEmployees.Add(new Employee { EmployeeId = 116, Name = "Alok", Gender = "Male", Salary = 5300 });
            ListEmployees.Add(new Employee { EmployeeId = 117, Name = "Sonia", Gender = "Female", Salary = 4100 });
            ListEmployees.Add(new Employee { EmployeeId = 118, Name = "Vishal", Gender = "Male", Salary = 6200 });
            ListEmployees.Add(new Employee { EmployeeId = 119, Name = "John", Gender = "Male", Salary = 8500 });
            ListEmployees.Add(new Employee { EmployeeId = 120, Name = "Emily", Gender = "Female", Salary = 7800 });
            ListEmployees.Add(new Employee { EmployeeId = 121, Name = "Michael", Gender = "Male", Salary = 9500 });
            ListEmployees.Add(new Employee { EmployeeId = 122, Name = "Sophia", Gender = "Female", Salary = 9000 });
            ListEmployees.Add(new Employee { EmployeeId = 123, Name = "David", Gender = "Male", Salary = 7500 });
            ListEmployees.Add(new Employee { EmployeeId = 124, Name = "Olivia", Gender = "Female", Salary = 6700 });
            ListEmployees.Add(new Employee { EmployeeId = 125, Name = "Liam", Gender = "Male", Salary = 8800 });
            ListEmployees.Add(new Employee { EmployeeId = 126, Name = "Mia", Gender = "Female", Salary = 6200 });
            ListEmployees.Add(new Employee { EmployeeId = 127, Name = "James", Gender = "Male", Salary = 5100 });
            ListEmployees.Add(new Employee { EmployeeId = 128, Name = "Charlotte", Gender = "Female", Salary = 7300 });
            ListEmployees.Add(new Employee { EmployeeId = 129, Name = "Lucas", Gender = "Male", Salary = 5400 });
            ListEmployees.Add(new Employee { EmployeeId = 130, Name = "Isabella", Gender = "Female", Salary = 7600 });
        }

        public string this[int employeeId]
        {
            get
            {
                return ListEmployees.FirstOrDefault(emp => emp.EmployeeId == employeeId).Name;
            }
            set
            {
                ListEmployees.FirstOrDefault(emp => emp.EmployeeId == employeeId).Name = value;
            }
        }
    }
}
