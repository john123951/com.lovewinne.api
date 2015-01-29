using System;
using System.Collections.Generic;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class GetServerListResponse: BaseResponse
	{
		public List<ServerDto> ServerList { get; set; }
	}
}

