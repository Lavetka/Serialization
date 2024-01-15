using BinarySerialization;

namespace Binary
{
    class Program
    {
        static void Main()
        {
            Person person = new Person
            {
                Name = "hLEB",
                Age = 28
            };

            SerializePerson(person, "person.dat");
            Person deserializedPerson = DeserializePerson("person.dat");
            Console.WriteLine($"Deserialized Person - Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
        }

        static void SerializePerson(Person person, string fileName)
        {
            BinarySerialization.BinarySerialization.Serialize(person, fileName);
            Console.WriteLine("Person serialized to binary file using standard serialization.");
        }

        static Person DeserializePerson(string fileName)
        {
            return BinarySerialization.Deserialize(fileName);
        }
    }
}