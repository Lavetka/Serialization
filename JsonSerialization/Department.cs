using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace JsonSerialization
{
    [Serializable]
    public class Department
	{
        [JsonPropertyName("DepartmentName")]
        public string DepartmentName { get; set; }

        [JsonPropertyName("Employees")]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}

