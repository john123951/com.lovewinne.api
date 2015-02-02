using System;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Sweet.LoveWinne.Utility;
using System.Net;

namespace Sweet.LoveWinne.Infrastructure
{
	public class JsonFormatter : MediaTypeFormatter
	{
		private static readonly MediaTypeHeaderValue ApplicationJsonMediaType = new MediaTypeHeaderValue ("application/json");
		private static readonly MediaTypeHeaderValue TextJsonMediaType = new MediaTypeHeaderValue ("text/json");

		public JsonFormatter ()
		{
			// Set default supported media types
			SupportedMediaTypes.Add (ApplicationJsonMediaType.Clone ());
			SupportedMediaTypes.Add (TextJsonMediaType.Clone ());
		}

		public override bool CanReadType (Type type)
		{
			return CanReadTypeCore (type);
		}

		public override bool CanWriteType (Type type)
		{
			return CanReadTypeCore (type);
		}

		public override Task<object> ReadFromStreamAsync (Type type,
		                                                  Stream readStream,
		                                                  HttpContent content,
		                                                  IFormatterLogger formatterLogger)
		{
			#if DEBUG
			Debug.WriteLine ("ReadFromStreamAsync");
			Debug.WriteLine (type.FullName);
			#endif
			var task = Task.Factory.StartNew<object> (() => {
					return JsonUtility.DeserializeFromStream (type, readStream);
				});

			return task;
		}

		public override Task WriteToStreamAsync (Type type,
		                                         object value,
		                                         Stream writeStream,
		                                         HttpContent content,
		                                         TransportContext transportContext)
		{
			#if DEBUG
			Debug.WriteLine ("WriteToStreamAsync");
			Debug.WriteLine (type.FullName);
			Debug.WriteLine (value);
			#endif
			var task = Task.Factory.StartNew (() => {
					JsonUtility.SerializeToStream (value, writeStream);
				});

			return task;
		}

		private static bool CanReadTypeCore (Type type)
		{
			//if (type == typeof(IKeyValueModel))
			//{
			//    return false;
			//}

			return true;
		}
	}
}

