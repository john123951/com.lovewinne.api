using System;
using Sweet.LoveWinne.Model;
using Sweet.LoveWinne.Infrastructure;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Service
{
	public interface IShadowServerService
	{
		/// <summary>
		/// Gets the server list.
		/// </summary>
		/// <returns>The server list.</returns>
		/// <param name="request">Request.</param>
		ServicesResult<List<ServerDto>> GetServerList (long userId);
	}
}

