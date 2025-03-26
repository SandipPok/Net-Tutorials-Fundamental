namespace Ex2_AutoMapper_Complex_Mapping.Model
{
    class EmployeeDto
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public AddressDto AddressDto { get; set; }
    }
    class AddressDto
    {
        public string EmpCity { get; set; }
        public string EmpState { get; set; }
        public string Country { get; set; }
    }
}
