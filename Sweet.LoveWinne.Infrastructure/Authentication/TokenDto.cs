using System;

namespace Sweet.LoveWinne.Infrastructure
{
	public class TokenDto
	{
		public long UserId { get; set; }

		public string AccessToken { get; set; }

		public DateTime ExpiredTime { get; set; }
	}
}

