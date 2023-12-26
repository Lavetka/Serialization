using System.Xml.Serialization;

namespace XMLSerialization
{
    [Serializable]
    public class Employee
	{
        [XmlElement("Name")]
        public string EmployeeName { get; set; }
    }
}

