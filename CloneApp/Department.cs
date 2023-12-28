using System.Text;

namespace Clone
{
    [Serializable]
    public class Department : ICustomSerializable
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
        }

        public Department(string name)
        {
            DepartmentName = name;
            Employees = new List<Employee>();
        }
        public void SerializeCustom(Stream stream)
        {
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(DepartmentName);
                writer.Write(Employees.Count);

                foreach (var employee in Employees)
                {
                    employee.SerializeCustom(stream);
                }
            }
        }

        public T DeepClone<T>()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                SerializeCustom(stream);
                stream.Seek(0, SeekOrigin.Begin);

                // Use BinaryReader for reading from the stream
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Read DepartmentName
                    string name = reader.ReadString();

                    // Read the count of Employees
                    int employeeCount = reader.ReadInt32();

                    // Deserialize each Employee
                    List<Employee> employees = new List<Employee>();
                    for (int i = 0; i < employeeCount; i++)
                    {
                        // Corrected: Read EmployeeName and EmployeeId from the stream
                        string employeeName = reader.ReadString();
                        int employeeId = reader.ReadInt32();

                        // Create a new instance of Employee and add it to the list
                        employees.Add(new Employee { EmployeeName = employeeName, EmployeeId = employeeId });
                    }

                    return (T)Convert.ChangeType(new Department { DepartmentName = name, Employees = employees }, typeof(T));
                }
            }
        }
    }
}
