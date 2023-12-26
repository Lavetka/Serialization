using System;
using System.Text.Json;

namespace JsonSerialization
{
    public static class JsonSerialization
    {
        public static void Serialize(Department department, string fileName)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(department, options);
            File.WriteAllText(fileName, jsonString);
        }

        public static Department Deserialize(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Department>(jsonString);
        }
    }
}

