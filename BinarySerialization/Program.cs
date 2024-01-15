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

            BinarySerialization.Serialize(department, "department.bin");

            Department deserializedDepartment = BinarySerialization.Deserialize<Department>("department.bin");

            Console.WriteLine($"Department Name: {deserializedDepartment.DepartmentName}");

            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine($"Employee Name: {employee.EmployeeName}");
            }
        }
    }
}
