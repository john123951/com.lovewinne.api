using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sweet.LoveWinne.Utility
{
	/// <summary>
	/// 字符串类型扩展方法类
	/// </summary>
	public static class StringExtention
	{
		public static string Utf8String (this byte[] bytes)
		{
			return bytes == null ? null : Encoding.UTF8.GetString (bytes);
		}

		public static byte[] Utf8Bytes (this string s)
		{
			return s.IsNullOrEmpty () ? null : Encoding.UTF8.GetBytes (s);
		}

		public static bool IsNullOrEmpty (this string value)
		{
			return string.IsNullOrEmpty (value);
		}

		public static NameValueCollection ToNameValueCollection (this string queryString)
		{
			if (string.IsNullOrWhiteSpace (queryString))
				return new NameValueCollection ();

			var queryParameters = new NameValueCollection ();
			var querySegments = queryString.Split ('&');

			foreach (var segment in querySegments) {
				var parts = segment.Split ('=');
				if (parts.Length > 0) {
					var key = parts [0].Trim (new char[] { '?', ' ' });
					var val = parts [1].Trim ();

					queryParameters.Add (key, val);
				}
			}

			return queryParameters;
		}

		public static string ToCamelCase (this string s)
		{
			if (string.IsNullOrEmpty (s))
				return s;

			if (!char.IsUpper (s [0]))
				return s;

			string camelCase = char.ToLower (s [0], CultureInfo.InvariantCulture).ToString (CultureInfo.InvariantCulture);
			if (s.Length > 1)
				camelCase += s.Substring (1);

			return camelCase;
		}

		public static void WriteLog (this string message, string name, Log4NetType logType)
		{
			var log = LogUtility.GetInstance ().GetLog (name);
			if (log == null) {
				return;
			}

			switch (logType) {
				case Log4NetType.Debug:
					log.Debug (message);
					break;

				case Log4NetType.Error:
					log.Error (message);
					break;

				case Log4NetType.Fatal:
					log.Fatal (message);
					break;

				case Log4NetType.Info:
					log.Info (message);
					break;

				case Log4NetType.Warn:
					log.Warn (message);
					break;

				default:
					log.Warn (message);
					break;
			}
		}

	}
}

