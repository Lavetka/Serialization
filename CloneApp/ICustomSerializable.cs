
namespace Clone
{
	public interface ICustomSerializable
	{
        public T DeepClone<T>();
        public void SerializeCustom(Stream stream);

    }
}

