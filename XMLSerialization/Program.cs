namespace XMLSerialization
{
    class Program
    {
        static void Main()
        {
            Department department = new Department
            {
                DepartmentName = "XmlDep"
            };

            // Add employees for demonstration
            department.Employees.Add(new Employee { EmployeeName = "xml1" });
            department.Employees.Add(new Employee { EmployeeName = "xml2" });
            department.Employees.Add(new Employee { EmployeeName = "xml3" });

            // XML Serialization
            XmlSerialization.Serialize(department, "department.xml");

            // Deserialize the entire department
            Department deserializedDepartment = XmlSerialization.Deserialize("department.xml");

            Console.WriteLine($"Department Name: {deserializedDepartment.DepartmentName}");

            // Get and print each employee separately
            foreach (var employee in deserializedDepartment.Employees)
            {
                Console.WriteLine($"Employee Name: {employee.EmployeeName}");
            }
        }
    }
}