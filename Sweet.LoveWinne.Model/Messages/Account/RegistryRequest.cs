using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class RegistryRequest:BaseRequest
	{
		public string UserName{ set; get; }

		public string Password{ set; get; }
	}
}

