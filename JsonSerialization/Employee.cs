using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace JsonSerialization
{
    [Serializable]
	public class Employee
	{
        [JsonPropertyName("Name")]
        public string EmployeeName { get; set; }
    }
}

