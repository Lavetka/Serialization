using System.Text.Json;

namespace JsonSerialization
{
    class Program
    {
        static void Main()
        {
            Department department = new Department
            {
                DepartmentName = "JsonDep"
            };

            // Add employees for demonstration
            department.Employees.Add(new Employee { EmployeeName = "HlebJson1" });
            department.Employees.Add(new Employee { EmployeeName = "HlebJson2" });

            // JSON Serialization
            JsonSerialization.Serialize(department, "department.json");

            // Deserialize the entire department
            Department deserializedDepartment = JsonSerialization.Deserialize("department.json");

            Console.WriteLine($"Department Name: {deserializedDepartment.DepartmentName}");

            // Get and print each employee separately
            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine($"Employee Name: {employee.EmployeeName}");

            }

            Employee empl = new Employee
            {
                EmployeeName = "Hlebster"
            };
            string jsonString = JsonSerializer.Serialize(empl);
            Console.WriteLine(jsonString);
        }
    }
}