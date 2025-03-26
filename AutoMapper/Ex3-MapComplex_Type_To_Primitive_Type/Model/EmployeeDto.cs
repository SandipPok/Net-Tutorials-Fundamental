namespace Ex3_MapComplex_Type_To_Primitive_Type.Model
{
    class EmployeeDto
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }

        //public string City { get; set; }
        //public string State { get; set; }
        //public string Country { get; set; }

        public Address Address { get; set; }
    }
}
