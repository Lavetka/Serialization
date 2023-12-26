using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace BinarySerialization
{
    public static class BinarySerialization
    {
        // OBSOLETE
        /*  public static void Serialize(Department department, string fileName)
          {
              BinaryFormatter formatter = new BinaryFormatter();
              using (FileStream stream = new FileStream(fileName, FileMode.Create))
              {
                  formatter.Serialize(stream, department);
              }
          }

          public static Department Deserialize(string fileName)
          {
              BinaryFormatter formatter = new BinaryFormatter();
              using (FileStream stream = new FileStream(fileName, FileMode.Open))
              {
                  return (Department)formatter.Deserialize(stream);
              }
          }
        */

        public static void Serialize(Department department, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(department);
            File.WriteAllText(fileName, jsonString);
        }

        public static Department Deserialize(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Department>(jsonString);
        }
    }
}

