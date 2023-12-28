namespace Clone
{
    public static class DeepCopyHelper
    {
        public static T DeepCopy<T>(T obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            if (obj is ICustomSerializable customSerializable)
            {
                return customSerializable.DeepClone<T>();
            }
            else
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(obj);
                return System.Text.Json.JsonSerializer.Deserialize<T>(jsonString);
            }
        }
    }
}

