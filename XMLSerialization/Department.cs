
using System.Xml.Serialization;

namespace XMLSerialization
{
    [Serializable]
    public class Department
	{
        [XmlAttribute("DepartmentName")]
        public string DepartmentName { get; set; }

        [XmlElement("Employees")]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}

