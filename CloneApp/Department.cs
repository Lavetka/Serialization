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
            string jsonString = System.Text.Json.JsonSerializer.Serialize(this);
            return System.Text.Json.JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
