﻿using System;
using Sweet.LoveWinne.Infrastructure;

namespace Sweet.LoveWinne.Model
{
	public class AuthRequest : BaseRequest
	{
		public UserInfo UserInfo { get; set; }
	}
}

