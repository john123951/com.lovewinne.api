using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Sweet.LoveWinne.Infrastructure
{
	/// <summary>
	/// 为Http请求添加头  Content-Type: application/json
	/// </summary>
	public class IgnoreJsonHeaderHandler : DelegatingHandler
	{
		private static readonly MediaTypeHeaderValue ApplicationJsonMediaType = new MediaTypeHeaderValue ("application/json");

		protected override Task<HttpResponseMessage> SendAsync (HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.Content.Headers.ContentType = ApplicationJsonMediaType;

			return base.SendAsync (request, cancellationToken);
		}
	}
}

