using System;
using ServiceStack.Text;
using System.IO;

namespace Sweet.LoveWinne.Utility
{
	public static class JsonUtility
	{
		public static string Serialize<T> (T model)
		{
			return JsonSerializer.SerializeToString (model);
		}

		public static T Deserialize<T> (string src)
		{
			return JsonSerializer.DeserializeFromString<T> (src);
		}

		public static void SerializeToStream<T> (T value, Stream writeStream)
		{
			JsonSerializer.SerializeToStream (value, writeStream);
		}

		public static object DeserializeFromStream (Type type, Stream stream)
		{
			var result = JsonSerializer.DeserializeFromStream (type, stream);
			return result;
		}
	}
}

