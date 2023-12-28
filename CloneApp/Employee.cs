using System.Text;

namespace Clone
{
    [Serializable]
    public class Employee : ICustomSerializable
    {
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }

        public Employee(string name, int id)
        {
            EmployeeName = name;
            EmployeeId = id;
        }

        public Employee()
        {
        }

        public void SerializeCustom(Stream stream)
        {
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(EmployeeName ?? string.Empty);
                writer.Write(EmployeeId);
            }
        }

        public T DeepClone<T>()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                SerializeCustom(stream);
                stream.Seek(0, SeekOrigin.Begin);

                using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    string name = reader.ReadString();
                    int id = reader.ReadInt32();
                    return (T)Convert.ChangeType(new Employee { EmployeeName = name, EmployeeId = id }, typeof(T));
                }
            }
        }
    }
}

