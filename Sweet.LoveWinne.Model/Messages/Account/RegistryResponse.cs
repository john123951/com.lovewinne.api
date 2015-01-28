using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class RegistryResponse:BaseResponse
	{
		public string Token { get; set; }

		public string Notify { get; set; }
	}
}

