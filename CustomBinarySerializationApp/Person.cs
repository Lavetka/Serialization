using System.Runtime.Serialization;


namespace Binary
{
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("PersonName");
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PersonName", Name);
        }
    }
}
