using System;
using Sweet.LoveWinne.Model;

namespace Sweet.LoveWinne.Service
{
	public interface IShadowProxyService
	{
		/// <summary>
		/// Gets the server list.
		/// </summary>
		/// <returns>The server list.</returns>
		/// <param name="request">Request.</param>
		GetServerListResponse GetServerList (GetServerListRequest request);
	}
}

