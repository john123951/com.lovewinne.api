using System;
using System.Configuration;

namespace Sweet.LoveWinne.Infrastructure
{
	public static class AppSettingsConfigManager
	{
		/// <summary>
		/// 网站Url
		/// </summary>
		public static string WebSite {
			get {
				return ReadConfiguration ("WebSite", @"http://www.hk515.com", x => Convert.ToString (x));
			}
		}

		/// <summary>
		/// 读取AppSettings配置节
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="settingKey">AppSettings中的Key值</param>
		/// <param name="defValue">转换失败时的默认值</param>
		/// <param name="converter">转换函数</param>
		/// <returns></returns>
		private static T ReadConfiguration<T> (string settingKey, T defValue, Func<String, T> converter)
		{
			string settingValue = ConfigurationManager.AppSettings [settingKey];

			if (string.IsNullOrWhiteSpace (settingValue)) {
				return defValue;
			}

			try {
				return converter.Invoke (settingValue);
			} catch (Exception) {
				return defValue;
			}
		}
	}
}