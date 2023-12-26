namespace BinarySerialization
{
    class Program
    {
        static void Main()
        {
            Department department = new Department
            {
                DepartmentName = "HLDepartment"
            };

            department.Employees.Add(new Employee { EmployeeName = "Hleb1" });
            department.Employees.Add(new Employee { EmployeeName = "Hleb2" });

            // Binary Serialization
            BinarySerialization.Serialize(department, "department.bin");

            // Deserialize the entire department
            Department deserializedDepartment = BinarySerialization.Deserialize("department.bin");

            Console.WriteLine($"Department Name: {deserializedDepartment.DepartmentName}");

            // Get and print each employee separately
            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine($"Employee Name: {employee.EmployeeName}");
            }
        }
    }
}

