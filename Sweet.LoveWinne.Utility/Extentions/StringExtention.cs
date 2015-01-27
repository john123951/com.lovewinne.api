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
		public static string Utf8String(this byte[] bytes)
		{
			return bytes == null ? null : Encoding.UTF8.GetString(bytes);
		}

		public static byte[] Utf8Bytes(this string s)
		{
			return s.IsNullOrEmpty() ? null : Encoding.UTF8.GetBytes(s);
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static NameValueCollection ToNameValueCollection(this string queryString)
		{
			if (string.IsNullOrWhiteSpace(queryString)) return new NameValueCollection();

			var queryParameters = new NameValueCollection();
			var querySegments = queryString.Split('&');

			foreach (var segment in querySegments)
			{
				var parts = segment.Split('=');
				if (parts.Length > 0)
				{
					var key = parts[0].Trim(new char[] { '?', ' ' });
					var val = parts[1].Trim();

					queryParameters.Add(key, val);
				}
			}

			return queryParameters;
		}

		public static string ToCamelCase(this string s)
		{
			if (string.IsNullOrEmpty(s))
				return s;

			if (!char.IsUpper(s[0]))
				return s;

			string camelCase = char.ToLower(s[0], CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
			if (s.Length > 1)
				camelCase += s.Substring(1);

			return camelCase;
		}

		/// <summary>
		/// 移除字符串中的Html标签
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static string RemoveHtml(this string src)
		{
			if (string.IsNullOrEmpty(src)) { return string.Empty; }

			string rx = @"<(\S*?)[^>]*>.*?</\1>|<.*? />|<.*?>";
			var result = Regex.Replace(src, rx, string.Empty, RegexOptions.IgnoreCase);
			return result;
		}

		/// <summary>
		/// 移除字符串中的Html编码字符
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static string RemoveHtmlEncode(this string src)
		{
			if (string.IsNullOrEmpty(src)) { return string.Empty; }

			return src.Replace("&nbsp;", string.Empty);
		}

		/// <summary>
		/// 将HTML去除
		/// </summary>
		/// <param name="txt"></param>
		/// <returns></returns>
		public static string DelHTML(string txt)
		{
			txt = Regex.Replace(txt, @"<(.[^>]*)>", string.Empty);
			txt = Regex.Replace(txt, @"&\w{1,7};", string.Empty);
			txt = txt.Replace(" ", string.Empty);

			//删除脚本
			//Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
			//删除HTML
			// Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
			//Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
			// Htmlstring.Replace("<", "");
			//Htmlstring.Replace(">", "");
			// Htmlstring.Replace("\r\n", "");
			return txt;
		}
	}
}

