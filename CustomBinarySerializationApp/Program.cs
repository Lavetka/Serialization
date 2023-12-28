using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Binary
{
    class Program
    {
        static void Main()
        {
            // Create an instance of the Person class
            Person person = new Person
            {
                Name = "John Doe",
                Age = 30
            };

            // Serialize to a binary file using custom serialization
            SerializeCustomPerson(person, "person.dat");

            // Deserialize from the binary file using custom deserialization
            Person deserializedPerson = DeserializeCustomPerson("person.dat");

            // Display the deserialized person's information
            Console.WriteLine($"Deserialized Person - Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
        }

        static void SerializeCustomPerson(Person person, string fileName)
        {
            // Use FileStream for custom binary serialization
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                person.SerializeCustom(stream);
            }

            Console.WriteLine("Person serialized to binary file using custom serialization.");
        }

        static Person DeserializeCustomPerson(string fileName)
        {
            // Use FileStream for custom binary deserialization
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                return Person.DeserializeCustom(stream);
            }
        }
    }
}
