using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class RegisterRequest : BaseRequest
	{
		public string UserName{ set; get; }

		public string Password{ set; get; }
	}
}

