using System;
using Sweet.LoveWinne.Model;
using System.Collections.Generic;

namespace Sweet.LoveWinne.Repository
{
	public interface IShadowServerRepository
	{
		List<ServerInfo> GetServerListByUserId (long userId);
	}
}

