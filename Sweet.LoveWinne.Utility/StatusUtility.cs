using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Sweet.LoveWinne.Utility
{
	[XmlRoot ("status")]
	internal class MessageStatus:List<MessageStatus.MessageItem>
	{
		internal class MessageItem
		{
			[XmlAttribute]
			public string code { get; set; }

			[XmlAttribute]
			public string message { get; set; }
		}

	}


	public class StatusUtility
	{
		private static StatusUtility _instance;
		private readonly Dictionary<string, string> _messageDictionary;

		private StatusUtility ()
		{			
		}

		protected StatusUtility (string xmlConfigPath)
		{
			var xmlSerilizer = new XmlSerializer (typeof(MessageStatus));

			var path = string.Format ("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory, xmlConfigPath);

			using (var fsReader = File.OpenRead (path)) {

				var model = xmlSerilizer.Deserialize (fsReader) as MessageStatus;
				if (model != null) {
					this._messageDictionary = new Dictionary<string, string> ();

					foreach (var item in model) {
						this._messageDictionary.Add (item.code, item.message);
					}
				}

			}
		}

		public static void Register (string xmlConfigPath)
		{
			if (_instance == null) {
				_instance = new StatusUtility (xmlConfigPath);
			}
		}

		public static StatusUtility GetInstance ()
		{
			return _instance;
		}

		/// <summary>
		/// 获取状态信息
		/// </summary>
		/// <param name="statusCode">状态码</param>
		/// <returns>
		/// 返回状态信息
		/// </returns>
		public string GetMessage (string statusCode)
		{
			return _messageDictionary.ContainsKey (statusCode) ? _messageDictionary [statusCode] : string.Empty;
		}
	}
}

