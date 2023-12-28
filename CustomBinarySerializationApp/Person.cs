using System.Runtime.Serialization;


namespace Binary
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Custom binary serialization method
        public void SerializeCustom(FileStream stream)
        {
            // Convert string to bytes and write to the stream
            byte[] nameBytes = System.Text.Encoding.UTF8.GetBytes(Name);
            stream.Write(BitConverter.GetBytes(nameBytes.Length), 0, sizeof(int));
            stream.Write(nameBytes, 0, nameBytes.Length);

            // Write age to the stream
            stream.Write(BitConverter.GetBytes(Age), 0, sizeof(int));
        }

        // Custom binary deserialization method
        public static Person DeserializeCustom(FileStream stream)
        {
            // Read length of the name from the stream
            byte[] lengthBytes = new byte[sizeof(int)];
            stream.Read(lengthBytes, 0, lengthBytes.Length);
            int nameLength = BitConverter.ToInt32(lengthBytes, 0);

            // Read name bytes from the stream
            byte[] nameBytes = new byte[nameLength];
            stream.Read(nameBytes, 0, nameBytes.Length);
            string name = System.Text.Encoding.UTF8.GetString(nameBytes);

            // Read age from the stream
            byte[] ageBytes = new byte[sizeof(int)];
            stream.Read(ageBytes, 0, ageBytes.Length);
            int age = BitConverter.ToInt32(ageBytes, 0);

            return new Person { Name = name, Age = age };
        }
    }
}
