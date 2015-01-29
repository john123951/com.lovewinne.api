using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public class ClientAuthAttribute : Attribute
	{
		public string ClientId { get; set; }

		public string ClientKey { get; set; }
	}
}

