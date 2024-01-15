using System.Runtime.Serialization.Formatters.Binary;


namespace BinarySerialization
{
    public static class BinarySerialization
    {
        public static void Serialize<T>(T obj, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(stream, obj);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}

