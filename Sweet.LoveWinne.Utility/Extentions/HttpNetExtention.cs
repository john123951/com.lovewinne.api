using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

namespace Sweet.LoveWinne.Utility
{
	public static class HttpNetExtention
	{
		/// <summary>
		/// 读取header标头，如果不存在，返回空字符串
		/// </summary>
		/// <param name="headers">The headers</param>
		/// <param name="key">The key</param>
		/// <returns>
		/// The String
		/// </returns>
		public static string Read (this HttpRequestHeaders headers, string key)
		{
			IEnumerable<string> values;
			headers.TryGetValues (key, out values);
			return values == null ? string.Empty : values.FirstOrDefault () ?? string.Empty;
		}
	}
}

