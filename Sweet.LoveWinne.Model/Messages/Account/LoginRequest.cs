﻿using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class LoginRequest : BaseRequest
	{
		public string ClientId { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }
	}
}

