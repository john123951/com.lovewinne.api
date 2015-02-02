using System;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Service
{
	public interface IShadowProxyService
	{
		/// <summary>
		/// Gets the server list.
		/// </summary>
		/// <returns>The server list.</returns>
		/// <param name="request">Request.</param>
		[Authentication]
		ServicesResult<GetServerListResult> GetServerList (GetServerListRequest request);
	}
}

