using System;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Infrastructure
{
	public class JsonContentNegotiator : IContentNegotiator
	{
		private readonly MediaTypeFormatter _jsonFormatter;

		public JsonContentNegotiator (MediaTypeFormatter formatter)
		{
			_jsonFormatter = formatter;
		}

		public ContentNegotiationResult Negotiate (Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
		{
			var result = new ContentNegotiationResult (_jsonFormatter, new MediaTypeHeaderValue ("application/json"));
			return result;
		}
	}
}

