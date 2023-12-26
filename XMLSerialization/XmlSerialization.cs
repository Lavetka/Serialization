using System;
using System.Xml.Serialization;

namespace XMLSerialization
{
    public static class XmlSerialization
    {
        public static void Serialize(Department department, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Department));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, department);
            }
        }

        public static Department? Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Department));
            using (TextReader reader = new StreamReader(fileName))
            {
                return serializer.Deserialize(reader) as Department;
            }
        }
    }
}

