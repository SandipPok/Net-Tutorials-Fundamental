namespace Ex2_IndexersDemo.Model
{
    class EmployeeInt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }

        public EmployeeInt(int ID,
                           string Name,
                           string Job,
                           int Salary,
                           string Location,
                           string Department,
                           string Gender)
        {
            this.Id = ID;
            this.Name = Name;
            this.Job = Job;
            this.Salary = Salary;
            this.Location = Location;
            this.Department = Department;
            this.Gender = Gender;
        }

        public object this[int index]
        {
            get
            {
                if (index == 0)
                    return Id;
                else if (index == 1)
                    return Name;
                else if (index == 2)
                    return Job;
                else if (index == 3)
                    return Salary;
                else if (index == 4)
                    return Location;
                else if (index == 5)
                    return Department;
                else if (index == 6)
                    return Gender;
                else
                    return null;
            }
            set
            {
                if (index == 0)
                    Id = Convert.ToInt32(value);
                else if (index == 1)
                    Name = value.ToString();
                else if (index == 2)
                    Job = value.ToString();
                else if (index == 3)
                    Salary = Convert.ToDouble(value);
                else if (index == 4)
                    Location = value.ToString();
                else if (index == 5)
                    Department = value.ToString();
                else if (index == 6)
                    Gender = value.ToString();
            }
        }
    }

    class EmployeeString
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }

        public EmployeeString(int ID,
                           string Name,
                           string Job,
                           int Salary,
                           string Location,
                           string Department,
                           string Gender)
        {
            this.Id = ID;
            this.Name = Name;
            this.Job = Job;
            this.Salary = Salary;
            this.Location = Location;
            this.Department = Department;
            this.Gender = Gender;
        }

        public object this[string index]
        {
            get
            {
                if (index.ToUpper() == "ID")
                    return Id;
                else if (index.ToUpper() == "NAME")
                    return Name;
                else if (index.ToUpper() == "JOB")
                    return Job;
                else if (index.ToUpper() == "SALARY")
                    return Salary;
                else if (index.ToUpper() == "LOCATION")
                    return Location;
                else if (index.ToUpper() == "DEPARTMENT")
                    return Department;
                else if (index.ToUpper() == "GENDER")
                    return Gender;
                else
                    return null;
            }
            set
            {
                if (index.ToUpper() == "ID")
                    Id = Convert.ToInt32(value);
                else if (index.ToUpper() == "NAME")
                    Name = value.ToString();
                else if (index.ToUpper() == "JOB")
                    Job = value.ToString();
                else if (index.ToUpper() == "SALARY")
                    Salary = Convert.ToDouble(value);
                else if (index.ToUpper() == "LOCATION")
                    Location = value.ToString();
                else if (index.ToUpper() == "DEPARTMENT")
                    Department = value.ToString();
                else if (index.ToUpper() == "GENDER")
                    Gender = value.ToString();
            }
        }
    }

    class EmployeeOverloading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public EmployeeOverloading(int ID,
                           string Name,
                           string Job,
                           int Salary,
                           string Location,
                           string Department,
                           string Gender)
        {
            this.Id = ID;
            this.Name = Name;
            this.Job = Job;
            this.Salary = Salary;
            this.Location = Location;
            this.Department = Department;
            this.Gender = Gender;
        }

        public object this[int index]
        {
            get
            {
                if (index == 0)
                    return Id;
                else if (index == 1)
                    return Name;
                else if (index == 2)
                    return Job;
                else if (index == 3)
                    return Salary;
                else if (index == 4)
                    return Location;
                else if (index == 5)
                    return Department;
                else if (index == 6)
                    return Gender;
                else
                    return null;
            }
            set
            {
                if (index == 0)
                    Id = Convert.ToInt32(value);
                else if (index == 1)
                    Name = value.ToString();
                else if (index == 2)
                    Job = value.ToString();
                else if (index == 3)
                    Salary = Convert.ToDouble(value);
                else if (index == 4)
                    Location = value.ToString();
                else if (index == 5)
                    Department = value.ToString();
                else if (index == 6)
                    Gender = value.ToString();
            }
        }
        public object this[string index]
        {
            get
            {
                if (index.ToUpper() == "ID")
                    return Id;
                else if (index.ToUpper() == "NAME")
                    return Name;
                else if (index.ToUpper() == "JOB")
                    return Job;
                else if (index.ToUpper() == "SALARY")
                    return Salary;
                else if (index.ToUpper() == "LOCATION")
                    return Location;
                else if (index.ToUpper() == "DEPARTMENT")
                    return Department;
                else if (index.ToUpper() == "GENDER")
                    return Gender;
                else
                    return null;
            }
            set
            {
                if (index.ToUpper() == "ID")
                    Id = Convert.ToInt32(value);
                else if (index.ToUpper() == "NAME")
                    Name = value.ToString();
                else if (index.ToUpper() == "JOB")
                    Job = value.ToString();
                else if (index.ToUpper() == "SALARY")
                    Salary = Convert.ToDouble(value);
                else if (index.ToUpper() == "LOCATION")
                    Location = value.ToString();
                else if (index.ToUpper() == "DEPARTMENT")
                    Department = value.ToString();
                else if (index.ToUpper() == "GENDER")
                    Gender = value.ToString();
            }
        }
    }
}
