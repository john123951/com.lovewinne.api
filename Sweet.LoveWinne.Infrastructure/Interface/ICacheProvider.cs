using System;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Infrastructure
{
	public interface ICacheProvider
	{
		T Get<T> (string cache_key);

		IDictionary<string, object> GetAll (List<string> keys);

		List<string> GetCacheKeys ();

		bool Append (string key, object value);

		bool Set (string cache_key, object cache_object);

		bool Set (string cache_key, object cache_object, DateTime expiration);

		bool Set (string cache_key, object cache_object, TimeSpan expiration);

		bool Delete (string cache_key);

		void Delete (System.Collections.Generic.List<string> cache_keys);

		bool Exists (string cache_key);

		void Flush ();
	}
}

